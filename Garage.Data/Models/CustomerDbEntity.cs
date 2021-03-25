using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Data.Models
{
    public class CustomerDbEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<CarDbEntity> Cars{ get; set; }
    }
}
