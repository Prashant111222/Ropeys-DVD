<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="Producer.aspx.cs" Inherits="RopeysDVD.Producer1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="card col-md-12">
            <div class="card-body">
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <asp:TextBox ID="producerNumber" type="hidden" class="form-control" runat="server">
                        </asp:TextBox>
                        <label for="exampleInputEmail1" class="form-label">Producer Name</label>
                        <asp:TextBox ID="producerName" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="id" ControlToValidate="producerName"
                            ValidationGroup="required" ErrorMessage="Please Provide the Producer Name!"
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
                        Text="Add Producer" OnClick="Button_Submit_Click" />
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
                <asp:GridView ID="ProducerGV" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging"
                    CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false"
                    OnRowCommand="ProducerGV_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.N">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label1" Text='<%#Eval("ProducerNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Producer Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="ProducerName" Text='<%#Eval("ProducerName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary"
                                    CommandName="View" CommandArgument='<%#Bind("ProducerNumber")%>'
                                    CausesValidation="false">Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Content>