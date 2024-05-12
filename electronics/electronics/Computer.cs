using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics
{
    internal abstract class Computer : ProductItem
    {
        public abstract OS OperationSystem { get; }

        public abstract ComputerType ComputerType { get; }

        public override ElectronicsType Type => ElectronicsType.Computer;

        protected Computer(string name, string brand)
            :base(name, brand)
        {
        }
    }
}
