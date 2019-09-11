using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTOKEN.Repository
{
    interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        bool Delete(int id);
        bool Update(int id,T item);
        T Save(T item);
    }
}
