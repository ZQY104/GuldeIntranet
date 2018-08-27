<%@ Page Title="ECRN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ECRN.aspx.cs" Inherits="GuldeDwgSystem.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <address>
        &nbsp;</address>
       <p>
        ECRN Number:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        Affected Part:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        Affected Drawing:
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  >
            <Columns>
            <asp:TemplateField HeaderText="Link">
              <ItemTemplate>
                 <%--<a href="<%#Eval("ECRNLink")%>"><%#Eval("ECRNLink")%></a>--%>
                 <asp:HyperLink ID="ECRNLink" runat="server" Text='Open' NavigateUrl='<%#"file:///"+Eval("ECRNLink")%>'></asp:HyperLink>
              </ItemTemplate>
            </asp:TemplateField>
            </Columns>

     </asp:GridView>
    <p>
        &nbsp;<address>
        <strong>Support:</strong>   <a href="mailto:Stone.Zhou@Emerson.com">Stone.Zhou@Emerson.com</a><br />
    </address>
</asp:Content>
