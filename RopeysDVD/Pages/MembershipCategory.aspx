<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="MembershipCategory.aspx.cs" Inherits="RopeysDVD.MembershipCategory1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="card col-md-12">
            <div class="card-body">
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <asp:TextBox ID="categoryNumber" type="hidden" class="form-control" runat="server">
                        </asp:TextBox>
                        <label for="exampleInputEmail1" class="form-label">Membership Category Description</label>
                        <asp:TextBox ID="categoryDescription" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="id" ControlToValidate="categoryDescription"
                            ValidationGroup="required" ErrorMessage="Please Provide the Category Description!"
                            ForeColor="Red" />
                    </div>
                </div>
                <br />
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <label for="exampleInputPassword1" class="form-label">Total Loans</label>
                        <asp:TextBox ID="totalLoans" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="id1" ControlToValidate="totalLoans"
                            ValidationGroup="required" ErrorMessage="Please Provide the Total Loans!" ForeColor="Red" />
                    </div>
                </div>
                <br />
                <div class="col d-flex justify-content-center">
                    <asp:Label ID="Result" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <br />
                <div class="col d-flex justify-content-center">
                    <asp:Button ID="Button_Submit" ValidationGroup="required" CssClass="btn btn-primary" runat="server"
                        Text="Add Memberhip" OnClick="Button_Submit_Click" />
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
                <asp:GridView ID="MembershipCategoryGV" PageSize="5" AllowPaging="true"
                    OnPageIndexChanging="OnPageIndexChanging" CssClass="table table-dark table-sm table-hover"
                    runat="server" AutoGenerateColumns="false" OnRowCommand="MembershipCategoryGV_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.N">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label1" Text='<%#Eval("MembershipCategoryNumber") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category Description">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="ActorLastName"
                                    Text='<%#Eval("MembershipCategoryDescription") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Loans">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label2" Text='<%#Eval("MembershipCategoryTotalLoans") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary"
                                    CommandName="View" CommandArgument='<%#Bind("MembershipCategoryNumber")%>'
                                    CausesValidation="false">Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Content>