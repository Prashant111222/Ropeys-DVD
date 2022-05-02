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
    public partial class LoanType1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) ViewLoanTypes();
        }

        protected void ViewLoanTypes()
        {
            try
            {
                LoanType loan = new LoanType();
                LoanTypeGV.DataSource = loan.SelectLoanType();
                LoanTypeGV.DataBind();
                loan = null;
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Clear_Fields()
        {
            loanTypeNumber.Text = "";
            loanType.Text = "";
            loanDuration.Text = "";
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                LoanType loan = new LoanType();
                loan.AddLoanType(loanType.Text, loanDuration.Text);
                Result.Text = "Loan Type Inserted !!";
                ViewLoanTypes();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoanTypeGV.PageIndex = e.NewPageIndex;
            this.ViewLoanTypes();
        }

        protected void LoanTypeGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM LoanType Where LoanTypeNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "LoanType");
            DataTable dt = ds.Tables[0];

            loanTypeNumber.Text = dt.Rows[0]["LoanTypeNumber"].ToString();
            loanType.Text = dt.Rows[0]["LoanType"].ToString();
            loanDuration.Text = dt.Rows[0]["LoanDuration"].ToString();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LoanType loan = new LoanType();
                loan.DeleteLoanType(loanTypeNumber.Text);
                Result.Text = "Loan Type Deleted!!";
                ViewLoanTypes();
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
                LoanType loan = new LoanType();
                loan.UpdateLoanType(loanTypeNumber.Text, loanType.Text, loanDuration.Text);
                Result.Text = "Loan Type Updated!!";
                ViewLoanTypes();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }
    }
}