<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCity.aspx.cs" Inherits="rwa_projekt_katlija_2407.AddCity" UnobtrusiveValidationMode="none"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container status-container">
          <h1 style="width: 225px; margin-top:-12px;">AdventureWorksOBP - cities</h1>
            <div class="contbtnh" style="text-align:center;">
            <h2 class="addstateheader" style="margin-left:0px;">Add a new city</h2>
            </div>

            <label class="txtadd">Pick a state: </label>
            <asp:DropDownList ID="ddlstate" runat="server" style="margin-bottom: 20px;"></asp:DropDownList>
            <br />
            <label class="txtadd">Name: </label>
            <asp:TextBox ID="AddAState" runat="server" CssClass="my-textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="City name must be declared." ControlToValidate="AddAState" Display="none"></asp:RequiredFieldValidator>
            <asp:Button ID="add" runat="server" Text="Add" CssClass="btn btn-success" OnClick="add_Click" />
            <div class="status" id="status" runat="server">
                <asp:Label ID="lblStatus" runat="server" CssClass="lblstatus"></asp:Label>
                <br />
                <div style="margin-top: 20px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/update.png" CssClass="editImg" OnClick="ImageButton1_Click" />
                </div>
            </div>                            
            </div>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="true" ShowSummary="false" />

    </asp:Content>
