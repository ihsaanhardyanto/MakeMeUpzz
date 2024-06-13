using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class Login : System.Web.UI.Page
    {
        UserRepository userRepo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            label_message.Visible = false;
        }

        protected void login_submit_Click(object sender, EventArgs e)
        {
            string username = login_username.Text;
            string password = login_password.Text;
            bool isRemember = checkRememberMe.Checked;

            bool isAuthenticated = userRepo.Verification(username, password);

            if (string.IsNullOrEmpty(username))
            {
                showMessage("Username cannot be empty!");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                showMessage("Password cannot be empty!");
                return;
            }

            if (isAuthenticated)
            {
                var user = userRepo.GetUserByUsername(username);
                Session["user"] = user;

                if (isRemember)
                {
                    HttpCookie cookie = new HttpCookie("user_cookies");
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(5);
                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("HomePage.aspx");
            }
            else
            {
                showMessage("Invalid email or password!");
                return;
            }
        }

        private void showMessage(string msg)
        {
            label_message.Visible = true;
            label_message.Text = msg;
        }
    }
}