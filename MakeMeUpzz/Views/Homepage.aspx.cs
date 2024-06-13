using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    public partial class HomePage : System.Web.UI.Page
    {
        UserRepository userRepo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            customerDataLbl.Visible = false;
            customerGrid.Visible = false;


            if (Session["user"] == null && Request.Cookies["user_cookies"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    var id = Request.Cookies["user_cookies"].Value;
                    user = userRepo.GetUserByID(int.Parse(id));
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }
                lblRole.Text = user.UserRole;
                lblName.Text = user.Username;

                if (user.UserRole == "admin")
                {
                    customerDataLbl.Visible = true;
                    customerGrid.Visible = true;

                    List<User> users = userRepo.GetAllUser();

                    customerGrid.DataSource = users;
                    customerGrid.DataBind();

                }
            }
        }
    }
}