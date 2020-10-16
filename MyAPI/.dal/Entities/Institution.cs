using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.dal.Entities
{
    public class Institution
    {
        [Key]
        public string name { get; set; }
        public int id { get; set; }


    }
}
