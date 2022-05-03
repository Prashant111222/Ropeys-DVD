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
    public partial class Producer1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                        ViewProducers();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('exception)</script>");
                }
        }

        protected void ViewProducers()
        {
            try
            {
                Producer producer = new Producer();
                ProducerGV.DataSource = producer.SelectProducer();
                ProducerGV.DataBind();
                producer = null;
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProducerGV.PageIndex = e.NewPageIndex;
            this.ViewProducers();
        }

        protected void Clear_Fields()
        {
            producerName.Text = "";
            producerNumber.Text = "";
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Producer producer = new Producer();
                producer.AddProducer(producerName.Text);
                Result.Text = "Producer Inserted !!";
                ViewProducers();
                Clear_Fields();
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            if (producerNumber.Text != "")
            {
                try
                {
                    Producer producer = new Producer();
                    producer.UpdateProducer(producerNumber.Text, producerName.Text);
                    Result.Text = "Producer Updated!!";
                    ViewProducers();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a Producer From the Table";
            }
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if (producerNumber.Text != "")
            {
                try
                {
                    Producer producer = new Producer();
                    producer.DeleteProducer(producerNumber.Text);
                    Result.Text = "Producer Deleted!!";
                    ViewProducers();
                    Clear_Fields();
                }
                catch (Exception ex)
                {
                    Result.Text = ex.Message;
                }
            }
            else
            {
                Result.Text = "Please Select a Producer From the Table";
            }

        }

        protected void Button_Clear_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        protected void ProducerGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GlobalConnection gc = new GlobalConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = gc.cn;
            string index = Convert.ToString(e.CommandArgument);

            string strData = "SELECT * FROM Producer Where ProducerNumber='" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(strData, gc.cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Producer");
            DataTable dt = ds.Tables[0];

            producerNumber.Text = dt.Rows[0]["ProducerNumber"].ToString();
            producerName.Text = dt.Rows[0]["ProducerName"].ToString();
        }
    }
}