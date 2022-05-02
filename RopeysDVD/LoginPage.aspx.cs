using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace RopeysDVD
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie userCookie = Request.Cookies["userCookie"];
                if (userCookie == null)
                {
                    return;
                }
                else if (!string.IsNullOrEmpty(userCookie.Values["username"]))
                {
                    Response.Redirect("Home.aspx");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('error')</script>");
            }
        }

        protected void Signin_Button_Click1(object sender, EventArgs e)
        {
            string sqlcon = System.Configuration.ConfigurationManager.AppSettings.Get("DBConnection").ToString();
            SqlConnection con = new SqlConnection(sqlcon);

            string sql = "SELECT * FROM [User] where UserName= '" + tfUserName.Text + "' and UserPassword = '" + tfPassword.Text + "' and UserType='" + ddUserType.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                HttpCookie userCookie = new HttpCookie("userCookie");
                userCookie.Values.Add("username", tfUserName.Text);
                userCookie.Values.Add("password", tfPassword.Text);
                userCookie.Values.Add("userType", ddUserType.SelectedItem.ToString());

                userCookie.Expires = DateTime.Now.AddMinutes(1);
                Response.Cookies.Add(userCookie);


                Response.Write("<script>alert('Login successful')</script>");
                if (ddUserType.SelectedIndex == 0)
                {
                    Response.Redirect("Home.aspx");
                }
                else if (ddUserType.SelectedIndex == 1)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                lblStatus.Text = "Invalid credentials! Please try again.";
            }
        }
    }
}