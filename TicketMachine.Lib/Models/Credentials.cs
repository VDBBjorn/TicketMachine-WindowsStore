using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMachine.Lib.Models
{
    public class Credentials
    {
        public string CustomerId { get; set; }
        public string Password { get; set; }
        public bool Remeber { get; set; }

        public Credentials(decimal customerId, string password, bool remeber)
        {
            CustomerId = customerId.ToString();
            Password = password;
            Remeber = remeber;
        }
    }
}
