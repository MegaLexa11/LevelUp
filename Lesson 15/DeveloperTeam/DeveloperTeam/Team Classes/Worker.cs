namespace DeveloperTeam
{
    internal abstract class Worker
    {
        public string Name { get; }

        protected Worker(string name) 
        {
            Name = name;
        }
    }
}
