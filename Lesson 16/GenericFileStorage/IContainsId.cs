using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFileStorage
{
    internal interface IContainsId
    {
        public Guid Id { get; }

    }
}
