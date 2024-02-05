using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB5
{
    public partial class page4 : System.Web.UI.Page
    {

        static int numb = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
            //На сторінку 4 можно потрапити тільки зі сторінки 3.

            try
            {
                if (Request.UrlReferrer.OriginalString.Contains("/page3"))
                {
                    if (!page3.codenorm)
                    {
                        L2.Text = "ПОМИЛКА РЕЄСТРАЦІЇ!";
                        L2.ForeColor = System.Drawing.Color.Red;
                        page1.InSubmitted = false;
                        numb = 3;
                    }
                    else
                    {
                        L2.Text = "РЕЄСТРАЦІЮ УСПІШНО ЗАВЕРШЕНО! " + page2.User.name;
                        L2.ForeColor = System.Drawing.Color.Green;
                        page1.InSubmitted = true;
                        numb = 1;
                    }
                }
            }
            catch
            {
                Response.Redirect("~/page3.aspx");
            }
        }
        protected void B1_Click(object sender, EventArgs e)
        {
            //На головну
            page1.pause();
            Response.Redirect($"~/page{numb}.aspx");
        }
    }
}