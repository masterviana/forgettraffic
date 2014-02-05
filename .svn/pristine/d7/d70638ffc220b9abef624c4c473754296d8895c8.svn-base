using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;

namespace ForgetTraffic.Site.Models
{

    #region Models

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Current password")]
        public string OldPassword { get; set; }

        [Required]

        [DataType(DataType.Password)]
        [DisplayName("New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm new password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Secret Question")]
        public String SecretQuestion { get; set; }

        [Required]
        [DisplayName("Secret Answer")]
        [DataType(DataType.Text)]
        public String SecretAnswer { get; set; }

    }

    public class LogOnModel
    {
        [Required]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [DisplayName("User name")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        public String LoginToken { get; set; }

        [Required]
        [DisplayName("First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Hidden UserName")]
        public bool HidenUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Birth Date")]
        public String BirthDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Secret Question")]
        public String SecretQuestion { get; set; }

        [Required]
        [DisplayName("Secret Answer")]
        [DataType(DataType.Text)]
        public String SecretAnswer { get; set; }

        [DisplayName("Old Password")]
        [DataType(DataType.Text)]
        public String OldPassword { get; set; }

        [DisplayName("Nº Submited Incidents")]
        [DataType(DataType.Text)]
        public int PostIncidents{ get; set; }

        [DisplayName("Nº Validate Incident")]
        [DataType(DataType.Text)]
        public int ValidadeIncidents { get; set; }

        [DisplayName("Nº Invalid Incident")]
        [DataType(DataType.Text)]
        public int InvalideIncident { get; set; }

        [DisplayName("Nº Post Votes")]
        [DataType(DataType.Text)]
        public int PostVotes { get; set; }

        [DisplayName("User Ratio")]
        [DataType(DataType.Text)]
        public int Ratio { get; set; }


    }

    #endregion
}