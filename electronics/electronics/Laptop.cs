namespace Electronics
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
