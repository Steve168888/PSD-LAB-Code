<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionPage.aspx.cs" Inherits="PSDLab.View.TransactionPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Transaction History</h1>
            <hr />
            <div>
                <table style="width: 1000px" border="1">
                    <tr>
                        <th>Transaction ID</th>
                        <th>Transaction Date</th>
                        <th>Customer Name</th>
                        <th>Album Picture</th>
                        <th>Album Name</th>
                        <th>Album Quantity</th>
                        <th>Album Price</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                  <td style="border: 1px solid black; padding: 5px;"><%# Eval("TransactionId") %></td>
                                  <td style="border: 1px solid black; padding: 5px;"><%# Eval("transactionDate", "{0:dd/MM/yyyy}") %></td>
                                  <td style="border: 1px solid black; padding: 5px;"><%# Eval("customerName") %></td>
                                  <td style="border: 1px solid black; padding: 5px;"><asp:Image runat="server" ImageUrl='<%# Eval("AlbumImage") %>' Width="100px" Height="100px"></asp:Image></td>
                                  <td style="border: 1px solid black; padding: 5px;"><%# Eval("albumName") %></td>
                                  <td style="border: 1px solid black; padding: 5px;"><%# Eval("Qty") %></td>
                                  <td style="border: 1px solid black; padding: 5px;"><%# Eval("albumPrice", "{0:C}") %></td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
