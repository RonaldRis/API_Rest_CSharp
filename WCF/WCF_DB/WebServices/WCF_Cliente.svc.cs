using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_DB.Models;

namespace WCF_DB.WebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WCF_Cliente" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WCF_Cliente.svc o WCF_Cliente.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WCF_Cliente : IWCF_Persona
    {
        Model1 db = new Model1();

        public bool Delete(int id)
        {
            try
            {
                Cliente c = db.Cliente.Find(id);
                db.Cliente.Remove(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            return db.Cliente;
        }

        public Cliente GetById(int id)
        {
            return db.Cliente.Find(id);
        }

        public bool Save(string nombre, string direccion,int edad)
        {
            try
            {
                Cliente c = new Cliente() { nombre = nombre, direccion = direccion, edad = edad };
                db.Cliente.Add(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Cliente c)
        {
            try
            {
                Cliente old = db.Cliente.Find(c.id);
                if (old==null)
                {
                    return false;
                }

                old.direccion=c.direccion;
                old.edad = c.edad;   
                old.nombre = c.nombre;
                db.Entry(old).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
