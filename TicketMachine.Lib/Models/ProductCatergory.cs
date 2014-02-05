using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicketMachine.Lib.Models
{
    public class ProductCatergory
    {
        public ProductCatergory(String aName, Double aCost)
        {
            Name = aName;
            Cost = aCost;
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private Double cost;
        public Double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
    }
}
