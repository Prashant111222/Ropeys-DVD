<%@ Page Title="" Language="C#" MasterPageFile="~/GuestMaster.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RopeysDVD.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- Email input -->
    <div class="col d-flex justify-content-center">
        <h1 class="w-100 text-xxl-center">Sign In!</h1>
    </div>
    <br />
    <div class="col d-flex justify-content-center">
        <div class="form-outline col-md-4">
            <asp:TextBox ID="tfUserName" class="form-control" runat="server"></asp:TextBox>
            <label class="form-label" for="form2Example1">User Name</label>
        </div>
    </div>

    <!-- Password input -->
    <div class="col d-flex justify-content-center">
        <div class="form-outline col-md-4">
            <asp:TextBox ID="tfPassword" class="form-control" runat="server"></asp:TextBox>
            <label class="form-label" for="form2Example2">Password</label>
        </div>
    </div>

    <!-- 2 column grid layout for inline styling -->
    <div class="row mb-4">
        <div class="col d-flex justify-content-center">
            <!-- Checkbox -->
            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="form2Example31" checked />
                <label class="form-check-label" for="form2Example31"> Remember me </label>
            </div>
        </div>
    </div>

    <!-- Submit button -->
    <div class="col d-flex justify-content-center">
        <asp:Button ID="Signin_Button" CssClass="btn btn-primary" runat="server" Text="Sign in" />
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
</asp:Content>
