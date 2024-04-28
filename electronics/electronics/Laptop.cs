using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electronics
{
    internal class Laptop : Computer
    {
        public override OS OperationSystem { get; }

        public override ComputerType ComputerType => ComputerType.Laptop;

        protected Laptop(string name, string brand, OS operationSystem)
            : base(name, brand)
        {
            OperationSystem = operationSystem;
        }
    }
}
