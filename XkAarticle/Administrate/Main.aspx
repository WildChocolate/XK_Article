<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XkAarticle.Administrate.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/AdminMain.css" rel="stylesheet"/>
</head>
<body>
    <header>
        <h1>系统管理</h1>
    </header>
    <form id="form1" runat="server">
        <aside>
            <p><a href="Verify/FrmQueryArticle.aspx" target="ifm">文章管理</a></p>
            <p><a href="Verify/FrmQueryUser.aspx" target="ifm">人员管理</a></p>
            <p><a href="" target="ifm">角色管理</a></p>
            <p><a href="" target="ifm">栏目管理</a></p>
            <p><a href="" target="ifm">友情链接管理</a></p>
            <p><a href="" target="ifm">公告管理</a></p>
            <p><a href="" target="ifm">评论管理</a></p>
        </aside>
        <article>
            <iframe id="ifm" name="ifm" style="border:none;width:100%;height:100%" scrolling="no" width="100%" height="100%" frameborder="0">

            </iframe>
        </article>
    </form>
    
</body>
</html>
