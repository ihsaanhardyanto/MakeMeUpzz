<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MakeMeUpzz.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_login" runat="server">
        <h1>Login Page</h1>
        <div>
            <asp:Label ID="label_username" runat="server" Text="Label">Username :</asp:Label>
            <asp:TextBox ID="login_username" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="label_password" runat="server" Text="Label">Password :</asp:Label>
            <asp:TextBox ID="login_password" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:CheckBox ID="checkRememberMe" runat="server" Text="Remember Me" />
         </div>
         
        <asp:Button ID="login_submit" runat="server" Text="Login" />
    </form>
    
       <p>Don't have an account? <a href="/Register">Register here</a>.</p>
</body>
</html>
