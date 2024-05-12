using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics
{
    internal class PC : Computer
    {
        public override  OS OperationSystem { get; }

        public override ComputerType ComputerType => ComputerType.PC;

        protected PC(string name, string brand, OS operationSystem)
            : base(name, brand)
        {
            OperationSystem = operationSystem;
        }
    }
}
