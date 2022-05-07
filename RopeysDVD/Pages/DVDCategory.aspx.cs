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
    public partial class DVDCategory1 : System.Web.UI.Page
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
                    }
                    ViewDVDCategory();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception')</script>");
            }
        }

        protected void ViewDVDCategory()
        {
            try
            {
                DVDCategory cat = new DVDCategory();
                DVDCategoryGridView.DataSource = cat.SelectDVDCategory();
                DVDCategoryGridView.DataBind();
                cat = null;
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DVDCategoryGridView.PageIndex = e.NewPageIndex;
            this.ViewDVDCategory();
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                DVDCategory cat = new DVDCategory();
                cat.AddDVDCategory(categoryDescription.Text, ageRestriction.SelectedValue);
                Result.Text = "Category Inserted !!";
                ViewDVDCategory();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }

        }

        protected void Clear_Fields()
        {
            dvdCategoryNumber.Text = "";
            categoryDescription.Text = "";
            ageRestriction.SelectedIndex = 0;
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            if (dvdCategoryNumber.Text != "")
            {
                try
                {
                    DVDCategory cat = new DVDCategory();
                    cat.UpdateDVDCategory(dvdCategoryNumber.Text, categoryDescription.Text, ageRestriction.Text);
                    Result.Text = "Category Updated!!";
                    ViewDVDCategory();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select the Category From the Table";
            }
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if (dvdCategoryNumber.Text != "")
            {
                try
                {
                    DVDCategory cat = new DVDCategory();
                    cat.DeleteDVDCategory(dvdCategoryNumber.Text);
                    Result.Text = "Category Deleted!!";
                    ViewDVDCategory();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select the Category From the Table";
            }
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void DVDCategoryGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM DVDCategory Where CategoryNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "DVDCategory");
            DataTable dt = ds.Tables[0];

            if(dt.Rows.Count > 0)
            {
                dvdCategoryNumber.Text = dt.Rows[0]["CategoryNumber"].ToString();
                categoryDescription.Text = dt.Rows[0]["CategoryDescription"].ToString();
                ageRestriction.SelectedValue = dt.Rows[0]["AgeRestricted"].ToString();
            }            
        }
    }
}