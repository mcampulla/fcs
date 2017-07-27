using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace fcs.web.Models
{
    [Table("UsersDto")]
    public class User
    {
        public User()
        {
        }

        [Key]
        [Display(Name = "Id")]
        public Guid UserID { get; set; }

        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
//        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Boolean IsActive { get; set; }

    }
}