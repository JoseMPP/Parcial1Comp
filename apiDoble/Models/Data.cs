using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiDoble.Models
{
    public class Data
    {
        [Key]
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }
        [Required]
        public int Random { get; set; }
    }
}
