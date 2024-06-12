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
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string gender = ddlGender.SelectedValue;
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            DateTime dateOfBirth;

            if (calDOB.SelectedDate == DateTime.MinValue)
            {
                lblMessage.Text = "Please select a valid date of birth.";
                return;
            }

            dateOfBirth = calDOB.SelectedDate;

            if (password != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match.";
                return;
            }

            if (ValidateInputs(username, email, gender, password))
            {
                // Save the user to the database
                if (RegisterUser(username, email, gender, password, dateOfBirth))
                {
                    lblMessage.Text = "Registration successful!";
                    Response.Redirect("~/Views/Login.aspx");
                }
                else
                {
                    lblMessage.Text = "Registration failed. Please try again.";
                }
            }
        }

        private bool ValidateInputs(string username, string email, string gender, string password)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 5 || username.Length > 15)
            {
                lblMessage.Text = "Username must be between 5 and 15 characters.";
                return false;
            }

            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                lblMessage.Text = "Enter the valid email";
                return false;
            }

            if (string.IsNullOrEmpty(gender))
            {
                lblMessage.Text = "Gender must be selected.";
                return false;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 5)
            {
                lblMessage.Text = "Password must be at least 5 characters long.";
                return false;
            }   

            return true;
        }

        private bool RegisterUser(string username, string email, string gender, string password, DateTime dateOfBirth)
        {
            try
            {
                // Add database registration logic here
                // This is a placeholder for actual database interaction code
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
    }
}
