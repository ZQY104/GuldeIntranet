<%@ Page Title="SearchDWG" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchDWG.aspx.cs" Inherits="GuldeDwgSystem.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <p>
        Drawing Number:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        Fisher Number:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        First Name:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        Last Name:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
    </p>
    <p>
        Description:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        Status:<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Status" DataValueField="Status"> </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GuldeERP_TestConnectionString2 %>" SelectCommand="SELECT [Status] FROM [30_dwgstatus]"></asp:SqlDataSource>
        Predecessor:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        Project ID:<asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="Project_Number" DataValueField="Project_Number"> </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GuldeERP_TestConnectionString2 %>" SelectCommand="SELECT [Project Number] AS Project_Number FROM [30_project]"></asp:SqlDataSource>
        Patent#:<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server"  >
            <Columns>
                <asp:TemplateField HeaderText="Link">
     <ItemTemplate>
          <%--<a href="<%#Eval("DrawingLink")%>"><%#Eval("DrawingLink")%></a>--%>
          <asp:HyperLink ID="DrawingLink" runat="server" Text='Open' NavigateUrl='<%#Eval("DrawingLink")%>'></asp:HyperLink>
      </ItemTemplate>
 </asp:TemplateField>
            </Columns>

     </asp:GridView>
    <p>
        &nbsp;</p>
</asp:Content>
