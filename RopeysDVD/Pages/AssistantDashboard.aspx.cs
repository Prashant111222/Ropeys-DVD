using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeysDVD
{
    public partial class AssistantDashboard : System.Web.UI.Page
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

                    //contents to be included in the page

                    //member last name to be displayed in the dropdown list
                    Dashboard dash = new Dashboard();
                    memberList.DataSource = dash.GetMemberDetails();
                    memberList.DataTextField = "MemberLastName";
                    memberList.DataValueField = "MemberNumber";
                    memberList.DataBind();
                    memberList.Items.Insert(0, new ListItem("-- Member Last Name --", ""));

                    ViewMemberDetails();

                    ViewMovieDetails();

                    Dashboard dashboard = new Dashboard();
                    copyNumberList.DataSource = dashboard.GetDVDCopyNumber();
                    copyNumberList.DataTextField = "CopyNumber";
                    copyNumberList.DataTextField = "CopyNumber";
                    copyNumberList.DataBind();
                    copyNumberList.Items.Insert(0, new ListItem("-- DVD Copy Number --", ""));

                    ViewCopyDetails();

                    ViewCurrentLoans();

                    ViewBriefLoanDetails();

                    ViewDetailedLoanDetails();

                    ViewMemberWithoutLoans();

                    ViewCopyWithoutLoans();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception)</script>");
            }
        }

        protected void ViewMemberDetails()
        {
            try
            {
                Dashboard dash = new Dashboard();
                MovieDetailGV.DataSource = dash.GetOldMovies();
                MovieDetailGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void MemberChanged(object sender, EventArgs e)
        {
            //movie details of specific actor
            try
            {
                Dashboard dash = new Dashboard();
                MovieDetailGV.DataSource = dash.GetOldMovies(Int32.Parse(memberList.SelectedValue));
                MovieDetailGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void ViewMovieDetails()
        {
            //movie details ordered by released date and cast member
            try
            {
                Dashboard dash = new Dashboard();
                MovieDetailGV1.DataSource = dash.GetMovieDetails();
                MovieDetailGV1.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void ViewCopyDetails()
        {
            try
            {
                Dashboard dash = new Dashboard();
                CopyDetailsGV.DataSource = dash.GetDVDCopyDetails();
                CopyDetailsGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void CopyNumberChanged(object sender, EventArgs e)
        {
            //Details of Specific loan number
            try
            {
                Dashboard dash = new Dashboard();
                CopyDetailsGV.DataSource = dash.GetDVDCopyDetails(Int32.Parse(copyNumberList.SelectedValue));
                CopyDetailsGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void ViewCurrentLoans()
        {
            try
            {
                Dashboard dash = new Dashboard();
                CurrentLoanGV.DataSource = dash.GetMemberLoanDetails();
                CurrentLoanGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void ViewBriefLoanDetails()
        {
            try
            {
                Dashboard dash = new Dashboard();
                BriefLoanGV.DataSource = dash.GetLoanedMovieDetails();
                BriefLoanGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void ViewDetailedLoanDetails()
        {
            try
            {
                Dashboard dash = new Dashboard();
                DetailedLoanGV.DataSource = dash.GetMovieOnLoan();
                DetailedLoanGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void ViewMemberWithoutLoans()
        {
            try
            {
                Dashboard dash = new Dashboard();
                MemberNoLoanGV.DataSource = dash.GetNoBorrowedMovies();
                MemberNoLoanGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void ViewCopyWithoutLoans()
        {
            try
            {
                Dashboard dash = new Dashboard();
                CopyNoLoanGV.DataSource = dash.GetNoLoanedMovies();
                CopyNoLoanGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }
    }
}