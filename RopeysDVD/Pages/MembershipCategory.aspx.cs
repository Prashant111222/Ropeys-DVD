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
    public partial class MembershipCategory1 : System.Web.UI.Page
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
                    ViewMembershipCategory();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception)</script>");
            }
        }

        protected void ViewMembershipCategory()
        {
            try
            {
                MembershipCategory cat = new MembershipCategory();
                MembershipCategoryGV.DataSource = cat.SelectMembershipCategory();
                MembershipCategoryGV.DataBind();
                cat = null;
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
                MembershipCategory cat = new MembershipCategory();
                cat.AddMembershipCategory(categoryDescription.Text, totalLoans.Text);
                Result.Text = "Category Inserted !!";
                ViewMembershipCategory();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Clear_Fields()
        {
            categoryNumber.Text = "";
            categoryDescription.Text = "";
            totalLoans.Text = "";
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MembershipCategoryGV.PageIndex = e.NewPageIndex;
            this.ViewMembershipCategory();
        }

        protected void MembershipCategoryGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM MembershipCategory Where MembershipCategoryNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "MembershipCategory");
            DataTable dt = ds.Tables[0];

            categoryNumber.Text = dt.Rows[0]["MembershipCategoryNumber"].ToString();
            categoryDescription.Text = dt.Rows[0]["MembershipCategoryDescription"].ToString();
            totalLoans.Text = dt.Rows[0]["MembershipCategoryTotalLoans"].ToString();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if (categoryNumber.Text != "")
            {
                try
                {
                    MembershipCategory cat = new MembershipCategory();
                    cat.DeleteMembershipCategory(categoryNumber.Text);
                    Result.Text = "Category Deleted!!";
                    ViewMembershipCategory();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a Membership Category From the Table";
            }
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            if (categoryNumber.Text != "")
            {
                try
                {
                    MembershipCategory cat = new MembershipCategory();
                    cat.UpdateMembershipCategory(categoryNumber.Text, categoryDescription.Text, totalLoans.Text);
                    Result.Text = "Category Updated!!";
                    ViewMembershipCategory();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a Membership Category From the Table";
            }
        }
    }
}