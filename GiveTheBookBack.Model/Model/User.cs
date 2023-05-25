using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }        
        public int AddressRef { get; set; }
        public Address Address { get; set; }
    }
}
