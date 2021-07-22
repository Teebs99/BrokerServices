using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum OrderType { Buy, Sell }
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public OrderType OrderType { get; set; }
        [Required]
        public Stock OrderedStock { get; set; }
        public bool IsFilled { get; set; }
    }
}
