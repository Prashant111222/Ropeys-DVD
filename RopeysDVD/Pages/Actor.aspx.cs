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
    public partial class Actor1 : System.Web.UI.Page
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
                        if (usertype == "Staff")
                        {
                            Response.Write("<script>alert('Staff Staff')</script>");
                            Response.Redirect("Unauthorized.aspx");
                        }
                    }
                    ViewActors();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('exception)</script>");
            }
        }

        protected void ViewActors()
        {
            try
            {
                Actor actor = new Actor();
                ActorGridView.DataSource = actor.SelectActor();
                ActorGridView.DataBind();
                actor = null;
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
                Actor actor = new Actor();
                actor.AddActor(actorSurname.Text, actorFirstName.Text);
                Result.Text = "Inserted !!";
                ViewActors();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Clear_Fields()
        {
            actorNumber.Text = "";
            actorSurname.Text = "";
            actorFirstName.Text = "";
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ActorGridView.PageIndex = e.NewPageIndex;
            this.ViewActors();
        }

        protected void ActorGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM Actor Where ActorNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Actor");
            DataTable dt = ds.Tables[0];

            actorNumber.Text = dt.Rows[0]["ActorNumber"].ToString();
            actorSurname.Text = dt.Rows[0]["ActorSurname"].ToString();
            actorFirstName.Text = dt.Rows[0]["ActorFirstName"].ToString();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                Actor actor = new Actor();
                actor.DeleteActor(actorNumber.Text);
                Result.Text = "Actor Deleted!!";
                ViewActors();
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
                Actor actor = new Actor();
                actor.UpdateActor(actorNumber.Text, actorSurname.Text, actorFirstName.Text);
                Result.Text = "Actor Updated!!";
                ViewActors();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }
    }
}