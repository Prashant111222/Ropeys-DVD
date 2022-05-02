using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class Loan
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable SelectLoan()
        {
            string sql = "SELECT * FROM Loan";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Loan");
            return ds.Tables[0];
        }

        public void AddLoan(string loanTypeNumber, string copyNumber, string memberNumber, string dateOut, string dateDue)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO Loan (LoanTypeNumber, CopyNumber, MemberNumber, DateOut, DateDue) values (@loanTypeNumber, @copyNumber, @memberNumber, @dateOut, @dateDue)", gc.cn);

            cmd.Parameters.AddWithValue("@loanTypeNumber", loanTypeNumber);
            cmd.Parameters.AddWithValue("@copyNumber", copyNumber);
            cmd.Parameters.AddWithValue("@memberNumber", memberNumber);
            cmd.Parameters.AddWithValue("@dateOut", dateOut);
            cmd.Parameters.AddWithValue("@dateDue", dateDue);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void ReturnLoan(string loanNumber, string dateReturned)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE [Loan] SET DateReturned = @dateReturned WHERE LoanNumber = @loanNumber", gc.cn);

            cmd.Parameters.AddWithValue("@loanNumber", loanNumber);
            cmd.Parameters.AddWithValue("@dateReturned", dateReturned);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteLoan(string loanNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [Loan] WHERE LoanNumber = @loanNumber", gc.cn);

            cmd.Parameters.AddWithValue("@loanNumber", loanNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public int GetLoanDuration(string loanTypeNumber)
        {
            //getting loan duration from the loan type number
            string sql = "SELECT LoanDuration from LoanType WHERE LoanTypeNumber = " + loanTypeNumber;
            SqlCommand cmd = new SqlCommand(sql, gc.cn);
            int duration = (Int32)cmd.ExecuteScalar();
            return duration;
        }
    }
}