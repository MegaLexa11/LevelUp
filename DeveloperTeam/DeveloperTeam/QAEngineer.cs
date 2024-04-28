namespace DeveloperTeam
{
    internal class QAEngineer : Engineer
    {
        public override Position Position => Position.QAEngineer;
        public QASpecialization Specialization { get; }

        public QAEngineer(string name, QASpecialization specialization, Level level)
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
