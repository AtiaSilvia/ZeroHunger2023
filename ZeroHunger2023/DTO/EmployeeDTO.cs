using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger2023.DTO
{
    public class EmployeeDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public System.DateTime DateOfBirth { get; set; }

        [Required]
        public string Password { get; set; }
    }
}