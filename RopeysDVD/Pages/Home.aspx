<%@ Page Title="Ropeys DVD | Home" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RopeysDVD.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="card col-sm-11" style="margin:1rem">
            <h5 class="card-header">
                <i class='bx bxs-movie-play text-primary' aria-hidden="true"></i>
                Search Movies By Actor's Last Name
            </h5>
            <div class="card-body">
                <div class="card-title">
                    <div class="col-md-3">
                        <asp:DropDownList ID="actorList" runat="server" AutoPostBack="True" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="card col-md-12">
                        <div class="card-body">
                            <asp:GridView ID="ActorGV" CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false">                                
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>