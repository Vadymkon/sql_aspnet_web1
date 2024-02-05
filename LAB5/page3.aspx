<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page3.aspx.cs" Inherits="LAB5.page3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  rel="stylesheet" type="text/css" href="Content/Site.css?Version=1">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--<asp:Label ID="L1" runat="server" Text="Сторінка верифікації його Емейл-адреси"></asp:Label> <br />-->
            <asp:Label ID="L2" runat="server" Text="ВЕРИФІКАЦІЯ АДРЕСИ ЕЛЕКТРОННОЇ ПОШТИ"></asp:Label> <br /> <br />
            <asp:Label ID="L3" runat="server" Text="На Вашу адресу направлений одноразовий пароль."></asp:Label> <br />
            <asp:Label ID="L4" runat="server" Text="Введіть його в поле і натисніть 'ДАЛІ':"></asp:Label> <br /><br />
            <asp:Label ID="Lerror" runat="server" Text="" ForeColor="Red"></asp:Label> <br /><br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="B1" runat="server" Text="ЗАРЕЄСТРУВАТИ" OnClick="B1_Click" />
            <asp:Button ID="B2" runat="server" Text="НАЗАД" OnClick="B2_Click" />
        
            
       <script src='<%=ResolveClientUrl("~/JavaScript.js") %>' type="text/javascript"></script>
        </div>
    </form>
</body>
</html>
