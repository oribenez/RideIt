<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html dir="rtl" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>התחברות - Ride it</title>

    <link rel="icon" type="image/png" href="images/favicon.png" />
    <link href="css/loginS.css" rel="stylesheet" type="text/css" />
    <script src="js/login.js" type="text/javascript"></script>
</head>
<body>

    <div id="login_block">
        <div id="login_main">
            <h1>כניסה למשתמש</h1>
            <form id="logForm" method="post" action="login.aspx" onsubmit="return Valid()">
                <table>
                    <tr>
                        <td>
                            <input type="text" value="אימייל" id="txtLoginMail" runat="server" name="txtLoginMail" onfocus="loginEmpty(this)" onblur="loginBack(this)" /></td>
                        <td id="error_mail"></td>
                    </tr>
                    <tr>
                        <td>
                            <input type="text" value="סיסמא" id="txtLoginPass" name="txtLoginPass" runat="server" onfocus="loginEmpty(this)" onblur="loginBack(this)" /></td>
                        <td id="error_pass"></td>
                    </tr>
                </table>
                <div id="not_register">לא נרשמת עדיין? <a href="Register.aspx">הרשמה</a></div>
                <div id="stay">
                    <input type="checkbox" name="stayConn" id="stayConn" />השאר מחובר </div>
                <div id="serverErr"><%=msg %></div>
                <input type="submit" id="loginCheck" name="loginCheck" value="" onmouseover="this.style.background = 'url(images/btn_login_normal.png)'" onmousedown="this.style.background = 'url(images/btn_login_pressed.png)'" onmouseout="this.style.background = 'url(images/btn_login_disabled.png)'" />
            </form>

        </div>
        <div id="goBack"><a href="Main.aspx">→חזור</a></div>
        <div id="copyright">This site was built by Ori.NET in 2013</div>
    </div>

</body>
</html>
