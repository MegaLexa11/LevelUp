using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFileStorage
{
    internal interface IContainsId<T>
    {
        public Guid Id { get; }

        public T Value { get; }

    }
}
