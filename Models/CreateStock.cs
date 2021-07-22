using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CreateStock
    {
        [Required]
        public string TickerSymbol { get; set; }
        public double Price { get; set; }
    }
}
