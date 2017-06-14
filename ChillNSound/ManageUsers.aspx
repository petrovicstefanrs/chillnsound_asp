<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="ChillNSound.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
    <form id="form1" runat="server" class="center_center">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM Users WHERE (Id = @original_Id)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE Users SET Username = @Username, Password = @Password WHERE (Username = @original_Username) AND (Password = @original_Password)">
            <DeleteParameters>
                <asp:Parameter Name="original_Id" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Username" />
                <asp:Parameter Name="Password" />
                <asp:Parameter Name="original_Username" />
                <asp:Parameter Name="original_Password" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <table class="material_table">
            <tr>
                <th>Username</th>
                <th>Password</th>
                <th>Add User</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbNewUsername" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbNewPassword" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnAddNewUser" runat="server" OnClick="Button1_Click" CssClass="btn-submit" Text="Add User" />
                </td>
            </tr>
        </table>
        <asp:GridView CssClass="material_table" ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" PageSize="3" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="Username" SortExpression="Username">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbUsernameEdit" runat="server" Text='<%# Bind("Username") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="tbUsernameEdit" runat="server" Text='<%# Bind("Username") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Password">
                    <ItemTemplate>
                        <asp:Label ID="HiddenPassword" runat="server" Text='**********'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbPassEdit" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:CommandField CausesValidation="False" HeaderText="Manage Users" InsertVisible="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
                
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLinksPlaceholder" runat="server">
    <div class="social_icons" id="footer_links" runat="server">
        
    </div>
</asp:Content>
