using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public double Cash { get; set; }
        public double Value { get; set; }

        public virtual Dictionary<Stock, int> Positions { get; set; } = new Dictionary<Stock, int>();
        public virtual List<Order> Orders { get; set; } = new List<Order>();

    }
}
