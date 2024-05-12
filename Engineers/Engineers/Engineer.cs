using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineers
{
    internal record Engineer(EngineerLevel Level, string[] Responsibilities)
    {   
        // set тут, конечно, не оч совсем
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
