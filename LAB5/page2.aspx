<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="LAB5.page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  rel="stylesheet" type="text/css" href="Content/Site.css?Version=1">
</head>
<body>
    <form id="form1" runat="server">
        <div >
            <!--<asp:Label ID="L1" runat="server" Text="Сторінка реєстрації користувача"></asp:Label>-->
            <asp:Label ID="L2" runat="server" Text="ФОТОГРАФІЯ (JPEG/PNG, min 100x150, max 200x300):"></asp:Label>
          <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br/>
            <br/>
           
            <asp:Label ID="L3" runat="server" Text="ІМ'Я:"></asp:Label> <br />
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>  <br />
            <asp:Label ID="L4" runat="server" Text="ПРІЗВИЩЕ:"></asp:Label>  <br />
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>  <br />
           
            <asp:Label ID="L5" runat="server" Text="Логін:"></asp:Label>  <br />
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox> <br />
            <asp:Label ID="L6" runat="server" Text="E-mail:"></asp:Label> <br />
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>  <br />

            <asp:Label ID="L7" runat="server" Text="Пароль:"></asp:Label>  <br />
                <asp:TextBox ID="TextBox7" TextMode="Password" runat="server"></asp:TextBox>  
                <asp:TextBox ID="TextBox7_2" TextMode="Password" runat="server"></asp:TextBox>  <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" onclick="handleRadioChange()" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Enabled="True" Selected="False" Value="st" Text="Студент" />
                <asp:ListItem Enabled="True" Selected="True" Value="vi" Text="Викладач" />
                <asp:ListItem Enabled="True" Selected="False" Value="nd" Text="Навчально-допоміжний персонал" />
            </asp:RadioButtonList>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="False" Value="ms" Text="Майстер спорту" />
                <asp:ListItem Selected="False" Value="kn" Text="Кандидат наук" />
                <asp:ListItem Selected="False" Value="dn" Text="Доктор наук" />
            </asp:CheckBoxList>
            
            <br />
            <asp:Label ID="L8" runat="server" Text="Курс:"></asp:Label>  <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Enabled="false">
            </asp:DropDownList> <br />

            <asp:Label ID="L9" runat="server" Text="Факультет:"></asp:Label>  <br />
            <asp:DropDownList ID="DropDownList2" runat="server" Enabled="true">
            </asp:DropDownList> <br />
            <asp:Label ID="L10" runat="server" Text="Структурний підрозділ:"></asp:Label>  <br />
            <asp:DropDownList ID="DropDownList3" runat="server" Enabled="false">
            </asp:DropDownList> <br />

            <asp:Label ID="Lerror" runat="server" Text="" ForeColor="Red"></asp:Label>  <br />
            <asp:Button ID="B3" runat="server" Text="Далі" OnClick="B3_Click" />
            <asp:Button ID="B4" runat="server" Text="Назад" OnClick="B4_Click" />

            
       <script src='<%=ResolveClientUrl("~/JavaScript.js") %>' type="text/javascript"></script>
        </div>
    </form>
</body>
</html>
