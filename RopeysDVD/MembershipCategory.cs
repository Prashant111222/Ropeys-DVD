using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class MembershipCategory
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable SelectMembershipCategory()
        {
            string sql = "SELECT * FROM MembershipCategory";
            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "MembershipCategory");
            return ds.Tables[0];
        }

        public void AddMembershipCategory(string membershipCategoryDescription, string membershipCategoryTotalLoans)
        {
            //inserting into the table created from SSM
            SqlCommand cmd = new SqlCommand("INSERT INTO MembershipCategory (MembershipCategoryDescription, MembershipCategoryTotalLoans) values (@membershipCategoryDescription, @membershipCategoryTotalLoans)", gc.cn);

            cmd.Parameters.AddWithValue("@membershipCategoryDescription", membershipCategoryDescription);
            cmd.Parameters.AddWithValue("@membershipCategoryTotalLoans", membershipCategoryTotalLoans);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void UpdateMembershipCategory(string membershipCategoryNumber, string membershipCategoryDescription, string membershipCategoryTotalLoans)
        {
            //updating into the table row
            SqlCommand cmd = new SqlCommand("UPDATE [MembershipCategory] SET MembershipCategoryDescription = @membershipCategoryDescription, MembershipCategoryTotalLoans = @membershipCategoryTotalLoans WHERE MembershipCategoryNumber = @membershipCategoryNumber", gc.cn);

            cmd.Parameters.AddWithValue("@membershipCategoryNumber", membershipCategoryNumber);
            cmd.Parameters.AddWithValue("@membershipCategoryDescription", membershipCategoryDescription);
            cmd.Parameters.AddWithValue("@membershipCategoryTotalLoans", membershipCategoryTotalLoans);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }

        public void DeleteMembershipCategory(string membershipCategoryNumber)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [MembershipCategory] WHERE MembershipCategoryNumber = @membershipCategoryNumber", gc.cn);

            cmd.Parameters.AddWithValue("@membershipCategoryNumber", membershipCategoryNumber);

            cmd.ExecuteNonQuery();
            gc.cn.Close();
        }
    }
}