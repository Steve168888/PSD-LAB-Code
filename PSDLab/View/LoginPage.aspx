<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PSDLab.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Login Page"></asp:Label><br /><br />

            <asp:Label ID="Label2" runat="server" Text="Email :"></asp:Label><br />
            <asp:TextBox ID="emailBox" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="Label3" runat="server" Text="Password :"></asp:Label><br />
            <asp:TextBox ID="passBox" runat="server" TextMode="Password"></asp:TextBox><br /><br />

            <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"/><br /><br />
            <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label><br />


        </div>
    </form>
</body>
</html>
