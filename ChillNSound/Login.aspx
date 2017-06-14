<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ChillNSound.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
    <div class="login-panel">
        <form id="form1" runat="server">
        <h3>Login</h3>
        <input id="tbUsername" runat="server" type="text" placeholder="username"/><br />
        <input id="tbPassword" runat="server" type="password" placeholder="password"/><br />
        <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn-submit" OnClick="Button1_Click"/>
        
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLinksPlaceholder" runat="server">
    <div class="social_icons" id="footer_links" runat="server">

    </div>
</asp:Content>
