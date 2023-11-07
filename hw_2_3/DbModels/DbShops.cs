using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels
{
    public class DbShops
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerInfo { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}