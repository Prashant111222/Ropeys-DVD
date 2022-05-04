using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RopeysDVD
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //getting the list of the actors
                Index index = new Index();
                actorList.DataSource = index.GetActorDetails();
                actorList.DataTextField = "ActorSurname";
                actorList.DataValueField = "ActorNumber";
                actorList.DataBind();
                actorList.Items.Insert(0, new ListItem("-- Actor Last Name --", ""));

                DVDDetails();

                //getting the list of actors
                Index index1 = new Index();
                actorList1.DataSource = index1.GetActorDetails();
                actorList1.DataTextField = "ActorSurname";
                actorList1.DataValueField = "ActorNumber";
                actorList1.DataBind();
                actorList1.Items.Insert(0, new ListItem("-- Actor Last Name --", ""));

                DVDDetails1();
            }
        }

        protected void DVDDetails()
        {
            try
            {
                Index index = new Index();
                MovieGV.DataSource = index.GetDVDTitleDetails();
                MovieGV.DataBind();
            }
            catch(Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void DVDDetails1()
        {
            try
            {
                Index index = new Index();
                MovieGV1.DataSource = index.GetMovieDetails();
                MovieGV1.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void ActorChanged(object sender, EventArgs e)
        {
            //movie details for the specific actor
            try
            {
                Index index = new Index();
                MovieGV.DataSource = index.GetDVDTitleDetails(Int32.Parse(actorList.SelectedValue));
                MovieGV.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }

        protected void ActorChanged1(object sender, EventArgs e)
        {
            //movie details for the specific actor
            try
            {
                Index index = new Index();
                MovieGV1.DataSource = index.GetMovieDetails(Int32.Parse(actorList1.SelectedValue));
                MovieGV1.DataBind();
            }
            catch (Exception)
            {
                Result.Text = "Server Error - 500";
            }
        }
    }
}