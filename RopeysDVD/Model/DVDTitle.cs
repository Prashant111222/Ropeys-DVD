using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class DVDTitle
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable SelectDVDTitle()
        {
            string sql = "SELECT * FROM DVDTitle";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "DVDTitle");
            return ds.Tables[0];
        }

        public void AddDVDTitle(string categoryNumber, string studioNumber, string producerNumber, string dvdTitle, string dateReleased, string standardCharge, string penaltyCharge)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO DVDTitle (CategoryNumber, StudioNumber, ProducerNumber, DVDTitle, DateReleased, StandardCharge, PenaltyCharge) values (@categoryNumber, @studioNumber, @producerNumber, @dvdTitle, @dateReleased, @standardCharge, @penaltyCharge)", gc.cn);

            cmd.Parameters.AddWithValue("@categoryNumber", categoryNumber);
            cmd.Parameters.AddWithValue("@studioNumber", studioNumber);
            cmd.Parameters.AddWithValue("@producerNumber", producerNumber);
            cmd.Parameters.AddWithValue("@dvdTitle", dvdTitle);
            cmd.Parameters.AddWithValue("@dateReleased", dateReleased);
            cmd.Parameters.AddWithValue("@standardCharge", standardCharge);
            cmd.Parameters.AddWithValue("@penaltyCharge", penaltyCharge);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void UpdateDVDTitle(string dvdNumber, string categoryNumber, string studioNumber, string producerNumber, string dvdTitle, string dateReleased, string standardCharge, string penaltyCharge)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE  [DVDTitle] SET CategoryNumber = @categoryNumber, StudioNumber = @studioNumber, ProducerNumber = @producerNumber, DVDTitle = @dvdTitle, DateReleased = @dateReleased, StandardCharge = @standardCharge, PenaltyCharge = @penaltyCharge  WHERE DVDNumber = @dvdNumber", gc.cn);

            cmd.Parameters.AddWithValue("@dvdNumber", dvdNumber);
            cmd.Parameters.AddWithValue("@categoryNumber", categoryNumber);
            cmd.Parameters.AddWithValue("@studioNumber", studioNumber);
            cmd.Parameters.AddWithValue("@producerNumber", producerNumber);
            cmd.Parameters.AddWithValue("@dvdTitle", dvdTitle);
            cmd.Parameters.AddWithValue("@dateReleased", dateReleased);
            cmd.Parameters.AddWithValue("@standardCharge", standardCharge);
            cmd.Parameters.AddWithValue("@penaltyCharge", penaltyCharge);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteDVDTitle(string dvdNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [DVDTitle] WHERE DVDNumber = @dvdNumber", gc.cn);

            cmd.Parameters.AddWithValue("@dvdNumber", dvdNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public int StandardCharge(string copyNumber)
        {
            //getting the price of the DVD
            string sql = "SELECT DVDTitle.StandardCharge FROM DVDCopy JOIN DVDTitle ON DVDCopy.DVDNumber = DVDTitle.DVDNumber WHERE DVDCopy.CopyNumber = " + copyNumber;
            SqlCommand cmd = new SqlCommand(sql, gc.cn);
            return (Int32)cmd.ExecuteScalar();
        }

        public int PenaltyCharge(string copyNumber)
        {
            //getting the price of the DVD
            string sql = "SELECT DVDTitle.PenaltyCharge FROM DVDCopy JOIN DVDTitle ON DVDCopy.DVDNumber = DVDTitle.DVDNumber WHERE DVDCopy.CopyNumber = " + copyNumber;
            SqlCommand cmd = new SqlCommand(sql, gc.cn);
            return (Int32)cmd.ExecuteScalar();
        }

        public int LastDVDTitle()
        {
            //getting lastly added DVD number
            string sql = "SELECT TOP 1 DVDNumber FROM DVDTitle ORDER BY DVDNumber DESC";
            gc.cn.Open();
            SqlCommand cmd = new SqlCommand(sql, gc.cn);
            return (Int32)cmd.ExecuteScalar();
        }
    }
}