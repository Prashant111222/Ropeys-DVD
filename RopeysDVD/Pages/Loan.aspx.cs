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
    public partial class Loan1 : System.Web.UI.Page
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
                    ViewLoans();

                    //for displaying loan type in the dropdown list
                    LoanType ln = new LoanType();
                    loanType.DataSource = ln.SelectLoanType();
                    loanType.DataTextField = "LoanType";
                    loanType.DataValueField = "LoanTypeNumber";
                    loanType.DataBind();
                    loanType.Items.Insert(0, new ListItem("-- Select Loan Type --", ""));

                    //for displaying dvd copy in the dropdown list
                    DVDCopy copy = new DVDCopy();
                    copyNumber.DataSource = copy.GetDVDCopyTitle();
                    copyNumber.DataTextField = "DVDTitle";
                    copyNumber.DataValueField = "CopyNumber";
                    copyNumber.DataBind();
                    copyNumber.Items.Insert(0, new ListItem("-- Select Copy --", ""));

                    //for displaying member in the dropdown list
                    Member mem = new Member();
                    member.DataSource = mem.SelectMember();
                    member.DataTextField = "MemberFirstName";
                    member.DataValueField = "MemberNumber";
                    member.DataBind();
                    member.Items.Insert(0, new ListItem("-- Select Member --", ""));
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception)</script>");
            }
        }

        protected void ViewLoans()
        {
            try
            {
                Loan ln = new Loan();
                LoanGV.DataSource = ln.SelectLoan();
                LoanGV.DataBind();
                ln = null;
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            if (!IsEmpty())
            {
                DVDCopy copy = new DVDCopy();

                //checking if the selected movie is age restricted
                if (copy.IsAgeResticted(copyNumber.SelectedValue))
                {
                    Member mem = new Member();

                    //checking the age of the user
                    if (mem.CheckMemberAge(member.SelectedValue) < 18)
                    {
                        Result.Text = "Age Restricted Content!";
                        return;
                    }
                }

                //inserting into the loan table
                try
                {
                    Loan ln = new Loan();

                    //for total duration
                    int totalDuration = ln.GetLoanDuration(loanType.SelectedValue);

                    string dateOut = DateTime.Now.ToString();
                    string dateDue = DateTime.Now.AddDays(totalDuration).ToString();
                    ln.AddLoan(loanType.SelectedValue, copyNumber.SelectedValue, member.SelectedValue, dateOut, dateDue);

                    DVDTitle dvd = new DVDTitle();

                    //calculating the total price
                    int standardCharge = dvd.StandardCharge(copyNumber.SelectedValue) * totalDuration;
                    Result.Text = "Loan Added! Total Charge: Rs." + standardCharge;
                    ViewLoans();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select Values From the Dropdown Lists";
            }
        }

        protected void Clear_Fields()
        {
            loanNumber.Text = "";
            loanType.SelectedIndex = 0;
            copyNumber.SelectedIndex = 0;
            member.SelectedIndex = 0;
        }

        protected bool IsEmpty()
        {
            if (loanType.SelectedIndex == 0 || copyNumber.SelectedIndex == 0 || member.SelectedIndex == 0)
            {
                return true;
            }
            return false;
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoanGV.PageIndex = e.NewPageIndex;
            this.ViewLoans();
        }

        protected void LoanGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM Loan Where LoanNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Loan");
            DataTable dt = ds.Tables[0];

            loanNumber.Text = dt.Rows[0]["LoanNumber"].ToString();
            loanType.SelectedValue = dt.Rows[0]["LoanTypeNumber"].ToString();
            copyNumber.SelectedValue = dt.Rows[0]["CopyNumber"].ToString();
            member.SelectedValue = dt.Rows[0]["MemberNumber"].ToString();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!IsEmpty() && loanNumber.Text != "")
            {
                try
                {
                    Loan ln = new Loan();
                    ln.DeleteLoan(loanNumber.Text);
                    Result.Text = "Loan Deleted!!";
                    ViewLoans();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a Row From the Table";
            }
        }

        protected void Button_Return_Click(object sender, EventArgs e)
        {
            if (!IsEmpty() && loanNumber.Text != "")
            {
                try
                {
                    Loan ln = new Loan();
                    //checking if the loan has already been returned

                    if (!ln.IsReturned(loanNumber.Text))
                    {
                        DVDTitle dvd = new DVDTitle();

                        //getting the standard duration
                        int standardDuration = ln.GetLoanDuration(loanType.SelectedValue);

                        string dateReturn = DateTime.Now.ToString();
                        ln.ReturnLoan(loanNumber.Text, dateReturn);

                        //getting total duration after loan returned
                        int actualDuration = ln.TotalLoanDuration(loanNumber.Text);
                        int durationDifference = standardDuration - actualDuration;

                        //calculating the standard price
                        int standardCharge = dvd.StandardCharge(copyNumber.SelectedValue) * standardDuration;

                        //for penalty charge
                        int penaltyCharge = 0;

                        //calculating the penalty chare if it exceeds the standard loan duration
                        if (durationDifference < 0)
                        {
                            int penaltyRate = dvd.PenaltyCharge(copyNumber.SelectedValue);
                            penaltyCharge = -1 * (durationDifference * penaltyRate);
                        }

                        Result.Text = "Loan Returned! Standard Charge: Rs." + standardCharge + " Penalty Charge: Rs." + penaltyCharge;
                        ViewLoans();
                        Clear_Fields();
                    }
                    else
                    {
                        Result.Text = "The Selected Loan has Already been Returned!";
                    }
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a Row From the Table";
            }
        }
    }
}