<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="XkAarticle.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/Register.css" rel="stylesheet"  />
    <title></title>
    <script>
        function RegisterClientCliek() {
            if (registerForm.password.value != registerForm.confirm.value) {
                alert("两次输入的密码必须相同！！！");
            }
        }
        var i = 3;
        function IntervalJumptoLogin() {
            var p = document.getElementById("time");
            var s = i + "秒后跳转.....";
            p.innerHTML = p.innerHTML + s;
            // 计时为0后，立即跳转
            i--;
            if (i < 0) {
                location.href = "Login.aspx";
            }
            setTimeout("IntervalJumptoLogin()", 1000);
        }
        //ICallbackEventHandler测试
        function GetNumber() {
            UseCallBack(); //回调函数
        }

        //用来接受返回信息并显示
        function GetRandom(TextBox1, content) {
            document.forms[0].txtMessage.innerHTML = TextBox1;
        }
    </script>
</head>
<body>
    
    <div class="main">
        <header>
            <p >文章发布系统用户注册</p>
        </header>
        <article>
            <section class="caption">
                <p >注册新用户（普通用户）</p>
            </section>
            <section class="register">
                <form id="registerForm" runat="server">
                    <div>
                        <p name="txtMessage"></p>
                        <label for="account">帐&emsp;&emsp;号</label>
                        <span>&emsp;&emsp;</span>
                        <input type="text" id="account" runat="server"/>
                    </div>
                    <div>
                        <label for="password">密&emsp;&emsp;码</label>
                        <span>&emsp;&emsp;</span>
                        <input type="password" name="password" id="password" runat="server"/>
                    </div>
                    <div>
                        <label for="confirm">确认密码</label>
                        <span>&emsp;&emsp;</span>
                        <input type="password" name="confirm" id="confirm" runat="server" />
                    </div>
                    <div>
                        <asp:Button ID="Button1" runat="server" Text="立即注册" OnClick="Button1_Click" OnClientClick="RegisterClientCliek()" />
                        <input id="btn" type="button" value="GetRandom" onclick="GetNumber()" />
                    </div>

                </form>
                <div class="side-img-box">
                    
                </div>
            </section>
            <section>
                <asp:Label ID="lbTip" runat="server" Text=""></asp:Label>
                <br />
                <p id="time"></p>
            </section>
        </article>
        <footer>
            <p>版本&copy;20171015</p>
        </footer>
    </div>
    
</body>
</html>
