﻿<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="Login.aspx.cs" Inherits="XkAarticle.Login" %>

<!DOCTYPE html>
<html lang="en" class="no-js">
<head>
<meta charset="UTF-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge"> 
<meta name="viewport" content="width=device-width, initial-scale=1"> 
<title>login</title>
<link rel="stylesheet" type="text/css" href="css/normalize.css" />
<link rel="stylesheet" type="text/css" href="css/demo.css" />
<!--必要样式-->
<link rel="stylesheet" type="text/css" href="css/component.css" />
<!--[if IE]>
<script src="js/html5.js"></script>
<![endif]-->
</head>
<body>
    <form id="form1" runat="server">

    
		<div class="container demo-1">
			<div class="content">
				<div id="large-header" class="large-header">
					<canvas id="demo-canvas"></canvas>
					<div class="logo_box">
						<h3>欢迎你</h3>
						<form action="#" name="f" method="post">
							<div class="input_outer">
								<span class="u_user"></span>
								<input name="logname" id="logname" runat="server" class="text" style="color: #FFFFFF !important;" type="text" placeholder="请输入账户">
							</div>
							<div class="input_outer">
								<span class="us_uer"></span>
								<input name="logpass" id="logpass" runat="server" class="text" style="color: #FFFFFF !important; position:absolute; z-index:100;" value="" type="password" placeholder="请输入密码">
							</div>
							<div class="mb2">
                                <%--<input class="act-but submit" id="Submit" runat="server" href="javascript:;" style="color: #FFFFFF" onserverclick="Submit_ServerClick">登录</input>--%>
                                <input class="act-but submit" type="submit" id="Submit" runat="server" value="登录" style="color: #FFFFFF;display:inline-block;" onclick="return true;" onserverclick="Submit_ServerClick"/>
                                <input class="act-but submit" type="submit" id="Register" runat="server" value="注册" style="color: #FFFFFF;display:inline-block;" onclick="return true;" onserverclick="Register_ServerClick"/>
                                <p>
                                    <asp:Label ID="TipsLabel" runat="server" Text=""></asp:Label>
                                </p>
							</div>
                            
						</form>
					</div>
				</div>
			</div>
		</div><!-- /container -->
		<script src="js/TweenLite.min.js"></script>
		<script src="js/EasePack.min.js"></script>
		<script src="js/rAF.js"></script>
		<script src="js/demo-1.js"></script>
		<div style="text-align:center;">
<!--<p>更多模板：<a href="http://www.mycodes.net/" target="_blank">源码之家</a></p>-->
</div>
        </form>
	</body>
</html>
