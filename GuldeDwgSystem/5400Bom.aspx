<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="5400Bom.aspx.cs" Inherits="GuldeDwgSystem._5400Bom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p style="background-color: #00FFFF">
<!--搜索框-->
        <br />
    &nbsp; BOM #:
    <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>&nbsp;     
    <a href="file://cntsn1-vmgweb01/C$/inetpub/Importantdocument/P_5400/5400阀门BOM命名规则.PDF/" target="_blank">(BOM#编码说明)</a>
    EM #:&nbsp; <asp:TextBox ID="TextBox2" runat="server" Width="400px"></asp:TextBox>&nbsp;    
    Discription: <asp:TextBox ID="TextBox3" runat="server" Width="400px"></asp:TextBox>&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />&nbsp; 
    <br />
        <br />
    </p>
<!--GridView 1, 显示BOM-EM信息-->
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound" AllowSorting="True"    AutoGenerateColumns="False" >
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />

        <Columns>            
            
           <asp:TemplateField HeaderText="">
             <ItemTemplate>
                <%--<a href="<%#Eval("DrawingLink")%>"><%#Eval("DrawingLink")%></a>--%>
                 <asp:Button ID="Button4" runat="server" Text="BOM list" OnClick="Button4_Click" CommandName ="Bom #" CommandArgument='<%#Eval("[Bom #]") %>' /> 
             </ItemTemplate>
          </asp:TemplateField>

            <asp:BoundField DataField="Bom #" HeaderText="Bom #"  />
            <asp:BoundField DataField="EM" HeaderText="EM"  />
            <asp:BoundField DataField="Description" HeaderText="Description"  />
            <asp:BoundField DataField="KV/CV" HeaderText="KV/CV"  />
            <asp:BoundField DataField="Shutoff" HeaderText="Shutoff"  />
            <asp:BoundField DataField="Hydro" HeaderText="Hydro"  />

           <asp:TemplateField HeaderText="">
             <ItemTemplate>
                <%--<a href="<%#Eval("DrawingLink")%>"><%#Eval("DrawingLink")%></a>--%>
                 <asp:Button ID="Button3" runat="server" Text="Em String" OnClick="Button3_Click" CommandName ="EM" CommandArgument='<%#Eval("EM") %>' /> 
             </ItemTemplate>
          </asp:TemplateField>     
            
         </Columns>

    </asp:GridView>

<!--Mutiple view-->
    <asp:MultiView ID="MultiView1" runat="server">
        <!--View for Engineer-->
        <asp:View ID="View1" runat="server">
                    <!--View for Order Entry-->
             <br />
    以下两个蓝色表可导出到EXCEL,请点击： 
            <asp:Button ID="Button2" runat="server" Text="Export (Engineer)" OnClick="Button2_Click" />
            <asp:Button ID="Button6" runat="server" Text="Export (OE)" OnClick="Button5_Click" />
    <asp:GridView ID="GridView3" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>

    <br />
    <asp:GridView ID="GridView2" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>

        </asp:View>

        <asp:View ID="View2" runat="server">
     以下两个蓝色表可导出到EXCEL,请点击： 
            <asp:Button ID="Button7" runat="server" Text="Export (Engineer)" OnClick="Button2_Click" />
            <asp:Button ID="Button5" runat="server" Text="Export (OE)" OnClick="Button5_Click" />
    <asp:GridView ID="GridView4" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>

    <br />
    <asp:GridView ID="GridView5" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
