using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeysDVD.Pages
{
    public partial class ChangePassword : System.Web.UI.Page
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
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception)</script>");
            }
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            if(newPassword.Text == confirmPassword.Text)
            {
                try
                {
                    HttpCookie userCookie = Request.Cookies["userCookie"];

                    if (!string.IsNullOrEmpty(userCookie.Values["userNumber"]))
                    {
                        //getting the user ID from the stored cookie
                        string userNumber = userCookie.Values["userNumber"].ToString();
                        string userOldPassword = userCookie.Values["password"].ToString();

                        //checking if old password matched
                        if(userOldPassword == oldPassword.Text)
                        {
                            User user = new User();
                            user.ChangePassword(userNumber, newPassword.Text);
                            Result.Text = "Password Changed!!";
                            Clear_Fields();

                            //clearing the cookies and logging out the user
                            if (Request.Cookies["userCookie"] != null)
                            {
                                Response.Cookies["userCookie"].Expires = DateTime.Now.AddDays(-1);
                                Response.Redirect("LoginPage.aspx");
                            }
                        }
                        else
                        {
                            Result.Text = "Old Password Did Not Match";
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "The Confirm Password Did Not Match!";
            }
        }

        protected void Clear_Fields()
        {
            oldPassword.Text = "";
            newPassword.Text = "";
            confirmPassword.Text = "";
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }
    }
}