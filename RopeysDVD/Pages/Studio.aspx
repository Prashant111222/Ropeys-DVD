﻿<%@ Page Title="Ropeys DVD | Studio" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="Studio.aspx.cs" Inherits="RopeysDVD.Studio1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="col d-flex justify-content-center">
        <h3 style="font-weight: bold">Studio Details</h3>
    </div>
    <div class="card col-md-12">
        <div class="card-body">
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <asp:TextBox ID="studioNumber" type="hidden" class="form-control" runat="server"></asp:TextBox>
                    <label for="exampleInputEmail1" class="form-label">Studio Name</label>
                    <asp:TextBox ID="studioName" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="id" ControlToValidate="studioName"
                        ValidationGroup="required" ErrorMessage="Please Provide the Studio Name!"
                        ForeColor="Red" />
                </div>
            </div>
            <br />
            <div class="col d-flex justify-content-center">
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <br />
            <div class="col d-flex justify-content-center">
                <asp:Button ID="Button_Submit" ValidationGroup="required" CssClass="btn btn-primary" runat="server" Text="Add Studio"
                    OnClick="Button_Submit_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Update" ValidationGroup="required" CssClass="btn btn-primary" runat="server" Text="Update"
                    OnClick="Button_Update_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Delete" ValidationGroup="required" CssClass="btn btn-danger" runat="server" Text="Delete"
                    OnClick="Button_Delete_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Clear" CssClass="btn btn-danger" runat="server" Text="Clear"
                    OnClick="Button_Clear_Click" />
            </div>
        </div>
    </div>
    <br />
    <div class="card col-md-12">
        <div class="card-body">
            <asp:GridView ID="StudioGV" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging"
                CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false"
                OnRowCommand="StudioGV_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.N">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("StudioNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Studio Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="StudioName" Text='<%#Eval("StudioName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary"
                                CommandName="View" CommandArgument='<%#Bind("StudioNumber")%>'
                                CausesValidation="false">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
