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
                }
            }
            catch (Exception ex)
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

        protected bool IsEmpty()
        {
            if (dvdCategory.SelectedIndex == 0 || producer.SelectedIndex == 0 || studio.SelectedIndex == 0)
            {
                return true;
            }
            return false;
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            if (!IsEmpty())
            {

            }
            else
            {
                Result.Text = "Please Select Items From the Dropdown Lists";
            }
            try
            {
                DVDTitle dvd = new DVDTitle();
                dvd.AddDVDTitle(dvdCategory.SelectedValue, studio.SelectedValue, producer.SelectedValue, dvdTitle.Text, datePicker.Text.ToString(), standardCharge.Text, penaltyCharge.Text);
                Result.Text = "DVD Inserted !!";
                ViewDVDs();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
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
            datePicker.Text = System.DateTime.Today.ToString();
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
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM DVDTitle Where DVDNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "DVDTitle");
            DataTable dt = ds.Tables[0];

            dvdNumber.Text = dt.Rows[0]["DVDNumber"].ToString();
            dvdCategory.SelectedValue = dt.Rows[0]["CategoryNumber"].ToString();
            studio.SelectedValue = dt.Rows[0]["StudioNumber"].ToString();
            producer.SelectedValue = dt.Rows[0]["ProducerNumber"].ToString();
            dvdTitle.Text = dt.Rows[0]["DVDTitle"].ToString();
            standardCharge.Text = dt.Rows[0]["StandardCharge"].ToString();
            penaltyCharge.Text = dt.Rows[0]["PenaltyCharge"].ToString();
            datePicker.Text = dt.Rows[0]["DateReleased"].ToString();
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!IsEmpty() && dvdNumber.Text != "")
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
            if (!IsEmpty() && dvdNumber.Text != "")
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
    }
}