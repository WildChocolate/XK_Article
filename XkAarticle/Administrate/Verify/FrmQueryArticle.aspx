<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmQueryArticle.aspx.cs" Inherits="XkAarticle.Administrate.Verify.FrmQueryArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;height:100%;overflow:auto;min-height:800px;">
        <asp:GridView ID="ArticleGridView" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                <asp:BoundField DataField="ColumnID" HeaderText="ColumnID" Visible="False" />
                <asp:BoundField DataField="Title" HeaderText="文章标题" />
                <asp:BoundField DataField="Author" HeaderText="作者ID" Visible="False" />
                <asp:BoundField DataField="PostDate" HeaderText="更新时间" />
                <asp:ImageField DataImageUrlField="PicUrl">
                </asp:ImageField>
                <asp:BoundField DataField="Body" HeaderText="内容">
                <HeaderStyle Width="500px" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <p>是否通过</p>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkItem" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:TemplateField>
                
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
        <p>
        <asp:Button ID="Button1" runat="server" Text="删除" OnClick="Button1_Click"/><asp:Button ID="Button2" runat="server" Text="审核" OnClick="Button2_Click" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
