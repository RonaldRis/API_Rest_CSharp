using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.Models;

namespace WCF.WebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WCF_Persona" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WCF_Persona.svc o WCF_Persona.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WCF_Persona : IWCF_Persona
    {

        #region Atributos
        private List<Persona> Personas;
        private int count;
        #endregion

        #region Contructor
        public WCF_Persona()
        {
            Personas = new List<Persona>()
            {
                new Persona(){id=1,Nombre="Ronald",Apellido="Tejada"},
                new Persona(){id=2,Nombre="Ashley",Apellido="Rivera"},
                new Persona(){id=3,Nombre="Dastan",Apellido="Viocelli"}
            };
            count = 3;
        }
        #endregion

        #region Metodos

        public IEnumerable<Persona> GetAll()
        {
            return Personas;
        }

        public Persona GetById(int id)
        {
            return Personas.Find(p => p.id == id);
        }
        #endregion

    }
}
