namespace Electronics
{
    internal class Monoblock : Computer
    {
        public override OS OperationSystem { get; }

        public override ComputerType ComputerType => ComputerType.Laptop;

        protected Monoblock(string name, string brand, OS operationSystem)
            : base(name, brand)
        {
            OperationSystem = operationSystem;
        }
    }
}
