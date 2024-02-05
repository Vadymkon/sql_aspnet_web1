using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB5
{
    public partial class page5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //На сторінку 5 можно потрапити тільки зі сторінки 1 (якщо натиснено ВХІД).

            try
            {
                if (Request.UrlReferrer.OriginalString.Contains("/page1") && page1.InSubmitted)
                {
                    if (File.Exists($@"C:\knu\spz\5\LAB5\LAB5\assets\{page2.User.login}.png")) 
                        Image1.ImageUrl = $@"http://localhost:56857/assets/{page2.User.login}.png";
                    else 
                        Image1.ImageUrl = $@"http://localhost:56857/assets/default.png";
                    L3.Text = L3.Text.Replace("{name}", page2.User.name).Replace("{surname}", page2.User.surname);
                    L4.Text = L4.Text.Replace("{login}", page2.User.login);
                    L5.Text = L5.Text.Replace("{email}", page2.User.email);
                    page1.InSubmitted = false;
                }
            }
            catch
            {
                Response.Redirect("~/page1.aspx");
            }
        }

        protected void B1_Click(object sender, EventArgs e)
        {
            page1.pause();
            Response.Redirect("~/page1.aspx");
        }
    }
}