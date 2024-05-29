using System.ComponentModel;

namespace DeveloperTeam
{
    internal class Analytic : Engineer
    {
        public AnalyticSpecialization Specialization { get; }

        public Analytic(string name, AnalyticSpecialization specialization, Level level)
            : base(name, level)
        {
            Specialization = specialization;
        }

        public override string ToString()
        {
            return $"{Name}, {typeof(Analytic).Name}, {Specialization}, {Level}";
        }
    }
}
