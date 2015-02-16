using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaharaChat.Models
{
    public class CreateAccountViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
        public bool SamePassword { get { return Password == RepeatPassword; } }
    }
}