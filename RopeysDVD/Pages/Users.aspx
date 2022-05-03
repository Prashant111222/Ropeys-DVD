<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="RopeysDVD.Pages.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="card col-md-12">
        <div class="card-body">
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <asp:TextBox ID="userNumber" type="hidden" class="form-control" runat="server"></asp:TextBox>
                    <label for="exampleInputEmail1" class="form-label">User Name</label>
                    <asp:TextBox ID="userName" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="id" ControlToValidate="userName" ValidationGroup="required" ErrorMessage="Please Enter User Name!" ForeColor="Red"/>
                </div>
            </div>
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <label for="exampleInputEmail1" class="form-label">User Type</label>
                    <asp:DropDownList ID="userType" CssClass="form-control" runat="server">
                        <asp:ListItem Value="Staff">Staff</asp:ListItem>
                        <asp:ListItem Value="Admin">Admin</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <label for="exampleInputEmail1" class="form-label">User Password</label>
                    <asp:TextBox ID="userPassword" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="userPassword" ValidationGroup="required" ErrorMessage="Please Enter User Password!" ForeColor="Red"/>
                </div>
            </div>
                <br />
            <div class="col d-flex justify-content-center">
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </div>
                <br />
                <br />
            <div class="col d-flex justify-content-center">
                <asp:Button ID="Button_Submit" ValidationGroup="required" CssClass="btn btn-primary" runat="server" Text="Add User" OnClick="Button_Submit_Click" />
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
            <asp:GridView ID="UserGV" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false" OnRowCommand="UserGV_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.N">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("UserNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ProducerName" Text='<%#Eval("UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Type">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="label" Text='<%#Eval("UserType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Password">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="label2" Text='<%#Eval("UserPassword") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary" CommandName="View" CommandArgument='<%#Bind("UserNumber")%>' CausesValidation="false">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
