using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RopeysDVD
{
    public class Index
    {
        readonly GlobalConnection gc = new GlobalConnection();

        public DataTable GetActorDetails()
        {
            //getting the actor details who are also cast members
            string sql = "SELECT DISTINCT Actor.ActorSurname, Actor.ActorNumber FROM CastMember LEFT JOIN Actor ON CastMember.ActorNumber = Actor.ActorNumber";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetDVDTitleDetails()
        {
            //getting the detail of DVDs having many to many relation with table cast members
            string sql = "SELECT CastMember.DVDNumber, DVDTitle.DVDTitle, DVDTitle.DateReleased, DVDTitle.StandardCharge FROM DVDTitle LEFT JOIN CastMember ON DVDTitle.DVDNumber = CastMember.DVDNumber";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetDVDTitleDetails(int actorNumber)
        {
            //getting specific DVD details for cast members
            string sql = "SELECT CastMember.DVDNumber, DVDTitle.DVDTitle, DVDTitle.DateReleased, DVDTitle.StandardCharge FROM DVDTitle LEFT JOIN CastMember ON DVDTitle.DVDNumber = CastMember.DVDNumber WHERE CastMember.ActorNumber =" + actorNumber;

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetMovieDetails()
        {
            //getting the total movies and details that are in loan
            string sql = "SELECT CastMember.DVDNumber, DVDTitle.DVDTitle, COUNT(DVDCopy.CopyNumber) AS 'Total Movies' FROM DVDTitle LEFT JOIN CastMember ON DVDTitle.DVDNumber = CastMember.DVDNumber LEFT JOIN DVDCopy ON DVDTitle.DVDNumber = DVDCopy.DVDNumber LEFT JOIN Loan ON DVDCopy.CopyNumber = Loan.CopyNumber AND DVDCopy.CopyNumber NOT IN (SELECT Loan.CopyNumber FROM Loan WHERE Loan.DateReturned IS NULL) GROUP BY CastMember.DVDNumber, DVDTitle.DVDTitle";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable GetMovieDetails(int actorNumber)
        {
            //getting the specific movie with count number details which are in loan
            string sql = "SELECT CastMember.DVDNumber, DVDTitle.DVDTitle, COUNT(DVDCopy.CopyNumber) AS 'Total Movies' FROM DVDTitle LEFT JOIN CastMember ON DVDTitle.DVDNumber = CastMember.DVDNumber LEFT JOIN DVDCopy ON DVDTitle.DVDNumber = DVDCopy.DVDNumber LEFT JOIN Loan ON DVDCopy.CopyNumber = Loan.CopyNumber WHERE CastMember.ActorNumber = " + actorNumber + " AND DVDCopy.CopyNumber NOT IN (SELECT Loan.CopyNumber FROM Loan WHERE Loan.DateReturned IS NULL) GROUP BY CastMember.DVDNumber,DVDTitle.DVDTitle";

            SqlDataAdapter sda = new SqlDataAdapter(sql, gc.cn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            return ds.Tables[0];
        }
    }
}