using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMascot.Models
{
    public class Mascot
    {
        public int ID { get; set; }
        public string MascotName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateBegan { get; set; }
        public string School { get; set; }
        public decimal Salary { get; set; }
    }
}