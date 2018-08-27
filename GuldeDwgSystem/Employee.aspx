<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="GuldeDwgSystem.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <p>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ShortName" HeaderText="ShortName" SortExpression="ShortName" />
            <asp:BoundField DataField="姓" HeaderText="姓" SortExpression="姓" />
            <asp:BoundField DataField="名" HeaderText="名" SortExpression="名" />
            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
            <asp:BoundField DataField="Job_Title" HeaderText="Job_Title" SortExpression="Job_Title" />
            <asp:BoundField DataField="Business_Phone" HeaderText="Business_Phone" SortExpression="Business_Phone" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GuldeERP_TestConnectionString %>" SelectCommand="SELECT [ShortName], [姓], [名], [EmployeeID], [Job Title] AS Job_Title, [Business Phone] AS Business_Phone FROM [30_employees] WHERE ([Statu] = @Statu) ORDER BY [姓]">
            <SelectParameters>
                <asp:Parameter DefaultValue="Active" Name="Statu" Type="String" />
            </SelectParameters>
            </asp:SqlDataSource>
</p>
</asp:Content>
