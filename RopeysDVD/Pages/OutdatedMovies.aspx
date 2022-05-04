<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="OutdatedMovies.aspx.cs" Inherits="RopeysDVD.Pages.OutdatedMovies" %>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">    
    <div class="card col-md-12">
        <div class="card-body">
            <div class="col d-flex justify-content-center">
                <h3>Remove Outdated Movies</h3>
            </div>
            <br />
            <div class="card col-sm-11" style="margin:1rem">
                <h5 class="card-header">
                    <i class='bx bxs-movie-play text-primary' aria-hidden="true"></i>
                    List of Outdated Movies
                </h5>
                <div class="card-body">
                    <div class="card-title">
                        <div class="card col-md-12">
                            <div class="card-body">
                                <asp:GridView ID="OutdatedMovieGV" CssClass="table table-dark table-sm table-hover" AutoGenerateColumns="false" OnRowCommand="OutdatedMovieGV_RowCommand" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="CopyNumber" HeaderText="Copy Number" />
                                        <asp:BoundField DataField="DVDTitle" HeaderText="DVD Title" />
                                        <asp:BoundField DataField="DatePurchased" HeaderText="Date Purchased" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="DeleteDVD" CssClass="btn btn-danger" runat="server" Text="Delete" CommandName="DeleteDVD" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col d-flex justify-content-center">
                    <asp:Label ID="Result" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
