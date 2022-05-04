<%@ Page Title="Ropeys DVD | Home" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RopeysDVD.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="col d-flex justify-content-center">
        <h3 style="font-weight: bold">Ropey's DVD | Home</h3>
    </div>
    <div class="col d-flex justify-content-center">
        <asp:Label ID="Result" runat="server" Text=""></asp:Label>
    </div>
    <div class="card col-sm-11" style="margin:1rem">
        <h5 class="card-header">
            <i class='bx bxs-movie-play text-primary' aria-hidden="true"></i>
            Search Movies By Actor
        </h5>
        <div class="card-body">
            <div class="card-title">
                <div class="col-md-3">
                    <asp:DropDownList ID="actorList" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ActorChanged">
                    </asp:DropDownList>
                </div>
                <br />
                <div class="card col-md-12">
                    <div class="card-body">
                        <asp:GridView ID="MovieGV" CssClass="table table-dark table-sm table-hover" runat="server">                                
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
            Search Number of Movies By Actor
        </h5>
        <div class="card-body">
            <div class="card-title">
                <div class="col-md-3">
                    <asp:DropDownList ID="actorList1" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ActorChanged1">
                    </asp:DropDownList>
                </div>
                <br />
                <div class="card col-md-12">
                    <div class="card-body">
                        <asp:GridView ID="MovieGV1" CssClass="table table-dark table-sm table-hover" runat="server">                                
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>