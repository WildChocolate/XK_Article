<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmQueryUser.aspx.cs" Inherits="XkAarticle.Administrate.Verify.FrmQueryUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;height:100%;">
        <asp:GridView ID="UserGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="UserGridView_RowDataBound" AllowPaging="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkUser" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="用户ID" />
                <asp:BoundField DataField="Name" HeaderText="用户名" />
                <asp:BoundField DataField="Pass" HeaderText="密码" />
                <asp:TemplateField HeaderText="角色">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlRole" DataValueField="ID" DataTextField="Name" runat="server">

                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="RoleID" Visible="False" />
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
            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click"/><asp:Button ID="Button2" runat="server" Text="删除" OnClick="Button2_Click"/>
        </p>
        <p>
            <asp:Label ID="lbTip" runat="server" Text=""></asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
