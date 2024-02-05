using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB5
{
    public partial class page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //На сторінку 2 можно потрапити тільки зі сторінки 1 (якщо натиснено РЕЄСТРАЦІЯ).

            try
            {
                if (Request.UrlReferrer.OriginalString.Contains("/page1") && page1.RegSubmitted)
                {
                    page1.RegSubmitted = false;

                    new List<String> { "1 курс", "2 курс", "3 курс", "4 курс", "5 курс", "6 курс" }
                    .ForEach(x => DropDownList1.Items.Add(x));
                    new List<String> { "Механіко-математичний", "Радіофізичний", "Геологічний", "Історичний", "Філософський" }
                    .ForEach(x => DropDownList2.Items.Add(x));
                    new List<String> { "Наукова бібліотека", "Ботанічний сад", "Інформаційно-обчислювальний центр", "Ректорат" }
                    .ForEach(x => DropDownList3.Items.Add(x));
                }
            }
            catch
            {
                Response.Redirect("~/page1.aspx");
            }
        }

        static bool ValidEmail(string email) => new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").IsMatch(email); protected void B3_Click(object sender, EventArgs e)
        {
            //Далі
            page1.pause();
            Lerror.Text = "";

            //EMPTY FIELD CHECKER
            if (
                //                || FileUpload1.FileName.Trim().Length == 0
                TextBox3.Text.Trim().Length == 0 ||
                TextBox4.Text.Trim().Length == 0 ||
                TextBox5.Text.Trim().Length == 0 ||
                TextBox6.Text.Trim().Length == 0 ||
                TextBox7.Text.Trim().Length == 0 ||
                TextBox7_2.Text.Trim().Length == 0
                )
            { Lerror.Text += "Found Empty fields. \n\r"; return; }

            //EMAIL CHECKER
            if (!ValidEmail(TextBox6.Text.Trim()))
            { Lerror.Text += "Not valid email. \n\r"; return; }

            //IMAGE CHECKER
            if (FileUpload1.HasFile)
            {
                string strpath = FileUpload1.PostedFile.FileName;
                if (!strpath.Contains(".jpg") && !strpath.Contains(".jpeg") && strpath.Contains(".gif")&& strpath.Contains(".png"))
                { Lerror.Text += "Not image added. \n\r"; return; } }

            //Password checker
            if (TextBox7.Text.Trim() != TextBox7_2.Text.Trim())
            { Lerror.Text += "Passwords are different. \n\r"; return; }

            //USER CHECKER
            if (IsUserExists(TextBox5.Text.Trim(), TextBox7.Text.Trim()))
            { Lerror.Text += "User already exists. \n\r"; return; }


            //MakeUserInfo
            User.name = TextBox3.Text.Trim(); UserInfo.name = User.name;
            User.surname = TextBox4.Text.Trim(); UserInfo.surname = User.surname;
            User.login = TextBox5.Text.Trim(); UserInfo.login = User.login;
            User.email = TextBox6.Text.Trim(); UserInfo.email = User.email;
            UserInfo.password = TextBox7.Text;             
            UserInfo.status = RadioButtonList1.SelectedValue;             
            UserInfo.Master = CheckBoxList1.Items.FindByValue("ms").Selected ? 1 : 0;             
            UserInfo.Canditate = CheckBoxList1.Items.FindByValue("kn").Selected ? 1 : 0;             
            UserInfo.Doctor = CheckBoxList1.Items.FindByValue("dn").Selected ? 1 : 0;
            UserInfo.Curs = DropDownList1.Text;
            UserInfo.Faculty = DropDownList2.Text;
            UserInfo.Structure = DropDownList3.Text;
            FileUpload1.PostedFile.SaveAs(@"C:\knu\spz\5\LAB5\LAB5\assets\temp.png");


            Response.Redirect("~/page3.aspx");
        }

        protected void B4_Click(object sender, EventArgs e)
        {
            //Назад
            page1.pause();
            Response.Redirect("~/page1.aspx");
        }

        public static bool IsUserExists(string username, string password)
        {
            List<String> Users = new List<string> { };
            string Query = $"SELECT * FROM Users WHERE Login = N'{username}' AND Password = N'{password}'";
            string DB = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=webserver; Integrated Security=true";
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                Conn.Open();
                using (SqlCommand cmd = new SqlCommand(Query, Conn))
                using (SqlDataReader read = cmd.ExecuteReader())  // reader based on comand-object
                {
                    while (read.Read()) //go every line of table
                        Users.Add((read["Name"].ToString()));
                }
            }
            if (Users.Count >= 1) return true;
            return false;
        }

        public static void InsertSQL()
        {
            string DB = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=webserver; Integrated Security=true";
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                Conn.Open();
                string insertQuery = $@"
                                    INSERT INTO Users (Login, Name, Surname, Email, Status, Master, Candidate, Doctor, Curs, Faculty, Structure, Password)
                                    VALUES
                                        (N'{User.login}', N'{User.name}', N'{User.surname}', N'{User.email}', N'{UserInfo.status}', 
                                            {UserInfo.Master}, {UserInfo.Canditate}, {UserInfo.Doctor},N'{UserInfo.Curs}',N'{UserInfo.Faculty}', N'{UserInfo.Structure}', N'{UserInfo.password}')";
                // Made object cmd for executing scripts
                using (SqlCommand cmd = new SqlCommand(insertQuery, Conn))
                {
                    int rowsAffected = cmd.ExecuteNonQuery(); // Execute SQL-script
                }
            }
        }


        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            L1.Text = RadioButtonList1.SelectedValue;
            switch (RadioButtonList1.SelectedValue)
            {
                case "st":
                    CheckBoxList1.Items.FindByValue("ms").Selected = true;
                    CheckBoxList1.Items.FindByValue("kn").Selected = false;
                    CheckBoxList1.Items.FindByValue("dn").Selected = false;
                    DropDownList1.Enabled = true;
                    DropDownList2.Enabled = true;
                    DropDownList3.Enabled = false;
                    break;
                case "vi":
                    CheckBoxList1.Items.FindByValue("ms").Selected = true;
                    CheckBoxList1.Items.FindByValue("kn").Selected = true;
                    CheckBoxList1.Items.FindByValue("dn").Selected = true;
                    DropDownList1.Enabled = false;
                    DropDownList2.Enabled = true;
                    DropDownList3.Enabled = false;
                    break;
                case "nd":
                    CheckBoxList1.Items.FindByValue("ms").Selected = true;
                    CheckBoxList1.Items.FindByValue("kn").Selected = true;
                    CheckBoxList1.Items.FindByValue("dn").Selected = false;
                    DropDownList1.Enabled = false;
                    DropDownList2.Enabled = false;
                    DropDownList3.Enabled = true;
                    break;
            }
        }

        public static class User {
            public static string name = "";
            public static string surname = "";
            public static string login = "";
            public static string email = "";
        }
        public static class UserInfo 
        {

            public static string name = "";
            public static string surname = "";
            public static string login = "";
            public static string email = "";

            public static string password = "";
            public static string status = "";
            public static int Master = 0;
            public static int Canditate = 0;
            public static int Doctor = 0;
            public static string Curs = "";
            public static string Faculty = "";
            public static string Structure = "";
        }
    }
}