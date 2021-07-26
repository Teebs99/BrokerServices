using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public int NumberOfUnits { get; set; }
        public bool IsFilled { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(Stock))]
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        [ForeignKey(nameof(Portfolio))]
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
