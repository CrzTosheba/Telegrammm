using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegrammm.Repository
{
    internal interface IRepository<T>
    {
        void Add(T item);
        void Delete(T item);

        IEnumerable<T> All();
    }
}
