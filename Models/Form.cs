using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace AssignmentFormValidation.Models
{
    public class Form
    {
        [Required]
        [RegularExpression(@"^[A-Za-z- .,]+$",ErrorMessage = "Your name can only contain alphabets, dot(.), comma(,), dash(-) and space")]
        [StringLength(50,MinimumLength =3)]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{2}-[0-9]{5}-[1-3]{1}$",ErrorMessage = "You id must be in form XX-XXXXX-X")]
        public string id { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        [EmailValidator("id")]
        public string email { get; set; }

        [Required]
        [StringLength(50,MinimumLength =8)]
        [RegularExpression(@"^.*(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$ %^&*~><.,:;]).*$" ,ErrorMessage = "Your password must contain 1 uppercase letter,1 lower case letter, 1 special character and 1 number")]
        public string password { get; set; }
        [Required]

        [Compare("password")]
        public string confPassword { get; set; }

        [Required]
        [DobValidator]
        public string dob { get; set; }
    }
}