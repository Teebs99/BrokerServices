using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CreateOrder
    {
        [Required]
        public OrderType OrderType { get; set; }
        [Required]
        public string TickerSymbol { get; set; }
        [Required]
        public int NumberOfUnits { get; set; }
    }
}
