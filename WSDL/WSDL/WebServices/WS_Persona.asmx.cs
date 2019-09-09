using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSDL.Models;

namespace WSDL.WebServices
{
    /// <summary>
    /// Descripción breve de WS_Persona
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Persona : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            string id = Console.ReadLine();
            return "Hola a todos";
        }

        [WebMethod]
        public string Agregar(string nombre, string apellido)
        {
            return PSingleton.Instancia.AddPersona(nombre, apellido);
        }

        [WebMethod]
        public string Update(int id,string nombre, string apellido)
        {
            return PSingleton.Instancia.Update(id,nombre, apellido);
        }

        [WebMethod]
        public string Delete(int id_Borrar)
        {
            return PSingleton.Instancia.DeleteId(id_Borrar);
        }
        [WebMethod]
        public List<Persona> GetAll()
        {
            return PSingleton.Instancia.GetAll();
        }
        [WebMethod]
        public Persona GetbyID(int id,DateTime fecha)
        {
            return PSingleton.Instancia.GetAll().Find(p => p.id == id);
        }
    }
}
