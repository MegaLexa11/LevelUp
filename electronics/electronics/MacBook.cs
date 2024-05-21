namespace Electronics
{
    internal class MacBook : Laptop
    {
        protected MacBook(string name, string brand)
            : base(name, brand, OS.MacOS)
        {
        }
    }
}
