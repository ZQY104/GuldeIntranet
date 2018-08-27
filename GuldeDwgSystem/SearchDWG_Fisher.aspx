<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchDWG_Fisher.aspx.cs" Inherits="GuldeDwgSystem.SearchDWG_Fisher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div style="background-color: #00FFFF">
        <br />
        &nbsp Drawing#: <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox> &nbsp;<asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
        &nbsp <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
              <asp:TemplateField HeaderText="Link">
                      <ItemTemplate>
                           <%--<a href="<%#Eval("DrawingLink")%>"><%#Eval("DrawingLink")%></a>--%>
                               <asp:HyperLink ID="DrawingLink" runat="server" Text='Open' NavigateUrl='<%#Eval("Link")%>'>
                               </asp:HyperLink>
                     </ItemTemplate>
               </asp:TemplateField>
             </Columns>


        </asp:GridView>

    </div>
    <div> 
        <br />
        <br />
        <strong>Support:</strong>   <a href="mailto:Stone.Zhou@Emerson.com">Stone.Zhou@Emerson.com</a><br /></div>
</asp:Content>
