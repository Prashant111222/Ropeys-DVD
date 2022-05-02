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
    public partial class Member1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewMembers();

                //for dsiplaying membership categories in th dropdown list
                MembershipCategory cat = new MembershipCategory();
                membershipCategory.DataSource = cat.SelectMembershipCategory();
                membershipCategory.DataTextField = "MembershipCategoryDescription";
                membershipCategory.DataValueField = "MembershipCategoryNumber";
                membershipCategory.DataBind();
                membershipCategory.Items.Insert(0, new ListItem("-- Select Membership Category --", ""));
            }
        }

        protected void ViewMembers()
        {
            try
            {
                Member member = new Member();
                MemberGV.DataSource = member.SelectMember();
                MemberGV.DataBind();
                member = null;
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
                Member member = new Member();
                member.AddMember(membershipCategory.SelectedValue, lastName.Text, firstName.Text, address.Text,  datePicker.Text);
                Result.Text = "Member Inserted !!";
                ViewMembers();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Clear_Fields()
        {
            memberNumber.Text = "";
            membershipCategory.SelectedIndex = 0;
            lastName.Text = "";
            firstName.Text = "";
            address.Text = "";
            datePicker.Text = System.DateTime.Today.ToString();
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MemberGV.PageIndex = e.NewPageIndex;
            this.ViewMembers();
        }

        protected void MemberGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM Member Where MemberNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Member");
            DataTable dt = ds.Tables[0];

            memberNumber.Text = dt.Rows[0]["MemberNumber"].ToString();
            membershipCategory.SelectedValue = dt.Rows[0]["MembershipCategoryNumber"].ToString();
            lastName.Text = dt.Rows[0]["MemberLastName"].ToString();
            firstName.Text = dt.Rows[0]["MemberFirstName"].ToString();
            address.Text = dt.Rows[0]["MemberAddress"].ToString();
            datePicker.Text = dt.Rows[0]["MemberDateOfBirth"].ToString();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                Member member = new Member();
                member.DeleteMember(memberNumber.Text);
                Result.Text = "Member Deleted!!";
                ViewMembers();
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
                Member member = new Member();
                member.UpdateMember(memberNumber.Text, membershipCategory.Text, lastName.Text, firstName.Text, address.Text, datePicker.Text);
                Result.Text = "Member Updated!!";
                ViewMembers();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }
    }
}