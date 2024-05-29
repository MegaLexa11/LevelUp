namespace DeveloperTeam
{
    internal class Team
    {
        public TeamLead TeamLead { get; }

        public List<Worker> Workers { get; } = new List<Worker>();

        public Team(TeamLead teamLead, IEnumerable<Worker> workers) 
        {
            TeamLead = teamLead;
            Workers.AddRange(workers);
        }

        public void AddWorker(Worker worker) 
        {
            Workers.Add(worker);
        }

        public void PrintTeamInfo()
        {
            Console.WriteLine(TeamLead);
            foreach (Worker worker in Workers)
            {
                Console.WriteLine(worker);
            }
        }
    }
}
