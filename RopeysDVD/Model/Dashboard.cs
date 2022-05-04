using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace RopeysDVD
{
    public class Dashboard
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable GetMemberDetails()
        {
            //member who have been loaned DVDs in last 31 days
            string sql = "SELECT DISTINCT Member.MemberLastName, Loan.MemberNumber FROM Loan LEFT JOIN Member ON Loan.MemberNumber = Member.MemberNumber WHERE DateOut >= CURRENT_TIMESTAMP-31";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetOldMovies()
        {
            //movies that have been loaned in last 31 days
            string sql = "SELECT DVDTitle.DVDNumber, DVDTitle.DVDTitle, DVDCopy.CopyNumber FROM DVDTitle LEFT JOIN DVDCopy ON DVDTitle.DVDNumber = DVDCopy.DVDNumber LEFT JOIN Loan ON DVDCOPY.CopyNumber = Loan.CopyNumber LEFT JOIN Member ON Loan.MemberNumber = Member.MemberNumber WHERE DateOut >= CURRENT_TIMESTAMP-31";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetOldMovies(int memberNumber)
        {
            //movies that have been loaned in last 31 days to specific member
            string sql = "SELECT DVDTitle.DVDNumber, DVDTitle.DVDTitle, DVDCopy.CopyNumber FROM DVDTitle LEFT JOIN DVDCopy ON DVDTitle.DVDNumber = DVDCopy.DVDNumber LEFT JOIN Loan ON DVDCOPY.CopyNumber = Loan.CopyNumber LEFT JOIN Member ON Loan.MemberNumber = Member.MemberNumber WHERE DateOut >= CURRENT_TIMESTAMP-31 AND Member.MemberNumber =" + memberNumber;

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetMovieDetails()
        {
            //movie details along with the details of the Cast Members in alphabetical order
            string sql = "SELECT Producer.ProducerName, Studio.StudioName,Actor.ActorFirstName, DVDTitle.DVDTitle, DVDTitle.DateReleased, Actor.ActorSurname FROM Producer JOIN DVDTitle ON Producer.ProducerNumber = DVDTitle.ProducerNumber JOIN Studio On DVDTitle.StudioNumber = Studio.StudioNumber JOIN CastMember ON DVDTitle.DVDNumber = CastMember.DVDNumber JOIN Actor ON CastMember.ActorNumber = Actor.ActorNumber ORDER BY DVDTitle.DateReleased, Actor.ActorSurname";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }


        public DataTable GetDVDCopyNumber()
        {
            //getting the copy number for every copies
            string sql = "SELECT DISTINCT DVDCopy.CopyNumber FROM Member JOIN Loan ON Member.MemberNumber = Loan.MemberNumber LEFT JOIN DVDCopy ON Loan.CopyNumber = DVDCopy.CopyNumber;";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetDVDCopyDetails()
        {
            //getting the details of DVD with respective to their copies
            string sql = "SELECT Loan.MemberNumber, Member.MemberFirstName, Member.MemberLastName, DVDTitle.DVDTitle, Loan.DateOut, Loan.DateDue, Loan.DateReturned FROM Loan LEFT JOIN Member ON Loan.MemberNumber = Member.MemberNumber LEFT JOIN DVDCopy ON Loan.CopyNumber = DVDCopy.CopyNumber LEFT JOIN DVDTitle ON DVDCopy.DVDNumber = DVDTitle.DVDNumber WHERE DVDCopy.CopyNumber= Loan.CopyNumber AND Loan.DateOut IN(SELECT MAX(Dateout) FROM Loan WHERE CopyNumber=Loan.CopyNumber)";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetDVDCopyDetails(int copyNumber)
        {
            //getting the details of DVD with respective to specific DVD copy
            string sql = "SELECT TOP 1 Loan.MemberNumber, Member.MemberFirstName, Member.MemberLastName, DVDTitle.DVDTitle, Loan.DateOut, Loan.DateDue, Loan.DateReturned FROM Loan LEFT JOIN Member ON Loan.MemberNumber = Member.MemberNumber LEFT JOIN DVDCopy ON Loan.CopyNumber = DVDCopy.CopyNumber LEFT JOIN DVDTitle ON DVDCopy.DVDNumber = DVDTitle.DVDNumber WHERE DVDCopy.CopyNumber=" + copyNumber + "AND Loan.DateOut IN(SELECT MAX(Dateout) FROM Loan WHERE CopyNumber=" + copyNumber + ")";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetMemberLoanDetails()
        {
            //Getting member details and their loan details for displaying in the table
            string sql = "SELECT Member.MemberNumber AS 'MemberNo.', CONCAT(Member.MemberFirstName, ' ', Member.MemberLastName) AS 'Name', Member.MemberAddress AS 'Address', Member.MemberDateOfBirth as 'DOB', MembershipCategory.MembershipCategoryDescription AS 'Membership Type', MembershipCategory.MembershipCategoryTotalLoans AS 'Allowed Loans', COUNT(Loan.MemberNumber) AS CurrentlyLoaned, CASE WHEN COUNT(Loan.MemberNumber) > MembershipCategory.MembershipCategoryTotalLoans THEN 'Too Many DVDs.' WHEN COUNT(Loan.MemberNumber) = 0 THEN 'No Pending Loans' ELSE 'Healthy Loan Amount.'  END AS Remarks FROM Member LEFT JOIN MembershipCategory ON Member.MembershipCategoryNumber = MembershipCategory.MembershipCategoryNumber LEFT JOIN Loan ON Member.MemberNumber = Loan.MemberNumber GROUP BY Member.MemberNumber, Member.MemberFirstName, MemberLastName, Member.MemberAddress, Member.MemberDateOfBirth, MembershipCategory.MembershipCategoryDescription, MembershipCategory.MembershipCategoryTotalLoans, Loan.MemberNumber";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetLoanedMovieDetails()
        {
            //getting the total number of DVDs being loaned in specific day
            string sql = "SELECT Loan.DateOut, COUNT(Loan.DateOut) AS 'Total Loans' FROM DVDCopy JOIN Loan ON DVDCopy.CopyNumber = Loan.CopyNumber JOIN DVDTitle ON DVDCopy.DVDNumber = DVDTitle.DVDNumber JOIN Member ON Loan.MemberNumber = Member.MemberNumber WHERE Loan.DateReturned IS NULL GROUP BY Loan.DateOut ORDER BY Loan.DateOut";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetMovieOnLoan()
        {
            //Overall details of loaned DVDs 
            string sql = "SELECT Loan.DateOut, DVDTitle.DVDTitle,DVDCopy.CopyNumber, Member.MemberFirstName FROM DVDCopy JOIN Loan ON DVDCopy.CopyNumber = Loan.CopyNumber JOIN DVDTitle ON DVDCopy.DVDNumber = DVDTitle.DVDNumber JOIN Member ON Loan.MemberNumber = Member.MemberNumber WHERE Loan.DateReturned IS NULL ORDER BY Loan.DateOut, DVDTitle.DVDTitle";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        //12
        public DataTable GetNoBorrowedMovies()
        {
            //members who have not borrowed books since last 31 days and their previous loaned details
            string sql = "SELECT DVDTitle.DVDtitle FROM DVDTitle JOIN DVDCopy ON DVDTitle.DVDNumber = DVDCopy.DVDNumber JOIN Loan ON Loan.CopyNumber =  DVDCopy.CopyNumber WHERE Loan.DateOut < CURRENT_TIMESTAMP - 31; ";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetNoLoanedMovies()
        {
            //displaying the list of DVDs that have not been loaned in last 31 days
            string sql = "SELECT DVDTitle.DVDtitle FROM DVDTitle JOIN DVDCopy ON DVDTitle.DVDNumber = DVDCopy.DVDNumber JOIN Loan ON Loan.CopyNumber =  DVDCopy.CopyNumber WHERE Loan.DateOut < CURRENT_TIMESTAMP - 31; ";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }
    }
}