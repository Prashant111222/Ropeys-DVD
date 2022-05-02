using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class DVDCategory
    {
        readonly GlobalConnection gc = new GlobalConnection();


        public DataTable SelectDVDCategory()
        {
            string sql = "SELECT * FROM DVDCategory";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "DVDCategory");
            return ds.Tables[0];
        }

        public void AddDVDCategory(string categoryDescription, string ageRestricted)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO DVDCategory (CategoryDescription, AgeRestricted) values (@categoryDescription, @ageRestricted)", gc.cn);

            cmd.Parameters.AddWithValue("@categoryDescription", categoryDescription);
            cmd.Parameters.AddWithValue("@ageRestricted", ageRestricted);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void UpdateDVDCategory(string categoryNumber, string categoryDescription, string ageRestricted)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE  [DVDCategory] SET CategoryDescription = @categoryDescription, AgeRestricted = @ageRestricted WHERE CategoryNumber = @categoryNumber", gc.cn);

            cmd.Parameters.AddWithValue("@categoryNumber", categoryNumber);
            cmd.Parameters.AddWithValue("@categoryDescription", categoryDescription);
            cmd.Parameters.AddWithValue("@ageRestricted", ageRestricted);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteDVDCategory(string categoryNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [DVDCategory] WHERE CategoryNumber = @categoryNumber", gc.cn);

            cmd.Parameters.AddWithValue("@categoryNumber", categoryNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}