<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ManageSounds.aspx.cs" Inherits="ChillNSound.ManageSounds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">

    <form id="form1" runat="server" class="center_center">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Sounds]" UpdateCommand="UPDATE Sounds SET ImgUrl = @ImgUrl, SoundUrl = @SoundUrl WHERE (ImgUrl = @original_ImgUrl) AND (SoundUrl = @original_SoundUrl)" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM Sounds WHERE (Id = @original_Id)" OldValuesParameterFormatString="original_{0}">
            <DeleteParameters>
                <asp:Parameter Name="original_Id" Type="Int32"/>
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ImgUrl" Type="String"/>
                <asp:Parameter Name="SoundUrl" Type="String"/>
                <asp:Parameter Name="original_ImgUrl" Type="String"/>
                <asp:Parameter Name="original_SoundUrl" Type="String"/>
            </UpdateParameters>
        </asp:SqlDataSource>
        <table class="material_table">
            <tr>
                <th>Choose Image</th>
                <th>Choose Sound</th>
                <th>Upload</th>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn-submit" Text="Upload" />
                </td>
            </tr>
            </table>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="material_table" DataKeyNames="Id" DataSourceID="SqlDataSource1" PageSize="4" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="Sound Image">
                    <EditItemTemplate>
                        <asp:Image ID="SoundImage" runat="server" ImageUrl='<%# Bind("ImgUrl") %>' Visible="false"/>
                        <asp:FileUpload ID="FileUploadEditImage" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="SoundImage" runat="server" ImageUrl='<%# Bind("ImgUrl") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SoundUrl" SortExpression="SoundUrl">
                    <EditItemTemplate>
                        <asp:TextBox ID="SoundUrl" runat="server" Text='<%# Bind("SoundUrl") %>' Visible="false"></asp:TextBox>
                        <asp:FileUpload ID="FileUploadEditSound" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="SoundUrl" runat="server" Text='<%# Bind("SoundUrl") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField CausesValidation="False" HeaderText="Manage" InsertVisible="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLinksPlaceholder" runat="server">
    <div class="social_icons" id="footer_links" runat="server">

    </div>
</asp:Content>
