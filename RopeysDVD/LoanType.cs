using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class LoanType
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable SelectLoanType()
        {
            string sql = "SELECT * FROM LoanType";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "LoanType");
            return ds.Tables[0];
        }

        public void AddLoanType(string loanType, string loanDuration)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO LoanType (LoanType, LoanDuration) values (@loanType, @loanDuration)", gc.cn);

            cmd.Parameters.AddWithValue("@loanType", loanType);
            cmd.Parameters.AddWithValue("@loanDuration", loanDuration);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void UpdateLoanType(string loanTypeNumber, string loanType, string loanDuration)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE [LoanType] SET LoanType = @loanType, LoanDuration = @loanDuration WHERE LoanTypeNumber = @loanTypeNumber", gc.cn);

            cmd.Parameters.AddWithValue("@loanTypeNumber", loanTypeNumber);
            cmd.Parameters.AddWithValue("@loanType", loanType);
            cmd.Parameters.AddWithValue("@loanDuration", loanDuration);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteLoanType(string loanTypeNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [LoanType] WHERE LoanTypeNumber = @loanTypeNumber", gc.cn);

            cmd.Parameters.AddWithValue("@loanTypeNumber", loanTypeNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}