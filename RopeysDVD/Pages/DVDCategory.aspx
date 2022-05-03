<%@ Page Title="DVD Category" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="DVDCategory.aspx.cs" Inherits="RopeysDVD.DVDCategory1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="card col-md-12">
        <div class="card-body">
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <asp:TextBox ID="dvdCategoryNumber" type="hidden" class="form-control" runat="server"></asp:TextBox>
                    <label for="exampleInputEmail1" class="form-label">Category Description</label>
                    <asp:TextBox ID="categoryDescription" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="id" ControlToValidate="categoryDescription" ValidationGroup="required" ErrorMessage="Please Enter Category Description!" ForeColor="Red"/>
                </div>
            </div>
            <br />
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <label for="exampleInputEmail1" class="form-label">Age Restricted [+18]</label>
                    <asp:DropDownList ID="ageRestriction" CssClass="form-control" runat="server">
                        <asp:ListItem Value="False">No</asp:ListItem>
                        <asp:ListItem Value="True">Yes</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="col d-flex justify-content-center">
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </div>
                <br />
                <br />
            <div class="col d-flex justify-content-center">
                <asp:Button ID="Button_Submit" ValidationGroup="required" CssClass="btn btn-primary" runat="server" Text="Add Category" OnClick="Button_Submit_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Update" ValidationGroup="required" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="Button_Update_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Delete" ValidationGroup="required" CssClass="btn btn-danger" runat="server" Text="Delete" OnClick="Button_Delete_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Clear" CssClass="btn btn-danger" runat="server" Text="Clear" OnClick="Button_Clear_Click" />
            </div>
        </div>
    </div>
    <br />
    <div class="card col-md-12">
        <div class="card-body">
            <asp:GridView ID="DVDCategoryGridView" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false" OnRowCommand="DVDCategoryGridView_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.N">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="CategoryNumber" Text='<%#Eval("CategoryNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="CategoryDescription" Text='<%#Eval("CategoryDescription") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Age Restriction">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="AgeRestricted" Text='<%#Eval("AgeRestricted") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary" CommandName="View" CommandArgument='<%#Bind("CategoryNumber")%>' CausesValidation="false">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
