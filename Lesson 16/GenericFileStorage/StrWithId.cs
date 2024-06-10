namespace GenericFileStorage
{
    internal class StrWithId: IContainsId<String>
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Value { get; }

        public StrWithId(string value)
        {
            Value = value;
        }
    }
}
