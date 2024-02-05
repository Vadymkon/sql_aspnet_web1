using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB5
{
    public partial class page1 : System.Web.UI.Page
    {
        public static bool RegSubmitted = false, 
                            InSubmitted = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             try
            {
                if (Request.UrlReferrer.ToString()!=string.Empty)
                {
            L2.Text = Request.UrlReferrer.OriginalString;
                }
            }
            catch
            {
                
            }
             */
        }

        protected void B1_Click(object sender, EventArgs e)
        {
            InSubmitted = true;
            pause();

            if (TextBox1.Text.Trim().Length == 0
                 || TextBox2.Text.Trim().Length == 0)
            { Lerror.Text = "Found Empty fields"; return; }
            
            if (!page2.IsUserExists(TextBox1.Text.Trim(),TextBox2.Text.Trim()))
            { Lerror.Text = "User Not found"; return; }

            getUserInfo(TextBox1.Text.Trim(), TextBox2.Text.Trim());

            Response.Redirect("~/page5.aspx");
        }

        protected void B2_Click(object sender, EventArgs e)
        {
            RegSubmitted = true;
            pause();
            Response.Redirect("~/page2.aspx");
        }

        public static void pause()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public static bool getUserInfo(string username, string password)
        {
            string Query = $"SELECT * FROM Users WHERE Login = N'{username}' AND Password = N'{password}'";
            string DB = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=webserver; Integrated Security=true";
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                Conn.Open();
                using (SqlCommand cmd = new SqlCommand(Query, Conn))
                using (SqlDataReader read = cmd.ExecuteReader())  // reader based on comand-object
                {
                    while (read.Read()) //go every line of table
                    {
                        page2.User.name = read["Name"].ToString();
                        page2.User.surname = read["Surname"].ToString();
                        page2.User.email = read["Email"].ToString();
                        page2.User.login = read["Login"].ToString();
                    }
                }
            }
            return false;
        }
    }
}