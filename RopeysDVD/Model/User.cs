using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class User
    {
        readonly GlobalConnection gc = new GlobalConnection();


        public DataTable SelectUser()
        {
            string sql = "SELECT * FROM [User]";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "User");
            return ds.Tables[0];
        }

        public void AddUser(string name, string userType, string userPassword)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO [User] (UserName, UserType, UserPassword) values (@name, @userType, @userPassword)", gc.cn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@userType", userType);
            cmd.Parameters.AddWithValue("@userPassword", userPassword);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void UpdateUser(string userNumber, string name, string userPassword)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE  [User] SET UserName = @name, UserPassword = @userPassword WHERE UserNumber = @userNumber", gc.cn);

            cmd.Parameters.AddWithValue("@userNumber", userNumber);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@userPassword", userPassword);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteUser(string userNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [User] WHERE UserNumber = @userNumber", gc.cn);

            cmd.Parameters.AddWithValue("@userNumber", userNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void ChangePassword(string userNumber, string userPassword)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE [User] SET UserPassword = @userPassword WHERE UserNumber = @userNumber", gc.cn);

            cmd.Parameters.AddWithValue("@userNumber", userNumber);
            cmd.Parameters.AddWithValue("@userPassword", userPassword);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}