<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="MakeMeUpzz.Views.ProfilePage"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <!-- Bagian Informasi Profile-->
    <h2>Profile Information</h2>
    <div>
        <asp:Label ID="label_Username" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="label_Email" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="label_Gender" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButton ID="rad_Male" runat="server" Text="Male" GroupName="gender"/>
        <asp:RadioButton ID="rad_Female" runat="server" Text="Female" GroupName="gender"/>
    </div>

    <div>
        <asp:Label ID="label_DOB" runat="server" Text="Date of Birth"></asp:Label>
        <asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="label_messageProfile" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <asp:Button ID="btnSubmit" runat="server" Text="Edit Profile" OnClick="btnSubmit_Click"/>

    <div>
    </div>

    <!-- Bagian Ganti Password-->
    <h2>Change Password</h2>

    <div>
        <asp:Label ID="label_OldPass" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="label_NewPass" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    

    <div>
        <asp:Label ID="label_messageProfile2" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
    </div>

    <div>
        <asp:Button ID="btnchangePass" runat="server" Text="Change Password"  OnClick="btnChangePass_Click"/>
    </div>
</asp:Content>