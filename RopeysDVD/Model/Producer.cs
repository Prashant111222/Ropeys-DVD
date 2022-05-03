using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class Producer
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable SelectProducer()
        {
            string sql = "SELECT * FROM Producer";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Producer");
            return ds.Tables[0];
        }

        public void AddProducer(string producerName)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO Producer (ProducerName) values (@producerName)", gc.cn);

            cmd.Parameters.AddWithValue("@producerName", producerName);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void UpdateProducer(string producerNumber, string producerName)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE [Producer] SET ProducerName = @producerName WHERE ProducerNumber = @producerNumber", gc.cn);

            cmd.Parameters.AddWithValue("@producerNumber", producerNumber);
            cmd.Parameters.AddWithValue("@producerName", producerName);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteProducer(string producerNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [Producer] WHERE ProducerNumber = @producerNumber", gc.cn);

            cmd.Parameters.AddWithValue("@producerNumber", producerNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}