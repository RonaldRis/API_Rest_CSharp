using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSDL.Models
{
    public class Persona
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        //public static List<Persona> Personas { get; set; }
        public Persona()
        {
            //if (Personas==null)
            //{
            //    Personas = new List<Persona>()
            //    {
            //        new Persona{id=1,nombre="Ashley",apellido="Rivera"},
            //        new Persona{id=2,nombre="Dastan",apellido="Calderón"},
            //        new Persona{id=3,nombre="Alexis",apellido="Ris"}
            //    };
            //}
        }
    }
}