using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class Member
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable SelectMember()
        {
            string sql = "SELECT * FROM Member";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Member");
            return ds.Tables[0];
        }

        public void AddMember(string membershipCategoryNumber, string memberLastName, string memberFirstName, string memberAddress, string memberDateOfBirth)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO Member (MembershipCategoryNumber, MemberLastName, MemberFirstName, MemberAddress, MemberDateOfBirth) values (@membershipCategoryNumber, @memberLastName, @memberFirstName, @memberAddress, @memberDateOfBirth)", gc.cn);

            cmd.Parameters.AddWithValue("@membershipCategoryNumber", membershipCategoryNumber);
            cmd.Parameters.AddWithValue("@memberLastName", memberLastName);
            cmd.Parameters.AddWithValue("@memberFirstName", memberFirstName);
            cmd.Parameters.AddWithValue("@memberAddress", memberAddress);
            cmd.Parameters.AddWithValue("@memberDateOfBirth", memberDateOfBirth);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void UpdateMember(string memberNumber, string membershipCategoryNumber, string memberLastName, string memberFirstName, string memberAddress, string memberDateOfBirth)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE [Member] SET MembershipCategoryNumber = @membershipCategoryNumber, MemberLastName = @memberLastName, MemberFirstName = @memberFirstName, MemberAddress = @memberAddress, MemberDateOfBirth = @memberDateOfBirth WHERE MemberNumber = @memberNumber", gc.cn);

            cmd.Parameters.AddWithValue("@memberNumber", memberNumber);
            cmd.Parameters.AddWithValue("@membershipCategoryNumber", membershipCategoryNumber);
            cmd.Parameters.AddWithValue("@memberLastName", memberLastName);
            cmd.Parameters.AddWithValue("@memberFirstName", memberFirstName);
            cmd.Parameters.AddWithValue("@memberAddress", memberAddress);
            cmd.Parameters.AddWithValue("@memberDateOfBirth", memberDateOfBirth);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteMember(string memberNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [Member] WHERE MemberNumber = @memberNumber", gc.cn);

            cmd.Parameters.AddWithValue("@memberNumber", memberNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public int CheckMemberAge(string memberNumber)
        {
            //getting the age of the user
            string sql = "SELECT DATEDIFF(year, MemberDateOfBirth, CURRENT_TIMESTAMP) from Member WHERE MemberNumber = " + memberNumber;
            SqlCommand cmd = new SqlCommand(sql, gc.cn);
            int age = (Int32)cmd.ExecuteScalar();
            return age;
        }
    }
}