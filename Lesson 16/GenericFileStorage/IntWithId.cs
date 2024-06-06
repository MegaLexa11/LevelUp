using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFileStorage
{
    internal class IntWithId: IContainsId
    {
        public Guid Id { get; }

        public int Num { get; }

        public IntWithId(int num)
        {
            Id = Guid.NewGuid();
            Num = num;
        }
    }
}
