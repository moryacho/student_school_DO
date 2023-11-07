using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    public class DbOrders
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid PickUpPointId { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }

    }
}