using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFileStorage
{
    internal class IntWithId: IContainsId<int>
    {
        public Guid Id { get; } = Guid.NewGuid();

        public int Value { get; }

        public IntWithId(int value)
        {
            Value = value;
        }
    }
}
