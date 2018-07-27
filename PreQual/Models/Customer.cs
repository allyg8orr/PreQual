using System;
using System.ComponentModel.DataAnnotations;

namespace PreQual.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Display(Name = "Annual Income (£)")]
        public decimal Income { get; set; }
        public string Result { get; set; }
    }
}
