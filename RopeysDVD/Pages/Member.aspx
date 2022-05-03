<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs"
    Inherits="RopeysDVD.Member1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="card col-md-12">
            <div class="card-body">
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <label for="exampleInputEmail1" class="form-label">Membership Category</label>
                        <asp:DropDownList CssClass="form-control" ID="membershipCategory" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <asp:TextBox ID="memberNumber" type="hidden" class="form-control" runat="server"></asp:TextBox>
                        <label for="exampleInputEmail1" class="form-label">Member Last Name</label>
                        <asp:TextBox ID="lastName" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="id" ControlToValidate="lastName"
                            ValidationGroup="required" ErrorMessage="Please Provide the Member Last Name!"
                            ForeColor="Red" />
                    </div>
                </div>
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <label for="exampleInputPassword1" class="form-label">Member First Name</label>
                        <asp:TextBox ID="firstName" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="id1" ControlToValidate="firstName"
                            ValidationGroup="required" ErrorMessage="Please Provide the Member First Name!"
                            ForeColor="Red" />
                    </div>
                </div>
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <label for="exampleInputPassword1" class="form-label">Member Address</label>
                        <asp:TextBox ID="address" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="id2" ControlToValidate="address"
                            ValidationGroup="required" ErrorMessage="Please Provide the Member Address!"
                            ForeColor="Red" />
                    </div>
                </div>
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <label for="exampleInputPassword1" class="form-label">Member Date of Birth</label>
                        <asp:TextBox ID="datePicker" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="id3" ControlToValidate="datePicker"
                            ValidationGroup="required" ErrorMessage="Please Provide the Member DOB!" ForeColor="Red" />
                    </div>
                </div>
                <div class="col d-flex justify-content-center">
                    <asp:Label ID="Result" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <br />
                <div class="col d-flex justify-content-center">
                    <asp:Button ID="Button_Submit" ValidationGroup="required" CssClass="btn btn-primary" runat="server"
                        Text="Add Member" OnClick="Button_Submit_Click" />
                    <div class="divider"></div>
                    <asp:Button ID="Button_Update" ValidationGroup="required" CssClass="btn btn-primary" runat="server"
                        Text="Update" OnClick="Button_Update_Click" />
                    <div class="divider"></div>
                    <asp:Button ID="Button_Delete" ValidationGroup="required" CssClass="btn btn-danger" runat="server"
                        Text="Delete" OnClick="Button_Delete_Click" />
                    <div class="divider"></div>
                    <asp:Button ID="Button_Clear" CssClass="btn btn-danger" runat="server" Text="Clear"
                        OnClick="Button_Clear_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="card col-md-12">
            <div class="card-body">
                <asp:GridView ID="MemberGV" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging"
                    CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false"
                    OnRowCommand="MemberGV_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.N">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label1" Text='<%#Eval("MemberNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category Number">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="ActorLastName"
                                    Text='<%#Eval("MembershipCategoryNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label2" Text='<%#Eval("MemberLastName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label3" Text='<%#Eval("MemberFirstName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label4" Text='<%#Eval("MemberAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DOB">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label5" Text='<%#Eval("MemberDateOfBirth") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary"
                                    CommandName="View" CommandArgument='<%#Bind("MemberNumber")%>'
                                    CausesValidation="false">Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Content>