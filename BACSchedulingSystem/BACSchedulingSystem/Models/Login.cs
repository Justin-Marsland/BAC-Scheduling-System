using System;
using System.ComponentModel.DataAnnotations;


namespace BACSchedulingSystem.Models
{
    public class Login
    {
        public string username { get; set; }
        [Key]
        public string email { get; set; }
    }
}