using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class OutdatedMovie
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable GetOutdatedMovies()
        {
            //getting the DVD copies details that are older than 365 days and currently not in loan
            string sql = "SELECT DISTINCT DVDCopy.CopyNumber, DVDTitle.DVDTitle, DVDCopy.DatePurchased FROM DVDCopy LEFT JOIN DVDTitle ON DVDCopy.DVDNumber = DVDTitle.DVDNumber WHERE DVDCopy.CopyNumber NOT IN (SELECT CopyNumber FROM Loan WHERE DateReturned IS NULL) AND YEAR(GETDATE()) -YEAR(DatePurchased) > 0";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public void RemoveOutdatedMovies(int copyNumber)
        {
            //deleting the movies older than 365 days
            SqlCommand cmd = new SqlCommand("DELETE FROM [DVDCopy] WHERE CopyNumber = @copyNumber", gc.cn);

            cmd.Parameters.AddWithValue("@copyNumber", copyNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}