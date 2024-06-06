using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFileStorage
{
    internal class StrWithId: IContainsId
    {
        public Guid Id { get; }

        public string Str { get; }

        public StrWithId(string str)
        {
            Id = Guid.NewGuid();
            Str = str;
        }
    }
}
