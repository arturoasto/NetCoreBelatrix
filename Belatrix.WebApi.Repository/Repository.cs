using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Repository
{
    public class Repository<T> : IRepository<T>
    {
        public Task<int> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
