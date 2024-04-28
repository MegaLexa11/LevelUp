namespace DeveloperTeam
{
    internal abstract class Worker
    {
        public string Name { get; }
        public abstract Position Position { get; }

        protected Worker(string name) 
        {
            Name = name;
        }
    }
}
