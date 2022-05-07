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
    public partial class Studio1 : System.Web.UI.Page
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
                    ViewStudios();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception)</script>");
            }
        }

        protected void ViewStudios()
        {
            try
            {
                Studio studio = new Studio();
                StudioGV.DataSource = studio.SelectStudio();
                StudioGV.DataBind();
                studio = null;
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StudioGV.PageIndex = e.NewPageIndex;
            this.ViewStudios();
        }

        protected void Clear_Fields()
        {
            studioNumber.Text = "";
            studioName.Text = "";
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Studio studio = new Studio();
                studio.AddStudio(studioName.Text);
                Result.Text = "Studio Inserted !!";
                ViewStudios();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            if (studioNumber.Text != "")
            {
                try
                {
                    Studio studio = new Studio();
                    studio.UpdateStudio(studioNumber.Text, studioName.Text);
                    Result.Text = "Studio Updated!!";
                    ViewStudios();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a Studio from the Table";
            }
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if (studioNumber.Text != "")
            {
                try
                {
                    Studio studio = new Studio();
                    studio.DeleteStudio(studioNumber.Text);
                    Result.Text = "Studio Deleted!!";
                    ViewStudios();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a Studio from the Table";
            }
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void StudioGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM Studio Where StudioNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Studio");
            DataTable dt = ds.Tables[0];

            if(dt.Rows.Count > 0)
            {
                studioName.Text = dt.Rows[0]["StudioName"].ToString();
                studioNumber.Text = dt.Rows[0]["StudioNumber"].ToString();
            }    
        }
    }
}