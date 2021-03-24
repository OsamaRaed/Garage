using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Data.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDelete = false;
        }
    }
}
