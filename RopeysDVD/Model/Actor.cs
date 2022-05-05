using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class Actor
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable SelectActor()
        {
            string sql = "SELECT * FROM Actor";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Actor");
            return ds.Tables[0];
        }

        public void AddActor(string actorSurname, string actorFirstName)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO Actor (ActorSurname, ActorFirstName) values (@actorSurname, @actorFirstName)", gc.cn);

            cmd.Parameters.AddWithValue("@actorSurname", actorSurname);
            cmd.Parameters.AddWithValue("@actorFirstName", actorFirstName);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void UpdateActor(string actorNumber, string actorSurname, string actorFirstName)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE  [Actor] SET ActorSurname = @actorSurname, ActorFirstName = @actorFirstName WHERE ActorNumber = @actorNumber", gc.cn);

            cmd.Parameters.AddWithValue("@actorNumber", actorNumber);
            cmd.Parameters.AddWithValue("@actorSurname", actorSurname);
            cmd.Parameters.AddWithValue("@actorFirstName", actorFirstName);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteActor(string actorNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [Actor] WHERE ActorNumber = @actorNumber", gc.cn);

            cmd.Parameters.AddWithValue("@actorNumber", actorNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public int LastActor()
        {
            //getting lastly added actor number
            string sql = "SELECT TOP 1 ActorNumber FROM Actor ORDER BY ActorNumber DESC";
            gc.cn.Open();
            SqlCommand cmd = new SqlCommand(sql, gc.cn);
            return (Int32)cmd.ExecuteScalar();
        }
    }
}