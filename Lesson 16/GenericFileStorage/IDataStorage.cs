using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFileStorage
{
    internal interface IDataStorage<T>
    {
        Task Save(IEnumerable<T> Items, bool isOverwrite);
        Task Save(T Item);

        Task<IEnumerable<T>> Fetch();
        Task<IEnumerable<T>> FetchById(Guid Id);
    }
}
