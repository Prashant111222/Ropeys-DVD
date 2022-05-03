<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RopeysDVD.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div>
        <div class="col d-flex justify-content-center">
        <h1 class="w-100 mt-3 text-xxl-center"><b>User Login</b><br/></h1>
    </div>
    <br />
    <div class="col d-flex justify-content-center">
        <div class="form-outline col-md-4">
            <label class="form-label" for="form2Example1">User Name</label>
            <asp:TextBox ID="tfUserName" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <!-- Password input -->
    <div class="col d-flex justify-content-center">
        <div class="form-outline col-md-4">
            <label class="form-label" for="form2Example2">Password</label>
            <asp:TextBox ID="tfPassword" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    
    <br />
    <!-- User Type-->
    <div class="col d-flex justify-content-center">
        <div class="form-outline col-md-4">
            <label class="form-label" for="form2Example2">User Type</label>
            <asp:DropDownList ID="ddUserType" CssClass="form-control" runat="server">
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Staff</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <!-- 2 column grid layout for inline styling -->
    <div class="row mb-4 mt-4">
        <div class="col d-flex justify-content-center">
            <!-- Checkbox -->
            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="form2Example31" checked />
                <label class="form-check-label" for="form2Example31"> Remember me </label>
            </div>
        </div>
    </div>

    <!-- Status Message -->
    <div class="col d-flex justify-content-center">
        <div class="form-outline col-md-4">
            <asp:Label ID="lblStatus" cssClass="alert alert-warning" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <!-- Submit button -->
    <div class="col d-flex justify-content-center">
        <asp:Button ID="Signin_Button" CssClass="btn btn-primary" runat="server" Text="Sign in" OnClick="Signin_Button_Click1" />
    </div>
    <br />
    <div class="text-center">
        <button type="button" class="btn btn-link btn-floating mx-1">
            <i class="fab fa-facebook-f"></i>
        </button>

        <button type="button" class="btn btn-link btn-floating mx-1">
            <i class="fab fa-google"></i>
        </button>

        <button type="button" class="btn btn-link btn-floating mx-1">
            <i class="fab fa-twitter"></i>
        </button>

        <button type="button" class="btn btn-link btn-floating mx-1">
            <i class="fab fa-github"></i>
        </button>
    </div>
    </div>
    
</asp:Content>
