using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeysDVD.Pages
{
    public partial class OutdatedMovies : System.Web.UI.Page
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

                    //loading the list of outdated movies
                    ViewOutdatedMovies();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception)</script>");
            }
        }

        protected void ViewOutdatedMovies()
        {
            try
            {
                //outdated movies in the table
                OutdatedMovie movie = new OutdatedMovie();
                OutdatedMovieGV.DataSource = movie.GetOutdatedMovies();
                OutdatedMovieGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void OutdatedMovieGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "DeleteDVD":
                        //removing teh outdated movie
                        OutdatedMovie movie = new OutdatedMovie();
                        int id = Convert.ToInt32(e.CommandArgument);
                        GridViewRow record = OutdatedMovieGV.Rows[id];

                        movie.RemoveOutdatedMovies(int.Parse(record.Cells[0].Text));
                        Result.Text = "Movie Successfully Removed!";
                        ViewOutdatedMovies();

                        break;
                    default:
                        return;
                }
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }
    }
}