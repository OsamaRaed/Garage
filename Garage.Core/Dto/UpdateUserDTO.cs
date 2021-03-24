using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Dto
{
    public class UpdateUserDTO
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DOB { get; set; }
    }
}
