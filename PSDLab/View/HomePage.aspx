<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PSDLab.View.HomePage" MasterPageFile="~/View/Navigation-Customer.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Label runat="server" Text="This is Home"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br /><br />
    <% int visitorRole = getVisitorRole(); %>
    <table>
        <tr align="left">
            <th>Artist Name</th>
            <% if (visitorRole == 2) { %>
                <th display="none">Action</th>
            <% } %>
            
        </tr>

        <%foreach (var x in db.Artists) { %>

        <tr align="left">
            <th><a href='<%= ResolveUrl("~/View/ArtistDetail.aspx?artistName=") + HttpUtility.UrlEncode(x.artistName) %>'><%= x.artistName%></a></th>

            <% if (visitorRole == 2) { %>
                <th><a href='<%= ResolveUrl("~/View/EditArtist.aspx?artistName=") + HttpUtility.UrlEncode(x.artistName) %>'>Edit</a></th>
            <% } %>
        </tr>
        <%    } %>
       
    </table>
    <br /><br />
    <asp:Button ID="addArtistBtn" runat="server" Text="Add Artist" OnClick="addArtistBtn_Click"/>

</asp:Content>
