<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page4.aspx.cs" Inherits="LAB5.page4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  rel="stylesheet" type="text/css" href="Content/Site.css?Version=1">
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <!-- <asp:Label ID="L1" runat="server" Text="Сторінка привітання з успішною реєстрацією або повідомлення про помилку"></asp:Label>-->
            <asp:Label ID="L2" runat="server" Text="РЕЄСТРАЦІЮ УСПІШНО ЗАВЕРШЕНО!" ForeColor="green"></asp:Label> <br /> <br />
            <asp:Button ID="B1" runat="server" Text="НА ГОЛОВНУ" OnClick="B1_Click" />

            
       <script src='<%=ResolveClientUrl("~/JavaScript.js") %>' type="text/javascript"></script>
        </div>
    </form>
</body>
</html>
