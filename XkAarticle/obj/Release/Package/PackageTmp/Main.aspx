<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="XkAarticle.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta   http-equiv="Pragma"   content="no-cache"/>   
    <meta   http-equiv="Cache-Control"   content="no-cache"/>   
    <meta   http-equiv="Expires"   content="0"/>   
    <link href="WebFormCss/Main.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" name="form1" runat="server"    >
        <div class="ColumnList">
        <asp:BulletedList ID="ColumnList"  runat="server" DisplayMode="HyperLink" DataValueField="Code" DataTextField="Title">
        </asp:BulletedList>
        </div>
        <div style="clear:both;"></div>
        <div class="ArticleReapter">
            <ul >
                <asp:Repeater ID="ArticleReapter" runat="server">
                    <ItemTemplate>
                        <dt>
                             <h3><%#Eval("Title") %></h3>
                                <div style="display:inline-block">
                                    <a><%#Eval("Author") %></a>
                                    <div style="display:inline-block;margin-left:50px;">
                                        <%#Eval("PublishTime") %>
                                    </div>
                                </div>
                        </dt>
                        <dd>
                            <p><%#Eval("Body") %></p>
                        </dd>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>

        </div>
        <div class="FriendlinkList">

        </div>
    </form>
</asp:Content>

