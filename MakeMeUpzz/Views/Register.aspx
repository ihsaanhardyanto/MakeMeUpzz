<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MakeMeUpzz.Views.Register" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Register</title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <h1>Register</h1>
        
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        
        <div>
            <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username"></asp:TextBox>
        </div>
        
        <div>
            <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
        </div>
        
        <div>
            <asp:Label ID="LblDOB" runat="server" Text="Date of Birth"></asp:Label>
            <asp:Calendar ID="calDOB" runat="server"></asp:Calendar>
        </div>
        
        <div>
            <asp:Label ID="LblGender" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:DropDownList>
        </div>
        
        <div>
            <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
        </div>
        
        <div>
            <asp:Label ID="LblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Placeholder="Confirm Password"></asp:TextBox>
        </div>
        
        <div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        </div>
    </div>
</form>
</body>
</html>
