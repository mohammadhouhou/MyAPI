using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string Name { get; set; }
    }
}
