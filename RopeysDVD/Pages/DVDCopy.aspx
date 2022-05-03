<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="DVDCopy.aspx.cs"
    Inherits="RopeysDVD.DVDCopy1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="card col-md-12">
            <div class="card-body">
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <asp:TextBox ID="copyNumber" type="hidden" class="form-control" runat="server"></asp:TextBox>
                        <label for="exampleInputEmail1" class="form-label">Select DVD</label>
                        <asp:DropDownList CssClass="form-control" ID="dvdNumber" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="col d-flex justify-content-center">
                    <div class="col-md-4">
                        <label for="exampleInputPassword1" class="form-label">Date Purchased</label>
                        <asp:TextBox ID="datePicker" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="id" ControlToValidate="datePicker"
                            ValidationGroup="required" ErrorMessage="Please Select the Purchased Date!"
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
                        Text="Add DVD Copy" OnClick="Button_Submit_Click" />
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
                <asp:GridView ID="CopyGV" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging"
                    CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false"
                    OnRowCommand="CopyGV_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.N">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label1" Text='<%#Eval("CopyNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DVD Number">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="ActorLastName" Text='<%#Eval("DVDNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Purchased">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label2" Text='<%#Eval("DatePurchased") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary"
                                    CommandName="View" CommandArgument='<%#Bind("CopyNumber")%>'
                                    CausesValidation="false">Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </asp:Content>