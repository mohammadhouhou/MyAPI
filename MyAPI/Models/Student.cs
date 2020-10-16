using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Models
{
    public class Student
    {
        [Key]
        public string Firstname { get; set;}
        public string Lastname { get; set; }
    }
} 
