<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="rwa_projekt_katlija_2407.Customers" UnobtrusiveValidationMode="none"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container load-customers">
        <h1>AdventureWorksOBP</h1>
        <div id="groupShowCustomer">
            <span>Show </span>
            <asp:TextBox ID="numOfCustomers" runat="server" OnTextChanged="numOfCustomers_TextChanged" CssClass="my-textBox"></asp:TextBox>

            <asp:RangeValidator ID="RangeValidator" runat="server" ErrorMessage="Input is not a number or it is too low or too high. Check the maximum number of records in database." ControlToValidate="numOfCustomers" MinimumValue="1" Type="Integer" Display="None"></asp:RangeValidator>
            <asp:RequiredFieldValidator ID="validateNumOfCustomers" runat="server" ErrorMessage="Please define a desired number of customers." ControlToValidate="numOfCustomers" Display="none"></asp:RequiredFieldValidator>

            <span>of maximum </span>
            <asp:Label ID="maxCustomers" runat="server" CssClass="maxCustomers"></asp:Label><span> customers.</span>
            <asp:Button ID="btnLoad" runat="server" Text="Load customers" OnClick="btnLoad_Click" CssClass="btn btn-primary load-button" />
        </div>
    </div>

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Always">
        <ContentTemplate>

            <div class="container filter-container" runat="server" id="filterContainer">
                <h1>Filter by</h1>
                <div style="display: flex; align-items: center; justify-content: center;">
                    <label style="color: white; margin-right: 0.75vw;">State: </label>
                    <asp:DropDownList ID="ddlStates" runat="server" CssClass="ddlStates" OnSelectedIndexChanged="ddlStates_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:ImageButton ID="AddAState" runat="server" ImageUrl="~/Images/add.png" CssClass="addToBase" OnClick="AddAState_Click"></asp:ImageButton>
                    <asp:Label ID="lblCity" runat="server" CssClass="lblcity" Visible="false">City: </asp:Label>
                    <asp:DropDownList ID="ddlCities" runat="server" Visible="false" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:ImageButton ID="AddACity" runat="server" ImageUrl="~/Images/add.png" CssClass="addToBase" Visible="false" OnClick="AddACity_Click"></asp:ImageButton>
                </div>
            </div>

            <div class="container table-holder" runat="server" id="tblHolder">
                <h1>Customers</h1>
                <asp:GridView ID="gvCustomers" runat="server" CssClass="table my-table" AutoGenerateColumns="False" AllowPaging="True" PageSize="50" OnRowDataBound="gvCustomers_RowDataBound" OnRowEditing="gvCustomers_RowEditing" OnPageIndexChanging="gvCustomers_PageIndexChanging" OnRowCancelingEdit="gvCustomers_RowCancelingEdit" OnSorting="gvCustomers_Sorting" OnRowUpdating="gvCustomers_RowUpdating" OnRowCreated="gvCustomers_RowCreated" OnRowCommand="gvCustomers_RowCommand" AllowSorting="True" DataKeyNames="IDKupac,Email,Telefon,GradID,DrzavaID">
                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="customer-row" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="WhiteSmoke" Font-Underline="false"/>
                    <EditRowStyle BackColor="#FFDF6C" Height="5px" /> 
                    <PagerStyle HorizontalAlign="Center"/>
                    <Columns>
                        <asp:BoundField DataField="IDKupac" HeaderText="IDKupac" Visible="False" />
                        <asp:TemplateField HeaderText="Name" SortExpression="Ime">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Ime") %>' CssClass="my-textBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Field Name is required!" ControlToValidate="TextBox1" Display="None"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Ime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Surname" SortExpression="Prezime">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Prezime") %>' CssClass="my-textBox"></asp:TextBox>      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field Surname is required!" ControlToValidate="TextBox2" Display="None" ></asp:RequiredFieldValidator>                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Prezime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Email" HeaderText="Email" Visible="False" />
                        <asp:BoundField DataField="Telefon" HeaderText="Telefon" Visible="False" />
                        <asp:TemplateField HeaderText="State">
                            <EditItemTemplate>
                                <asp:DropDownList runat="server" ID="ChooseState" Autopostback="true" OnSelectedIndexChanged="ChooseState_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please pick a state!" ControlToValidate="ChooseState" Display="None"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Drzava") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City">
                            <EditItemTemplate>
                                <asp:DropDownList runat="server" ID="ChooseCity"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please pick a city!" ControlToValidate="ChooseCity" Display="None"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Grad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="GradID" HeaderText="GradID" Visible="False" />
                        <asp:BoundField DataField="DrzavaID" HeaderText="DrzavaID" Visible="false" />

                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="5.3%">
                            <ItemTemplate>
                                <asp:ImageButton ID="moreInfoButton" runat="server" CausesValidation="false" CommandName="moreInfo" ImageUrl="~/Images/info.png" Text="Info" CssClass="moreInfo" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            </ItemTemplate>
                            <ItemStyle Width="5.3%" />
                        </asp:TemplateField>

                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="5.3%">
                            <ItemTemplate>
                                <asp:ImageButton ID="receiptsButton" runat="server" CausesValidation="false" CommandName="showReceipts" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  ImageUrl="~/Images/receipts.png" Text="Receipts" CssClass="receipts" />
                            </ItemTemplate>
                            <ItemStyle Width="5.3%" />
                        </asp:TemplateField>

                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="10.4%">
                            <EditItemTemplate>
                                <asp:ImageButton ID="updateButton" runat="server" CausesValidation="true" CommandName="Update" Text="Update" ImageUrl="~/Images/update.png" CssClass="editImg"/>
                                &nbsp;<asp:ImageButton ID="cancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" ImageUrl="~/Images/cancel.png" CssClass="receipts" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="editButton" runat="server" CausesValidation="False" CommandName="Edit" ImageUrl="~/Images/edit.png" Text="Edit" CssClass="editImg" />
                            </ItemTemplate>
                            <ItemStyle Width="10.4%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="test" runat="server"> </asp:Label>
    <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="true" ShowSummary="false" />

</asp:Content>
