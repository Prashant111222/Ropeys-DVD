<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="DVDTitle.aspx.cs" Inherits="RopeysDVD.DVDTitle1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="col d-flex justify-content-center">
        <h3 style="font-weight: bold">Movie Information</h3>
    </div>
    <div class="card col-md-12">
        <div class="card-body" style="margin-left: 5rem">
            <div class="col-md-4">
                <label for="exampleInputEmail1" class="form-label">DVD Category</label>
                <asp:DropDownList CssClass="form-control" ID="dvdCategory" runat="server"></asp:DropDownList>
            </div>
            <br />
            <div class="">
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="StudioChanged" />
                <label class="form-check-label" for="CheckBox1">
                    New Studio?
                </label>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:DropDownList CssClass="form-control" ID="studio" runat="server"></asp:DropDownList>
                </div>
                <div class="divider"></div>
                <div class="divider"></div>
                <div class="col-md-4">
                    <asp:TextBox ID="studioName" PlaceHolder="Studio Name" Enabled="false" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="">
                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="ProducerChanged" />
                <label class="form-check-label" for="CheckBox2">
                    New Producer?
                </label>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:DropDownList CssClass="form-control" ID="producer" runat="server"></asp:DropDownList>
                </div>
                <div class="divider"></div>
                <div class="divider"></div>
                <div class="col-md-4">
                    <asp:TextBox ID="producerName" PlaceHolder="Producer Name" Enabled="false" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="">
                <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" OnCheckedChanged="ActorChanged" />
                <label class="form-check-label" for="CheckBox3">
                    New Actor?
                </label>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <label for="exampleInputEmail1" class="form-label">Select Actors</label>
                    <asp:ListBox ID="actorList" CssClass="form-control" SelectionMode="Multiple" runat="server"></asp:ListBox>
                </div>
                <div class="divider"></div>
                <div class="divider"></div>
                <div class="col-md-3">
                    <label for="exampleInputEmail1" class="form-label"></label>
                    <asp:TextBox ID="actorSurname" PlaceHolder="Actor Surname" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                </div>
                <div class="divider"></div>
                <div class="col-md-3">
                    <label for="exampleInputEmail1" class="form-label"></label>
                    <asp:TextBox ID="actorFirstName" PlaceHolder="Actor First Name" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="col-md-4">
                <asp:TextBox ID="dvdNumber" type="hidden" class="form-control" runat="server"></asp:TextBox>
                <label for="exampleInputEmail1" class="form-label">DVD Title</label>
                <asp:TextBox ID="dvdTitle" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="validatorId" ControlToValidate="dvdTitle"
                    ValidationGroup="required" ErrorMessage="Please Provide the DVD Title!" ForeColor="Red" />
            </div>
            <div class="col-md-4">
                <label for="exampleInputPassword1" class="form-label">Date Released</label>
                <asp:TextBox ID="datePicker" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="id1" ControlToValidate="datePicker"
                    ValidationGroup="required" ErrorMessage="Please Provide the Released Date!" ForeColor="Red" />
            </div>
            <div class="col-md-4">
                <label for="exampleInputPassword1" class="form-label">Standard Charge</label>
                <asp:TextBox ID="standardCharge" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="id2" ControlToValidate="standardCharge"
                    ValidationGroup="required" ErrorMessage="Please Provide the Standard Charge!" ForeColor="Red" />
            </div>
            <div class="col-md-4">
                <label for="exampleInputPassword1" class="form-label">Penalty Charge</label>
                <asp:TextBox ID="penaltyCharge" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="id3" ControlToValidate="penaltyCharge"
                    ValidationGroup="required" ErrorMessage="Please Provide the Penalty Charge!" ForeColor="Red" />
            </div>
            <div class="col d-flex justify-content-center">
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div class="col d-flex justify-content-center">
                <asp:Button ID="Button_Submit" ValidationGroup="required" CssClass="btn btn-primary" runat="server"
                    Text="Add DVD" OnClick="Button_Submit_Click" />
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
            <asp:GridView ID="DVDGV" PageSize="5" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging"
                CssClass="table table-dark table-sm table-hover" runat="server" AutoGenerateColumns="false"
                OnRowCommand="DVDGV_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.N">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("DVDNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category Number">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ActorLastName" Text='<%#Eval("CategoryNumber") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Producer Number">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label2" Text='<%#Eval("ProducerNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StudioNumber">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label3" Text='<%#Eval("StudioNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DVD TItle">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label4" Text='<%#Eval("DVDTitle") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Released Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label5" Text='<%#Eval("DateReleased") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Standard Charge">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label6" Text='<%#Eval("StandardCharge") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Penalty Charge">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Label7" Text='<%#Eval("PenaltyCharge") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="Action_Button" runat="server" CssClass="btn btn-secondary"
                                CommandName="View" CommandArgument='<%#Bind("DVDNumber")%>'
                                CausesValidation="false">Select</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
