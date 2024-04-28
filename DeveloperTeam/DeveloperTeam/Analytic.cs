namespace DeveloperTeam
{
    internal class Analytic : Engineer
    {

        public override Position Position => Position.Analytic;
        public AnalyticSpecialization Specialization { get; }

        public Analytic(string name, AnalyticSpecialization specialization, Level level)
            : base(name, level)
        {
            Specialization = specialization;
        }

        public override string ToString()
        {
            return $"{Name}, {Position}, {Specialization}, {Level}";
        }
    }
}
