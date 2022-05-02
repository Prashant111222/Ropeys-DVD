<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Loan.aspx.cs" Inherits="RopeysDVD.Loan1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="card col-md-12">
        <div class="card-body">
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <asp:TextBox ID="loanNumber" type="hidden" class="form-control" runat="server"></asp:TextBox>
                    <label for="exampleInputEmail1" class="form-label">Loan Type</label>
                    <asp:DropDownList CssClass="form-control" ID="loanType" runat="server"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <label for="exampleInputEmail1" class="form-label">Copy Number</label>
                    <asp:DropDownList CssClass="form-control" ID="copyNumber" runat="server"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <label for="exampleInputEmail1" class="form-label">Member</label>
                    <asp:DropDownList CssClass="form-control" ID="member" runat="server"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="col d-flex justify-content-center">
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </div>
                <br />
                <br />
            <div class="col d-flex justify-content-center">
                <asp:Button ID="Button_Submit" CssClass="btn btn-primary" runat="server" Text="Add Loan" OnClick="Button_Submit_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Return" CssClass="btn btn-primary" runat="server" Text="Return" OnClick="Button_Return_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Delete" CssClass="btn btn-danger" runat="server" Text="Delete" OnClick="Button_Delete_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Clear" CssClass="btn btn-danger" runat="server" Text="Clear" OnClick="Button_Clear_Click" />
            </div>
        </div>
    </div>
    <br />
    <div class="card col-md-12">
        <div class="card-body">
            <asp:GridView ID="LoanGV" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false" OnRowCommand="LoanGV_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.N">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("LoanNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Loan Type">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ActorLastName" Text='<%#Eval("LoanTypeNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Copy Number">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label2" Text='<%#Eval("CopyNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Member">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label3" Text='<%#Eval("MemberNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Out">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label4" Text='<%#Eval("DateOut") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Due">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label5" Text='<%#Eval("DateDue") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Returned">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label6" Text='<%#Eval("DateReturned") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary" CommandName="View" CommandArgument='<%#Bind("LoanNumber")%>' CausesValidation="false">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
