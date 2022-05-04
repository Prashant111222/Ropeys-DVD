<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="AssistantDashboard.aspx.cs" Inherits="RopeysDVD.AssistantDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="col d-flex justify-content-center">
        <h1 style="font-weight: bold">Dashboard</h1>
    </div>
    <div class="col d-flex justify-content-center">
        <asp:Label ID="Result" runat="server" Text=""></asp:Label>
    </div>
    <div class="card col-sm-11" style="margin:1rem">
        <h5 class="card-header">
            <i class='bx bxs-movie-play text-primary' aria-hidden="true"></i>
            Search DVDs Loaned to Member in Last 31 Days
        </h5>
        <div class="card-body">
            <div class="card-title">
                <div class="col-md-3">
                    <asp:DropDownList ID="memberList" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="MemberChanged">
                    </asp:DropDownList>
                </div>
                <br />
                <div class="card col-md-12">
                    <div class="card-body">
                        <asp:GridView ID="MovieDetailGV" CssClass="table table-dark table-sm table-hover" runat="server">                                
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="card col-sm-11" style="margin:1rem">
        <h5 class="card-header">
            <i class='bx bxs-movie-play text-primary' aria-hidden="true"></i>
            Movies Details Ordered by Released Date and Cast Members
        </h5>
        <div class="card-body">
            <div class="card-title">
                <div class="card col-md-12">
                    <div class="card-body">
                        <asp:GridView ID="MovieDetailGV1" CssClass="table table-dark table-sm table-hover" runat="server">                                
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="card col-sm-11" style="margin:1rem">
        <h5 class="card-header">
            <i class='bx bxs-movie-play text-primary' aria-hidden="true"></i>
            Loan Details of the DVD Copies
        </h5>
        <div class="card-body">
            <div class="card-title">
                <div class="col-md-3">
                    <asp:DropDownList ID="copyNumberList" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="CopyNumberChanged">
                    </asp:DropDownList>
                </div>
                <br />
                <div class="card col-md-12">
                    <div class="card-body">
                        <asp:GridView ID="CopyDetailsGV" CssClass="table table-dark table-sm table-hover" runat="server">                                
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="card col-sm-11" style="margin:1rem">
        <h5 class="card-header">
            <i class='bx bxs-movie-play text-primary' aria-hidden="true"></i>
            Alphabetical List of Members with Current Loan Number
        </h5>
        <div class="card-body">
            <div class="card-title">
                <div class="card col-md-12">
                    <div class="card-body">
                        <asp:GridView ID="CurrentLoanGV" CssClass="table table-dark table-sm table-hover" runat="server">                                
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="card col-sm-11" style="margin:1rem">
        <h5 class="card-header">
            <i class='bx bxs-movie-play text-primary' aria-hidden="true"></i>
            Details of DVD Currently on Loan
        </h5>
        <div class="card-body">
            <div class="card-title">
                <div class="card col-md-12">
                    <div class="card-body">
                        <asp:GridView ID="BriefLoanGV" CssClass="table table-dark table-sm table-hover" runat="server">                                
                        </asp:GridView>
                    </div>
                </div>
                <br />
                <div class="card col-md-11" style="margin:1rem">
                    <h5 class="card-header">
                        Detailed Information
                    </h5>
                    <div class="card-body">
                        <div class="card-title">
                            <div class="card col-md-12">
                                <div class="card-body">
                                    <asp:GridView ID="DetailedLoanGV" CssClass="table table-dark table-sm table-hover" runat="server">                                
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="card col-sm-11" style="margin:1rem">
        <h5 class="card-header">
            <i class='bx bxs-movie-play text-primary' aria-hidden="true"></i>
            Members with no Loan Record in Last 30 Days
        </h5>
        <div class="card-body">
            <div class="card-title">
                <div class="card col-md-12">
                    <div class="card-body">
                        <asp:GridView ID="MemberNoLoanGV" CssClass="table table-dark table-sm table-hover" runat="server">                                
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="card col-sm-11" style="margin:1rem">
        <h5 class="card-header">
            <i class='bx bxs-movie-play text-primary' aria-hidden="true"></i>
            DVD Copy with no Loan Record in Last 30 Days
        </h5>
        <div class="card-body">
            <div class="card-title">
                <div class="card col-md-12">
                    <div class="card-body">
                        <asp:GridView ID="CopyNoLoanGV" CssClass="table table-dark table-sm table-hover" runat="server">                                
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
