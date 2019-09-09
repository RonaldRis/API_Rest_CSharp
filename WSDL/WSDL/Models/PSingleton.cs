using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDL.Models
{
    public class PSingleton
    {
        private static PSingleton instancia;
        private static int cant;
        private static List<Persona> Personas;

        public static PSingleton Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new PSingleton();
                }
                return instancia;
            }
        }

        protected PSingleton()
        {
            if (Personas == null)
            {
                Personas = new List<Persona>()
                {
                    new Persona{id=1,nombre="Ashley",apellido="Rivera"},
                    new Persona{id=2,nombre="Dastan",apellido="Calderón"},
                    new Persona{id=3,nombre="Alexis",apellido="Ris"}
                };
                cant = 3;
            }
        }

        public List<Persona> GetAll()
        {
            return Personas;
        }

        public string AddPersona(string nombre, string apellido)
        {
            Persona prueba = new Persona { id = cant + 1, apellido = apellido, nombre = nombre };
            try
            {
                Personas.Add(prueba);
                cant++;
                return "Agregado con exito";
            }
            catch (Exception)
            {
                return "No agregado";
            }
        }

        internal string Update(int id, string nombre, string apellido)
        {
            int pos = Personas.FindIndex(p => p.id == id);
            if (pos>=0)
            {
                try
                {
                    Persona prueba = new Persona { id = id, apellido = apellido, nombre = nombre };
                    Personas[pos] = prueba;
                    return "Actualizado corectamente";
                }
                catch (Exception)
                {
                    return "No se pudo actualizar";
                }
            }
            return "No existe un registro con ese id";
        }

        public string DeleteId(int id)
        {
            try
            {
                int pos = Personas.FindIndex(p=>p.id==id);
                Personas.RemoveAt(pos);
                return "Eliminado con exito";
            }
            catch (Exception)
            {
                return "No eliminado";
            }
        }

    }
}