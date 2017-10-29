<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="XkAarticle.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="WebFormCss/Register.css" rel="stylesheet"  />
    <title></title>
    <script>
        function RegisterClientCliek() {
            var result = true;
            if (registerForm.account.value == "") {
                alert("请输入用户名！！！");
                result = false;
            }
            else if (registerForm.password.value == "") {
                alert("请输入密码！！！");
                result = false;
            }
            else if (registerForm.password.value == "") {
                alert("请再次输入密码！！！");
                result = false;
            }
            else if (registerForm.password.value != registerForm.confirm.value) {
                alert("两次输入的密码必须相同！！！");
                result = false;
            }

            return result;
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
        function CheckType() {
            //得到上传文件的值     
            var fileName = document.getElementById("FileUpLoad1").value;

            //返回String对象中子字符串最后出现的位置.     
            var seat = fileName.lastIndexOf(".");

            //返回位于String对象中指定位置的子字符串并转换为小写.     
            var extension = fileName.substring(seat).toLowerCase();

            //判断允许上传的文件格式     
            //if(extension!=".jpg"&&extension!=".jpeg"&&extension!=".gif"&&extension!=".png"&&extension!=".bmp"){     
            //alert("不支持"+extension+"文件的上传!");     
            //return false;     
            //}else{     
            //return true;     
            //}     

            var allowed = [".jpg", ".gif", ".png", ".bmp", ".jpeg"];
            for (var i = 0; i < allowed.length; i++) {
                if (!(allowed[i] != extension)) {
                    return true;
                }
            }
            alert("不支持" + extension + "格式");
            return false;
        }
        function show(id) {
            alert(id);
            document.getElementById("Image1").src = id;
        }
        function show1(upimg) {
            var dd = document.getElementById("divview");
            dd.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = upimg;
            dd.style.width = 166;
            dd.style.height = 190;
            dd.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").sizingMethod = 'scale';
        }
        //ICallbackEventHandler测试
        function GetNumber() {
            
            
                UseCallBack(); //回调函数
           
        }

        //用来接受返回信息并显示
        function GetRandom(TextBox1, content) {
            
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
                        <label for="File1">头像图片</label>
                        <span>&emsp;&emsp;</span>
                        <asp:FileUpload ID="FileUpload1" runat="server" onpropertychange="show(this.value)" />
                    </div>
                    <div>
                        <asp:Button ID="Button1" runat="server" Text="立即注册" OnClick="Button1_Click" OnClientClick="return RegisterClientCliek();" />
                        <%--<input id="btn" type="button" value="上传照片" onclick="GetNumber()" />--%>
                        <asp:Button ID="Button2" runat="server" Text="上传照片" OnClick="Button2_Click" OnClientClick="return CheckType();"/>
                    </div>
                   
                </form>
                <div class="side-img-box">
                    <asp:Image ID="Image1" runat="server" />
                     <div id="divview" style="width:160px;height:199px;">  
                     </div>  
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
