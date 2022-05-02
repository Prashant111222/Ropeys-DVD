<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actor.aspx.cs" Inherits="RopeysDVD.Actor1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="card col-md-12">
        <div class="card-body">
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <asp:TextBox ID="actorNumber" type="hidden" class="form-control" runat="server"></asp:TextBox>
                    <label for="exampleInputEmail1" class="form-label">Actor Surname</label>
                    <asp:TextBox ID="actorSurname" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="id" ValidationGroup="required" ControlToValidate="actorSurname" ErrorMessage="Please Enter Actor Surname!" ForeColor="Red"/>
                </div>
            </div>
                <br />
            <div class="col d-flex justify-content-center">
                <div class="col-md-4">
                    <label for="exampleInputPassword1" class="form-label">Actor First Name</label>
                    <asp:TextBox ID="actorFirstName" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
                <br />
            <div class="col d-flex justify-content-center">
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </div>
                <br />
                <br />
            <div class="col d-flex justify-content-center">
                <asp:Button ID="Button_Submit" CssClass="btn btn-primary" ValidationGroup="required" runat="server" Text="Add Actor" OnClick="Button_Submit_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Update" CssClass="btn btn-primary" ValidationGroup="required" runat="server" Text="Update" OnClick="Button_Update_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Delete" CssClass="btn btn-danger" ValidationGroup="required" runat="server" Text="Delete" OnClick="Button_Delete_Click" />
                <div class="divider"></div>
                <asp:Button ID="Button_Clear" CssClass="btn btn-danger" runat="server" Text="Clear" OnClick="Button_Clear_Click" />
            </div>
        </div>
    </div>
    <br />
    <div class="card col-md-12">
        <div class="card-body">
            <asp:GridView ID="ActorGridView" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false" OnRowCommand="ActorGridView_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.N">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ActorNumber" Text='<%#Eval("ActorNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ActorLastName" Text='<%#Eval("ActorFirstName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Surname">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ActorSurname" Text='<%#Eval("ActorSurname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary" CommandName="View" CommandArgument='<%#Bind("ActorNumber")%>' CausesValidation="false">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>