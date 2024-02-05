using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB5
{
    public partial class page3 : System.Web.UI.Page
    {
        static String password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //На сторінку 3 можно потрапити тільки зі сторінки 2.

            try
            {
                if (Request.UrlReferrer.OriginalString.Contains("/page2"))
                {
                    password = GeneratePassword();
                    SmtpClient C = new SmtpClient("smtp.gmail.com");
                    C.Port = 587;
                    C.Credentials = new NetworkCredential("vadykakonon", "pitqhauddgybnhzz");
                    C.EnableSsl = true;
                    //to address ; title
                    C.Send(new MailMessage("vadykakonon@gmail.com", page2.User.email, password, $"Password:\n{password}\n"));
                    Lerror.Text = password;
                }
            }
            catch
            {
                Response.Redirect("~/page2.aspx");
            }
        }

        protected void B2_Click(object sender, EventArgs e)
        {
            //Назад
            page1.pause();
            Response.Redirect("~/page2.aspx");
        }

        public static bool codenorm = true;
        protected void B1_Click(object sender, EventArgs e)
        {
            //Регістрація
            page1.pause();

            if (TextBox1.Text.Trim().Length == 0)
            { Lerror.Text = "Found Empty fields"; return; }
            
            if (password != TextBox1.Text.Trim())
            { L2.Text = $"'{password}' != '{TextBox1.Text.Trim()}'"; page1.pause();
                    codenorm = false; Response.Redirect("~/page4.aspx"); return; }

            page2.InsertSQL();
            File.Move($@"C:\knu\spz\5\LAB5\LAB5\assets\temp.png", $@"C:\knu\spz\5\LAB5\LAB5\assets\{page2.User.login}.png");
            codenorm = true;

            Response.Redirect("~/page4.aspx");

        }

        static string GeneratePassword()
        {
            string allCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] passwordArray = new char[6];

            for (int i = 0; i < 6; i++)
            {
                passwordArray[i] = allCharacters[random.Next(allCharacters.Length)];
            }

            return new string(passwordArray);
        }

       
    }
}