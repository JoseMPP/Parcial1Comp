namespace fcnPar.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Data
    {
        [Key]
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }
        [Required]
        public int Random { get; set; }
    }
}
