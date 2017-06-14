<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ChillNSound.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 108px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
    <form id="form1" runat="server" class="center_center">
        <table class="material_table">
            <tr>
                <td class="auto-style1">First Name:</td>
                <td>
                    <asp:TextBox ID="tbFirstName" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Last Name:</td>
                <td>
                    <asp:TextBox ID="tbLastName" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Mail:</td>
                <td>
                    <asp:TextBox ID="tbEmail" runat="server" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Message:</td>
                <td>
                    <textarea runat="server" id="tbMessage" style="width:160px;"></textarea>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" CssClass="btn-submit" Text="Send Message" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>

        <table class="material_table">
            <tr>
                <th>Suggestions:</th>
            </tr>
            <tr>
                <td>
                    
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbFirstName" ErrorMessage="Name Is Requierd" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbFirstName" ErrorMessage="Name : Min 3 | Max 30 | Capitalized" ValidationExpression="[A-Z]{1}[a-z]{2,29}" Display="None"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbLastName" ErrorMessage="Last Name Is Requierd" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Last Name : Min 3 | Max 30 | Capitalized" ValidationExpression="[A-Z]{1}[a-z]{2,29}" ControlToValidate="tbLastName" Display="None"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEmail" ErrorMessage="Mail Is Requierd" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Mail : Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbEmail" Display="None"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbMessage" Display="None" ErrorMessage="Message Is Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLinksPlaceholder" runat="server">
    <div class="social_icons" id="footer_links" runat="server">

    </div>
</asp:Content>
