namespace DeveloperTeam
{
    internal class TeamLead : Worker
    {
        public override Position Position => Position.TeamLead;
        public TeamLead(string name) 
            : base(name)
        {
            
        }

        public override string ToString()
        {
            return $"{Name}, {Position}";
        }
    }
}
