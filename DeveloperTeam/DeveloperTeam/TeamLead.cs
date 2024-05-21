using System.ComponentModel;

namespace DeveloperTeam
{
    internal class TeamLead : Worker
    {
        public TeamLead(string name) 
            : base(name)
        {
            
        }

        public override string ToString()
        {
            return $"{Name}, {typeof(TeamLead).Name}";
        }
    }
}
