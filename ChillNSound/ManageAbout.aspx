<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ManageAbout.aspx.cs" Inherits="ChillNSound.ManageAbout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
    <form id="form1" runat="server" class="center_center">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [About]" ConflictDetection="CompareAllValues" UpdateCommand="UPDATE About SET AboutImg = @AboutImg, AboutDesc = @AboutDesc, AboutName = @AboutName WHERE (AboutImg = @original_AboutImg) AND (AboutName = @original_AboutName)">
            <UpdateParameters>
                <asp:Parameter Name="AboutImg" />
                <asp:Parameter Name="AboutDesc" />
                <asp:Parameter Name="AboutName" />
                <asp:Parameter Name="original_AboutImg" />
                <asp:Parameter Name="original_AboutName" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="material_table" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="About Image" SortExpression="AboutImg">
                    <EditItemTemplate>
                        <asp:Image ID="AboutImage" runat="server" ImageUrl='<%# Bind("AboutImg") %>' Visible="false"/>
                        <asp:FileUpload ID="FileUploadEditImage" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="AboutImage" runat="server" ImageUrl='<%# Bind("AboutImg") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="About Info" SortExpression="AboutDesc">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AboutDesc") %>' Height="70px" MaxLength="250" TextMode="MultiLine" Width="160px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("AboutDesc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="About Full Name" SortExpression="AboutName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("AboutName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("AboutName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" HeaderText="Edit About" ShowEditButton="True">
                <ControlStyle CssClass="btn-submit" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLinksPlaceholder" runat="server">
    <div class="social_icons" id="footer_links" runat="server">

    </div>
</asp:Content>
