<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleContent.aspx.cs" Inherits="XkAarticle.ArticleContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="WebFormCss/ArticleContent.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hidArticleID" runat="server" />
    <div style="width:100%;height:100%;">
        <header>
           <div class="titleContainer">
               <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
           </div>
            <br />
            <p style="position:relative;min-height:30px;">
                <asp:DropDownList ID="ddlColumns" runat="server" AutoPostBack="false"></asp:DropDownList>
                <asp:Label ID="lbTips" runat="server" Text=""></asp:Label><asp:Button ID="BtnPublish" runat="server" Text="发布" OnClick="BtnPublish_Click" />
            </p>
        </header>
        <article>
            <asp:TextBox ID="TxtContent" runat="server" TextMode="MultiLine"></asp:TextBox>
        </article>
    </div>
    </form>
</body>
</html>
