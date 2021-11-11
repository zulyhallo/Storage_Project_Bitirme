using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class Members
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Role { get; set; }
    }
}
