using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RopeysDVD
{
    public partial class DVDCopy1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HttpCookie userCookie = Request.Cookies["userCookie"];
                    if (userCookie == null)
                    {
                        Response.Redirect("LoginPage.aspx");
                    }

                    //cookie found
                    if (!string.IsNullOrEmpty(userCookie.Values["userType"]))
                    {
                        string usertype = userCookie.Values["userType"].ToString();
                        if (usertype == "Staff")
                        {
                            Response.Write("<script>alert('hyaa staff muji')</script>");
                            Response.Redirect("Unauthorized.aspx");
                        }
                    }
                    ViewCopies();
                    DVDTitle title = new DVDTitle();
                    dvdNumber.DataSource = title.SelectDVDTitle();
                    dvdNumber.DataTextField = "DVDTitle";
                    dvdNumber.DataValueField = "DVDNumber";
                    dvdNumber.DataBind();
                    dvdNumber.Items.Insert(0, new ListItem("-- Select DVD --", ""));
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception)</script>");
            }
        }

        protected void ViewCopies()
        {
            try
            {
                DVDCopy copy = new DVDCopy();
                CopyGV.DataSource = copy.SelectDVDCopy();
                CopyGV.DataBind();
                copy = null;
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                DVDCopy copy = new DVDCopy();
                copy.AddDVDCopy(dvdNumber.SelectedValue, datePicker.Text);
                Result.Text = "DVD COpy Inserted !!";
                ViewCopies();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Clear_Fields()
        {
            copyNumber.Text = "";
            dvdNumber.SelectedIndex = 0;
            datePicker.Text = System.DateTime.Today.ToString();
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CopyGV.PageIndex = e.NewPageIndex;
            this.ViewCopies();
        }

        protected void CopyGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM DVDCopy Where CopyNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "DVDCopy");
            DataTable dt = ds.Tables[0];

            copyNumber.Text = dt.Rows[0]["CopyNumber"].ToString();
            dvdNumber.SelectedValue = dt.Rows[0]["DVDNumber"].ToString();
            datePicker.Text = dt.Rows[0]["DatePurchased"].ToString();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DVDCopy copy = new DVDCopy();
                copy.DeleteDVDCopy(copyNumber.Text);
                Result.Text = "DVD Copy Deleted!!";
                ViewCopies();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            try
            {
                DVDCopy copy = new DVDCopy();
                copy.UpdateDVDCopy(copyNumber.Text, dvdNumber.SelectedValue, datePicker.Text);
                Result.Text = "DVD Copy Updated!!";
                ViewCopies();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }
    }
}