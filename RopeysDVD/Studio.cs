using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class Studio
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable SelectStudio()
        {
            string sql = "SELECT * FROM Studio";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Studio");
            return ds.Tables[0];
        }

        public void AddStudio(string studioName)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO Studio (StudioName) values (@studioName)", gc.cn);

            cmd.Parameters.AddWithValue("@studioName", studioName);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void UpdateStudio(string studioNumber, string studioName)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE [Studio] SET StudioName = @studioName WHERE StudioNumber = @studioNumber", gc.cn);

            cmd.Parameters.AddWithValue("@studioNumber", studioNumber);
            cmd.Parameters.AddWithValue("@studioName", studioName);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteStudio(string studioNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [Studio] WHERE StudioNumber = @studioNumber", gc.cn);

            cmd.Parameters.AddWithValue("@studioNumber", studioNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}