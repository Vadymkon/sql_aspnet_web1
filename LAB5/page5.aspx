<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page5.aspx.cs" Inherits="LAB5.page5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  rel="stylesheet" type="text/css" href="Content/Site.css?Version=1">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--<asp:Label ID="L1" runat="server" Text="Персональна сторінка користувача (профіль користувача)"></asp:Label>-->
            <asp:Label ID="L2" runat="server" Text="Вітаємо Вас на нашому сайті,"></asp:Label> <br />
            <asp:Label ID="L3" runat="server" Text="{name} {surname}!"></asp:Label> <br />
            
            <asp:Image ID="Image1" runat="server" alt="YourPhoto" /> <br />

            <asp:Label ID="L4" runat="server" Text="Логін ..... {login}"></asp:Label> <br />
            <asp:Label ID="L5" runat="server" Text="Е-mail .... {email}"></asp:Label> <br /> <br />

            <asp:Button ID="B1" runat="server" Text="ВИХІД" OnClick="B1_Click" />

            
       <script src='<%=ResolveClientUrl("~/JavaScript.js") %>' type="text/javascript"></script>
        </div>
    </form>
</body>
</html>
