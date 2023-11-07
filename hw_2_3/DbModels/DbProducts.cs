using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    public class DbProducts
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ShopId { get; set; }
        public int QuantityStock { get; set; }
        public Guid StockId { get; set; }
    }
}