<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="LoanType.aspx.cs" Inherits="RopeysDVD.LoanType1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="card col-md-12">
            <div class="card-body">
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <asp:TextBox ID="loanTypeNumber" type="hidden" class="form-control" runat="server">
                        </asp:TextBox>
                        <label for="exampleInputEmail1" class="form-label">Loan Type</label>
                        <asp:TextBox ID="loanType" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="id" ControlToValidate="loanType"
                            ValidationGroup="required" ErrorMessage="Please Provide the Loan Type!" ForeColor="Red" />
                    </div>
                </div>
                <br />
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <label for="exampleInputPassword1" class="form-label">Loan Duration</label>
                        <asp:TextBox ID="loanDuration" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="id" ControlToValidate="loanType"
                            ValidationGroup="required" ErrorMessage="Please Provide the Loan Duration!"
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
                    <asp:Button ID="Button_Submit" ValidationGroup="required" CssClass="btn btn-primary" runat="server"
                        Text="Add Loan Type" OnClick="Button_Submit_Click" />
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
                <asp:GridView ID="LoanTypeGV" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging"
                    CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false"
                    OnRowCommand="LoanTypeGV_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.N">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="LoanTypeNumber" Text='<%#Eval("LoanTypeNumber") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Loan Type">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="LoanType" Text='<%#Eval("LoanType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Loan Duration">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="LoanDuration" Text='<%#Eval("LoanDuration") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary"
                                    CommandName="View" CommandArgument='<%#Bind("LoanTypeNumber")%>'
                                    CausesValidation="false">Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Content>