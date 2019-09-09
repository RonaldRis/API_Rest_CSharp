

namespace WCF_DB.WebServices
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using WCF_DB.Models;
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWCF_Persona" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWCF_Persona
    {
        [OperationContract]
        IEnumerable<Cliente> GetAll();

        [OperationContract]
        Cliente GetById(int id);

        [OperationContract]
        bool Delete(int id);

        [OperationContract]
        bool Update(Cliente c);

        [OperationContract]
        bool Save(string nombre, string direccion, int edad);

    }
}
