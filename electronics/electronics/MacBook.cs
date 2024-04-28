using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electronics
{
    internal class MacBook : Laptop
    {
        protected MacBook(string name, string brand)
            : base(name, brand, OS.MacOS)
        {
        }
    }
}
