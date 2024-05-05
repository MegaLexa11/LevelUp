using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineers
{
    internal record Engineer(EngineerLevel Level, string[] Responsibilities)
    {   
        public Guid Id = Guid.NewGuid();
    }
}
