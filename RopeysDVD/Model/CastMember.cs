using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class CastMember
    {
        readonly GlobalConnection gc = new GlobalConnection();


        public DataTable SelectCastMember()
        {
            string sql = "SELECT * FROM CastMember";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "CastMember");
            return ds.Tables[0];
        }

        public void AddCastMember(string dvdNumber, string actorNumber)
        {            
            GlobalConnection globalConnection = new GlobalConnection();

            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO CastMember (DVDNumber, ActorNumber) values (@dvdNumber, @actorNumber)", globalConnection.cn);

            cmd.Parameters.AddWithValue("@dvdNumber", dvdNumber);
            cmd.Parameters.AddWithValue("@actorNumber", actorNumber);

            cmd.ExecuteNonQuery();
            globalConnection.cn.Close();
        }

        public void DeleteCastMemberActor(string actorNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [CastMember] WHERE ActorNumber = @actorNumber", gc.cn);

            cmd.Parameters.AddWithValue("@actorNumber", actorNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteCastMemberDVD(string dvdNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [CastMember] WHERE DVDNumber = @dvdNumber", gc.cn);

            cmd.Parameters.AddWithValue("@dvdNumber", dvdNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}