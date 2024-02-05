<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="LAB5.page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  rel="stylesheet" type="text/css" href="Content/Site.css?Version=1">
</head>
<body>
    <form id="form1" runat="server" >
        <div>
           <!-- <asp:Label ID="L1" runat="server" Text="Стартова сторінка з кнопками ВХІД і РЕЄСТРАЦІЯ"></asp:Label><br/>-->
            <asp:Label ID="L2" runat="server" Text="САЙТ З АВТОРИЗОВАНИМ ДОСТУПОМ"></asp:Label><br/>
            <asp:Label ID="L3" runat="server" Text="ЛОГІН:"></asp:Label><br/>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br/>
            <asp:Label ID="L4" runat="server" Text="ПАРОЛЬ:"></asp:Label><br/>
            <asp:TextBox ID="TextBox2" TextMode="Password"  runat="server"></asp:TextBox><br/>
            <asp:Label ID="Lerror" runat="server" Text="" ForeColor="Red"></asp:Label> <br />
            <asp:Button ID="B1" runat="server" Text="ВХІД" OnClick="B1_Click" /><br />
            <asp:Button ID="B2" runat="server" Text="РЕЄСТРАЦІЯ" OnClick="B2_Click" /><br />
       <script src='<%=ResolveClientUrl("~/JavaScript.js") %>' type="text/javascript"></script>
        </div>
    </form>
</body>
</html>
