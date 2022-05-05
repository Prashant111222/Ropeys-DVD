using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeysDVD
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userCookie"] != null)
            {
                login_sts.Text = "Sign out";
            }
            else
            {
                login_sts.Text = "Sign in";
            }
        }
        protected void btnSignout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["userCookie"] != null)
            {
                Response.Cookies["userCookie"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}