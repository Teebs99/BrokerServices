using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OrderDetail
    {
        public Stock OrderedStock { get; set; }
        public OrderType TypeOfOrder { get; set; }
        public int NumberOfUnits { get; set; }
        public bool IsFilled { get; set; }

    }
}
