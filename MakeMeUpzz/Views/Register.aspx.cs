using MakeMeUpzz.Controllers;
using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class Register : Page
    {
        UserRepository userRepo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            LblMessage.Visible = false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string response = UserController.CheckUsername(txtUsername.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showMessage(response);
                return;
            }

            response = UserController.CheckEmail(txtEmail.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showMessage(response);
                return;
            }

            response = UserController.CheckDOB(txtDOB.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showMessage(response);
                return;
            }
            if (!DateTime.TryParse(txtDOB.Text, out DateTime newDOB))
            {
                showMessage("Invalid date format. Please use yyyy-MM-dd.");
                return;
            }

            response = UserController.CheckGender(btnMale.Checked, btnFemale.Checked);
            if (!string.IsNullOrEmpty(response))
            {
                showMessage(response);
                return;
            }

            response = UserController.CheckPassword(txtPassword.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showMessage(response);
                return;
            }

            response = UserController.CheckConfirmPassword(txtConfirmPassword.Text, txtPassword.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showMessage(response);
                return;
            }


            int newId = userRepo.GenerateNewUserId();
            String newUsername = txtUsername.Text;
            String newEmail = txtEmail.Text;
            String newGender = btnMale.Checked ? btnMale.Text : btnFemale.Text;
            String newPassword = txtPassword.Text;
            String newRole = "Customer";

            User user = UserRegisterFactory.CreateUser(newId, newUsername, newEmail, newDOB, newGender, newRole, newPassword);
            userRepo.AddNewUser(user);
            Response.Redirect("Login.aspx");
        }

        private void showMessage(string msg)
        {
            LblMessage.Visible = true;
            LblMessage.Text = msg;
        }
    }
}
