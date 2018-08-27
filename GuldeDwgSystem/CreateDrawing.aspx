<%@ Page Title="CreateDrawing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateDrawing.aspx.cs" Inherits="GuldeDwgSystem.CreateDrawing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div style="border-style: solid; background-color: #00FFFF;">
            <br />
            <h3>Save drawing in GuldeDwgSearch.</h3>
            <br />
            Drawing Number:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;
            Fisher Number:
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            &nbsp;
            First Name:
            <asp:TextBox ID="TextBox3" runat ="server"></asp:TextBox>
            &nbsp;
            Last Name:
            <asp:TextBox ID="TextBox4" runat ="server"></asp:TextBox>
            &nbsp;
            <br />
            <br />
            Description:
            <asp:TextBox ID="TextBox5" runat ="server" Width="270px"></asp:TextBox>
            &nbsp;
            Status:
            <asp:DropDownlist ID="DropDownList1" runat ="server">
                 <asp:ListItem>ACTIVE</asp:ListItem>
                 <asp:ListItem>INACTIVE</asp:ListItem>
            <asp:ListItem></asp:ListItem>
            </asp:DropDownlist>
            &nbsp;
            Predecessor:
            <asp:TextBox ID ="TextBox7" runat ="server"></asp:TextBox>
            &nbsp;
            Project ID:
            <asp:DropDownList ID ="DropDownList2" runat ="server" DataSourceID="SqlDataSource1" DataTextField="Project_Number" DataValueField="Project_Number"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GuldeERP_TestConnectionString %>" SelectCommand="SELECT [Project Number] AS Project_Number FROM [30_project]"></asp:SqlDataSource>
            &nbsp;
            Pattern#
            <asp:DropDownList ID ="DropDownList3" runat ="server" DataSourceID="SqlDataSource2" DataTextField="Pattern_Number" DataValueField="Pattern_Number"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GuldeERP_TestConnectionString %>" SelectCommand="SELECT [Pattern Number] AS Pattern_Number FROM [30_pattern] ORDER BY [Pattern Number]"></asp:SqlDataSource>
            <br />
            <br />
            Rev:
            <asp:DropDownList ID ="DropDownList4" runat ="server" DataSourceID="SqlDataSource3" DataTextField="Revision" DataValueField="Revision"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GuldeERP_TestConnectionString %>" SelectCommand="SELECT [Revision] FROM [30_rev]"></asp:SqlDataSource>
            Ver:
            <asp:DropDownList ID ="DropDownList5" runat ="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
            </asp:DropDownList>
            Sheet #:
            <asp:DropDownList ID ="DropDownList6" runat ="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
            </asp:DropDownList>
            Total Sheets:
            <asp:DropDownList ID ="DropDownList7" runat ="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Drawn by:
            <asp:DropDownList ID ="DropDownList8" runat ="server" DataSourceID="SqlDataSource4" DataTextField="First_Name" DataValueField="ShortName"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:GuldeERP_TestConnectionString %>" SelectCommand="SELECT [ShortName], [Last Name] AS Last_Name, [First Name] AS First_Name FROM [30_employees] WHERE ([Statu] = @Statu)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Active" Name="Statu" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            Checked By:
            <asp:DropDownList ID ="DropDownList9" runat ="server" DataSourceID="SqlDataSource4" DataTextField="First_Name" DataValueField="ShortName"></asp:DropDownList>
            Approved By:
            <asp:DropDownList ID ="DropDownList10" runat ="server" DataSourceID="SqlDataSource4" DataTextField="First_Name" DataValueField="ShortName"></asp:DropDownList>

            &nbsp;&nbsp;&nbsp;

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <div class="auto-style2">
            </div>
            <br />
        </div>
</asp:Content>
