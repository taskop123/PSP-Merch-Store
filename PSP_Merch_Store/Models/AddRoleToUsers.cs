using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSP_Merch_Store.Models
{
    public class AddRoleToUsers
    {
        public List<String> Users_Emails { get; set; }
        [Display(Name = "Избери улога")]
        public string SelectedRole { get; set; }
        public List<String> Roles { get; set; }
        [Display(Name = "Избери корисник")]
        public string SelectedUserEmail { get; set; }
        public AddRoleToUsers()
        {
            Users_Emails = new List<string>();
            Roles = new List<string>();
        }
    }
}