<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="PSDLab.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Register Page"></asp:Label><br /><br />

            <asp:Label ID="Label5" runat="server" Text="Name :"></asp:Label><br />
            <asp:TextBox ID="nameBox" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="Label2" runat="server" Text="Email :"></asp:Label><br />
            <asp:TextBox ID="emailBox" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="Label6" runat="server" Text="Gender :"></asp:Label><br />
            <asp:RadioButtonList ID="GenderRadio" runat="server">
                <asp:ListItem Text="Male" Value="male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="female"></asp:ListItem>
            </asp:RadioButtonList>

            <asp:Label ID="Label7" runat="server" Text="Address :"></asp:Label><br />
            <asp:TextBox ID="addressBox" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="Label3" runat="server" Text="Password :"></asp:Label><br />
            <asp:TextBox ID="passBox" TextMode="Password" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="registerBtn" runat="server" Text="Login" OnClick="registerBtn_Click"/><br /><br />
            <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label><br />
        </div>
    </form>
</body>
</html>
