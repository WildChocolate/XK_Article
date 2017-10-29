<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WriteArticle.aspx.cs" Inherits="XkAarticle.WriteArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="WebFormCss/Article.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Main">
        <aside>
                <div class="ArticleList">
                    <h3>
                        <asp:HyperLink ID="Goback" runat="server" NavigateUrl="~/Main.aspx">返回主页</asp:HyperLink>
                    </h3>
                    <h4>
                        <asp:HyperLink ID="linkNew" runat="server" NavigateUrl="ArticleContent.aspx" Target="ArticleFrm">新建文章</asp:HyperLink>
                    </h4>
                    <ul id="ulArticle">
                    <asp:Repeater ID="ArticleReapter" runat="server">
                        <ItemTemplate>
                            <li onclick="liClickHandler(this)">
                                <a href="ArticleContent.aspx?ArticleID=<%#Eval("ID") %>" target="ArticleFrm"><%#Eval("Title") %></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                    </ul>
                </div>
            
        </aside>
        <article>
            <iframe id="ArticleFrm" name="ArticleFrm" class="ArticleFrm" scrolling="no" width="100%" height="100%" frameborder="0" scrolling="no" >

            </iframe>
        </article>
    </div>
    </form>
    <script>
        function liClickHandler(e) {
            //e.parentNode.style.backgroundColor = "gray";
            var lis = e.parentNode.getElementsByTagName("li");
            //alert(lis);
            for (var i = 0; i < lis.length;i++ ){
                lis[i].style.backgroundColor = "gray";
            }
            e.style.backgroundColor = "#2f2f2f";
        }
         window.onload = function () {
             
        }
    </script>
</body>
</html>
