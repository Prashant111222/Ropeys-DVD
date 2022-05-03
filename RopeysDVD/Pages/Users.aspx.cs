using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeysDVD.Pages
{
	public partial class Users : System.Web.UI.Page
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
                            Response.Write("<script>alert('Staff Staff')</script>");
                            Response.Redirect("Unauthorized.aspx");
                        }
                    }
                    ViewUsers();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception)</script>");
            }
		}

        protected void ViewUsers()
        {
            try
            {
                User user = new User();
                UserGV.DataSource = user.SelectUser();
                UserGV.DataBind();
                user = null;
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
                User user = new User();
                user.AddUser(userName.Text, userType.Text, userPassword.Text);
                Result.Text = "User Inserted !!";
                ViewUsers();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Clear_Fields()
        {
            userNumber.Text = "";
            userName.Text = "";
            userPassword.Text = "";
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UserGV.PageIndex = e.NewPageIndex;
            this.ViewUsers();
        }

        protected void UserGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM [User] Where UserNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "User");
            DataTable dt = ds.Tables[0];

            userNumber.Text = dt.Rows[0]["UserNumber"].ToString();
            userPassword.Text = dt.Rows[0]["UserPassword"].ToString();
            userType.SelectedValue = dt.Rows[0]["UserType"].ToString();
            userName.Text = dt.Rows[0]["UserName"].ToString();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if (userNumber.Text != "")
            {
                try
                {
                    User user = new User();
                    user.DeleteUser(userNumber.Text);
                    Result.Text = "User Deleted!!";
                    ViewUsers();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a User From the Table";
            }
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            if (userNumber.Text != "")
            {
                try
                {
                    User user = new User();
                    user.UpdateUser(userNumber.Text, userName.Text, userPassword.Text);
                    Result.Text = "User Updated!!";
                    ViewUsers();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a User From the Table";
            }
        }
    }
}