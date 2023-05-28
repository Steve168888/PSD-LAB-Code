<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navigation-Customer.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="PSDLab.View.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text="Cart Page"></asp:Label><br />
    <asp:Label ID="custNameLabel" runat="server" Text="Customer Name"></asp:Label>
    <br /><br />
    
    <%--<asp:GridView ID="CartView" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="albumImage">
                <ItemTemplate>
                    <asp:Image ID="ImageControl" runat="server" ImageUrl='<%# Eval("albumImage") %>' width="200" Height="200"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>

    <table border="1">
        <tr align="left">
            <th>Album Name</th>
            <th>Album Image</th>
            <th>Album Price</th>
            <th>Quantity</th>
            
        </tr>

        <%foreach (var (a, c) in listAlbum.Zip(albumQty, (a, b) => (a, b))) { %>

        <tr align="left">
            <th><%= a.albumName %></th>
            <th><img src='<%= a.albumImage%>' alt="Album Image" width="100" height="100"/></th>
            <th><%= a.albumPrice %></th>
            <th><%= c.Qty %></th>
        </tr>
        <%    } %>
       
    </table>

</asp:Content>
