using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsersManager.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string LastName { get; set; }
    }
}