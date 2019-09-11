using ApiTOKEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTOKEN.Repository
{
    public class Rcliente : IRepository<Cliente>
    {

        public bool Delete(int id)
        {

            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            using (var db = new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.Cliente.ToList();
            }
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente Save(Cliente item)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Cliente item)
        {
            throw new NotImplementedException();
        }
    }
}