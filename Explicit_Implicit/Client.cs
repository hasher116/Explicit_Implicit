using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explicit_Implicit
{
    class Client : Person
    {
        public string Bank { get; set; }
        public Client(string name, string bank)
            : base (name)
        {
            Bank = bank;
        }
    }
}
