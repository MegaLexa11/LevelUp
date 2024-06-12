namespace DeveloperTeam
{
    internal abstract class Engineer : Worker
    {
        public Level Level { get;  }

        protected Engineer(string name, Level level)
            : base(name)
        {
            Level = level;
        }
    }
}
