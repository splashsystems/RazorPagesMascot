using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMascot.Models
{
    public class Mascot
    {
        public int ID { get; set; }
        public string MascotName { get; set; }

        [Display(Name = "Date Began")]
        [DataType(DataType.Date)]
        public DateTime DateBegan { get; set; }
        public string School { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }
    }
}