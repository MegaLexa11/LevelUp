using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata;

namespace DeveloperTeam
{
    internal class QAEngineer : Engineer
    {
        public QASpecialization Specialization { get; }

        public QAEngineer(string name, QASpecialization specialization, Level level)
            : base(name, level)
        {
            Specialization = specialization;
        }

        public override string ToString()
        {
            return $"{Name}, {typeof(QAEngineer).Name}, {Specialization}, {Level}";
        }
    }
}
