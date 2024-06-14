using MakeMeUpzz.Controllers;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        private readonly UserRepository _userRepo = new UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
            }
        }

        private void LoadUserProfile()
        {
            User user = Session["user"] as User;
            if (user != null)
            {
                User currentUser = _userRepo.GetUserByID(user.UserID);
                if (currentUser != null)
                {
                    PopulateUserProfile(currentUser);
                }
            }
            else
            {
                Response.Redirect("~/View/Login.aspx");
            }
        }

        private void PopulateUserProfile(User user)
        {
            txtUsername.Text = user.Username;
            txtEmail.Text = user.UserEmail;
            rad_Male.Checked = user.UserGender == "Male";
            rad_Female.Checked = user.UserGender != "Male";
            txtDOB.Text = user.UserDOB.ToString("yyyy-MM-dd");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            label_messageProfile.Visible = true;
            User user = Session["user"] as User;
            if (user == null)
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            string response = ValidateUserInput();
            if (!string.IsNullOrEmpty(response))
            {
                DisplayMessage(response);
                return;
            }

            if (UpdateUserProfile(user))
            {
                label_messageProfile.Text = "Success!";
            }
            else
            {
                label_messageProfile.Text = "Invalid date format. Please enter a valid date.";
            }
        }

        private string ValidateUserInput()
        {
            string response = UserController.CheckUsername(txtUsername.Text);
            if (!string.IsNullOrEmpty(response)) return response;

            response = UserController.CheckEmail(txtEmail.Text);
            if (!string.IsNullOrEmpty(response)) return response;

            response = UserController.CheckGender(rad_Male.Checked, rad_Female.Checked);
            if (!string.IsNullOrEmpty(response)) return response;

            response = UserController.CheckDOB(txtDOB.Text);
            return response;
        }

        private bool UpdateUserProfile(User user)
        {
            int userId = user.UserID;
            User updatedUser = _userRepo.GetUserByID(userId);

            string updatedName = txtUsername.Text;
            string updatedEmail = txtEmail.Text;
            string updatedGender = rad_Male.Checked ? "Male" : "Female";
            string updatedPassword = user.UserPassword;
            string updatedRole = user.UserRole;
            if (DateTime.TryParse(txtDOB.Text, out DateTime updatedDOB))
            {
                _userRepo.ModifyUserData(userId, updatedName, updatedEmail, updatedDOB, updatedGender, updatedRole, updatedPassword);
                return true;
            }
            return false;
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            label_messageProfile2.Visible = true;
            User user = Session["user"] as User;
            if (user == null)
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (ChangeUserPassword(user))
            {
                label_messageProfile2.Text = "Successfully changed your password!";
            }
        }

        private bool ChangeUserPassword(User user)
        {
            string oldPassword = txtOldPass.Text;
            string newPassword = txtNewPass.Text;

            if (oldPassword != user.UserPassword)
            {
                label_messageProfile2.Text = "Your old password is incorrect!";
                return false;
            }

            _userRepo.ModifyUserPass(user.UserID, newPassword);
            return true;
        }

        private void DisplayMessage(string message)
        {
            label_messageProfile.Visible = true;
            label_messageProfile.Text = message;
        }
    }
}
