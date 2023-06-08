using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models
{
    public class Admin
    {
        [Required]
        public int Id { get; set; }

        // required min length 5 char and string only

        [Required]
        [MinLength(5)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Name { get; set; }

        //email validation
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^01\d{9}$")]
        public string Phone { get; set; }
    }
}
