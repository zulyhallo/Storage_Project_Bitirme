using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Storage.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileHash { get; set; }
        public DateTime Date { get; set; }


    }
}
