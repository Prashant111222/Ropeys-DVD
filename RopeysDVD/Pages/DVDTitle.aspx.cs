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
    public partial class DVDTitle1 : System.Web.UI.Page
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
                    ViewDVDs();

                    //for displaying DVD categories in the dropdown list
                    DVDCategory cat = new DVDCategory();
                    dvdCategory.DataSource = cat.SelectDVDCategory();
                    dvdCategory.DataTextField = "CategoryDescription";
                    dvdCategory.DataValueField = "CategoryNumber";
                    dvdCategory.DataBind();
                    dvdCategory.Items.Insert(0, new ListItem("-- Select DVD Category --", ""));

                    //for displaying producers in the dropdown list
                    Producer prod = new Producer();
                    producer.DataSource = prod.SelectProducer();
                    producer.DataTextField = "ProducerName";
                    producer.DataValueField = "ProducerNumber";
                    producer.DataBind();
                    producer.Items.Insert(0, new ListItem("-- Select Producer --", ""));

                    //for displaying studios in the dropdown list
                    Studio st = new Studio();
                    studio.DataSource = st.SelectStudio();
                    studio.DataTextField = "StudioName";
                    studio.DataValueField = "StudioNumber";
                    studio.DataBind();
                    studio.Items.Insert(0, new ListItem("-- Select Studio --", ""));

                    //for displaying the actor list
                    Actor actors = new Actor();
                    actorList.DataSource = actors.SelectActor();
                    actorList.DataTextField = "ActorSurname";
                    actorList.DataValueField = "ActorNumber";
                    actorList.DataBind();
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('exception)</script>");
            }
        }

        protected void ViewDVDs()
        {
            try
            {
                DVDTitle dvd = new DVDTitle();
                DVDGV.DataSource = dvd.SelectDVDTitle();
                DVDGV.DataBind();
                dvd = null;
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected bool IsValidated()
        {
            if (dvdCategory.SelectedIndex == 0)
            {
                Result.Text = "Please Select DVD Category.";
                return false;
            }

            //validation with respect to studio checkbox
            if (CheckBox1.Checked)
            {
                if (studioName.Text == "")
                {
                    Result.Text = "Please Provide the Studio Name.";
                    return false;
                }
            }
            else if (studio.SelectedIndex == 0)
            {
                Result.Text = "Please Select Studio From the List";
                return false;
            }

            //validation with respect to producer checkbox
            if (CheckBox2.Checked)
            {
                if (producerName.Text == "")
                {
                    Result.Text = "Please Provide the Producer Name.";
                    return false;
                }
            }
            else if (producer.SelectedIndex == 0)
            {
                Result.Text = "Please Select Producer From the List";
                return false;
            }

            //validation with respect to actor list box
            if (CheckBox3.Checked)
            {
                if (actorFirstName.Text == "" || actorSurname.Text == "")
                {
                    Result.Text = "Please Provide the Actor Name.";
                    return false;
                }
            }
            else if (actorList.SelectedIndex == -1)
            {
                Result.Text = "Please Select Actor(s) From the List Box.";
                return false;
            }

            return true;
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            if (IsValidated())
            {
                string studioId = "";
                string producerId = "";
                string actorId = "";
                string dvdId = "";

                try
                {
                    //inserting studio name
                    if (CheckBox1.Checked)
                    {
                        Studio stud = new Studio();
                        stud.AddStudio(studioName.Text);
                        studioId = stud.LastStudio().ToString();
                    }
                    else
                    {
                        studioId = studio.SelectedValue;
                    }

                    //inserting producer name
                    if (CheckBox2.Checked)
                    {
                        Producer prod = new Producer();
                        prod.AddProducer(producerName.Text);
                        producerId = prod.LastProducer().ToString();
                    }
                    else
                    {
                        producerId = producer.SelectedValue;
                    }

                    //inserting DVD information
                    DVDTitle dvd = new DVDTitle();
                    dvd.AddDVDTitle(dvdCategory.SelectedValue, studioId, producerId, dvdTitle.Text, datePicker.Text.ToString(), standardCharge.Text, penaltyCharge.Text);
                    dvdId = dvd.LastDVDTitle().ToString();
                    ViewDVDs();


                    //inserting actor(s) details
                    if (CheckBox3.Checked)
                    {
                        //inserting actor information
                        Actor act = new Actor();
                        act.AddActor(actorSurname.Text, actorFirstName.Text);
                        actorId = act.LastActor().ToString();

                        //inserting into the cast member
                        CastMember cm = new CastMember();
                        cm.AddCastMember(dvdId, actorId);
                    }
                    else
                    {
                        CastMember cm = new CastMember();

                        //inserting into list of actors and DVD in the CastMember
                        foreach (ListItem item in actorList.Items)
                        {
                            if (item.Selected == true)
                            {
                                cm.AddCastMember(dvdId, item.Value);
                            }
                        }
                    }

                    Clear_Fields();
                    Result.Text = "Data Inserted !!";
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                    return;
                }
            }
        }

        protected void Clear_Fields()
        {
            dvdNumber.Text = "";
            studio.SelectedIndex = 0;
            producer.SelectedIndex = 0;
            dvdCategory.SelectedIndex = 0;
            dvdTitle.Text = "";
            penaltyCharge.Text = "";
            standardCharge.Text = "";
            studioName.Text = "";
            actorFirstName.Text = "";
            actorSurname.Text = "";
            producerName.Text = "";
            actorList.ClearSelection();
            datePicker.Text = System.DateTime.Today.ToString();

            //displaying other fields after clearing
            CheckBox1.Visible = true;
            CheckBox2.Visible = true;
            CheckBox3.Visible = true;
            actorList.Visible = true;
            producerName.Visible = true;
            studioName.Visible = true;
            actorSurname.Visible = true;
            actorFirstName.Visible = true;
        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DVDGV.PageIndex = e.NewPageIndex;
            this.ViewDVDs();
        }

        protected void DVDGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //hiding other fields before updating and deleting
            CheckBox1.Visible = false;
            CheckBox2.Visible = false;
            CheckBox3.Visible = false;
            actorList.Visible = false;
            producerName.Visible = false;
            studioName.Visible = false;
            actorSurname.Visible = false;
            actorFirstName.Visible = false;

            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM DVDTitle Where DVDNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "DVDTitle");
            DataTable dt = ds.Tables[0];

            if(dt.Rows.Count > 0)
            {
                dvdNumber.Text = dt.Rows[0]["DVDNumber"].ToString();
                dvdCategory.SelectedValue = dt.Rows[0]["CategoryNumber"].ToString();
                studio.SelectedValue = dt.Rows[0]["StudioNumber"].ToString();
                producer.SelectedValue = dt.Rows[0]["ProducerNumber"].ToString();
                dvdTitle.Text = dt.Rows[0]["DVDTitle"].ToString();
                standardCharge.Text = dt.Rows[0]["StandardCharge"].ToString();
                penaltyCharge.Text = dt.Rows[0]["PenaltyCharge"].ToString();
                datePicker.Text = dt.Rows[0]["DateReleased"].ToString();
            }
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if (dvdNumber.Text != "")
            {
                try
                {
                    DVDTitle dvd = new DVDTitle();
                    dvd.DeleteDVDTitle(dvdNumber.Text);
                    Result.Text = "DVD Deleted!!";
                    ViewDVDs();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a DVD From the Table";
            }
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            if (dvdNumber.Text != "")
            {
                try
                {
                    DVDTitle dvd = new DVDTitle();
                    dvd.UpdateDVDTitle(dvdNumber.Text, dvdCategory.Text, studio.Text, producer.Text, dvdTitle.Text, datePicker.Text.ToString(), standardCharge.Text, penaltyCharge.Text);
                    Result.Text = "DVD Updated!!";
                    ViewDVDs();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a DVD From the Table";
            }
        }

        protected void StudioChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                studioName.Enabled = true;
                studio.Enabled = false;
                studio.SelectedIndex = 0;
            }
            else
            {
                studio.Enabled = true;
                studioName.Enabled = false;
                studioName.Text = "";
            }
        }

        protected void ProducerChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked)
            {
                producerName.Enabled = true;
                producer.Enabled = false;
                producer.SelectedIndex = 0;
            }
            else
            {
                producer.Enabled = true;
                producerName.Enabled = false;
                producerName.Text = "";
            }
        }

        protected void ActorChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked)
            {
                actorFirstName.Enabled = true;
                actorSurname.Enabled = true;
                actorList.ClearSelection();
                actorList.Attributes.Add("Disabled", "");
            }
            else
            {
                actorFirstName.Enabled = false;
                actorSurname.Enabled = false;
                actorFirstName.Text = "";
                actorSurname.Text = "";
                actorList.Attributes.Remove("Disabled");
            }
        }
    }
}