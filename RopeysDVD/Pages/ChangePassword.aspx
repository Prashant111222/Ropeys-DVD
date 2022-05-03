<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="RopeysDVD.Pages.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="card col-md-12">
        <div class="card-body">
            <div class="col d-flex justify-content-center">
                <h3>Change Password</h3>
            </div>
            <br />
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <asp:TextBox ID="actorNumber" type="hidden" class="form-control" runat="server"></asp:TextBox>
                    <label for="exampleInputEmail1" class="form-label">Old Password</label>
                    <asp:TextBox ID="oldPassword" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="id" ControlToValidate="oldPassword" ValidationGroup="required" ErrorMessage="Please Enter Old Password!" ForeColor="Red"/>
                </div>
            </div>
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <label for="exampleInputPassword1" class="form-label">New Password</label>
                    <asp:TextBox ID="newPassword" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="newPassword" ValidationGroup="required" ErrorMessage="Please Enter New Password!" ForeColor="Red"/>
                </div>
            </div>
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <label for="exampleInputPassword1" class="form-label">Confirm Password</label>
                    <asp:TextBox ID="confirmPassword" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="confirmPassword" ValidationGroup="required" ErrorMessage="Please Enter Password To Confirm!" ForeColor="Red"/>
                </div>
            </div>
            <div class="col d-flex justify-content-center">
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </div>
                <br />
                <br />
            <div class="col d-flex justify-content-center">
                <asp:Button ID="Button_Submit" ValidationGroup="required" CssClass="btn btn-primary" runat="server" Text="Reset Password" OnClick="Button_Submit_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Clear" CssClass="btn btn-danger" runat="server" Text="Clear" OnClick="Button_Clear_Click" />
            </div>
        </div>
    </div>
</asp:Content>
