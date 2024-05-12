using System.ComponentModel;

namespace DeveloperTeam
{
    // В целом, понятно, как классы от девелопера посоздавать с соответствующей специализацией, поэтому подумал, почему бы не оставить его в таком виде
    // Хотя, конечно, по итогу, создавать работников можно было бы передавая только два аргумента, что гораздо проще
    internal class Developer : Engineer
    {
        public DeveloperSpecialization Specialization { get; }

        public Developer(string name, DeveloperSpecialization specialization, Level level)
            : base(name, level)
        {
            Specialization = specialization;
        }

        public override string ToString()
        {
            return $"{Name}, {typeof(Developer).Name}, {Specialization}, {Level}";
        }
    }
}
