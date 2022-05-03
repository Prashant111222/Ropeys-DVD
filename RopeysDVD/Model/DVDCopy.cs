using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class DVDCopy
    {
        readonly GlobalConnection gc = new GlobalConnection();


        public DataTable SelectDVDCopy()
        {
            string sql = "SELECT * FROM DVDCopy";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "DVDCopy");
            return ds.Tables[0];
        }

        public void AddDVDCopy(string dvdNumber, string datePurchased)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO DVDCopy (DVDNumber, DatePurchased) values (@dvdNumber, @datePurchased)", gc.cn);

            cmd.Parameters.AddWithValue("@dvdNumber", dvdNumber);
            cmd.Parameters.AddWithValue("@datePurchased", datePurchased);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void UpdateDVDCopy(string copyNumber, string dvdNumber, string datePurchased)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE  [DVDCopy] SET DVDNumber = @dvdNumber, DatePurchased = @datePurchased WHERE CopyNumber = @copyNumber", gc.cn);

            cmd.Parameters.AddWithValue("@copyNumber", copyNumber);
            cmd.Parameters.AddWithValue("@dvdNumber", dvdNumber);
            cmd.Parameters.AddWithValue("@datePurchased", datePurchased);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteDVDCopy(string copyNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [DVDCopy] WHERE CopyNumber = @copyNumber", gc.cn);

            cmd.Parameters.AddWithValue("@copyNumber", copyNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public DataTable GetDVDCopyTitle()
        {
            string sql = "SELECT d.CopyNumber, t.DVDTitle FROM DVDCopy d JOIN DVDTitle t on d.DVDNumber = t.DVDNumber";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataTable table = new DataTable();
            sda.Fill(table);
            return table;
        }

        public bool IsAgeResticted(string copyNumber)
        {
            //getting if the selected category is age restricted
            string sql = "SELECT DVDCategory.AgeRestricted FROM DVDCopy JOIN DVDTitle ON DVDCopy.DVDNumber = DVDTitle.DVDNumber JOIN DVDCategory ON DVDTitle.CategoryNumber = DVDCategory.CategoryNumber WHERE DVDCopy.CopyNumber = " + copyNumber;
            SqlCommand cmd = new SqlCommand(sql, gc.cn);
            return (bool)cmd.ExecuteScalar();
        }
    }
}