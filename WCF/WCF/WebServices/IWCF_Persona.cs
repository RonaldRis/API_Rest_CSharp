

namespace WCF.WebServices
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using WCF.Models;
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWCF_Persona" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWCF_Persona
    {
        [OperationContract]
        IEnumerable<Persona> GetAll();

        [OperationContract]
        Persona GetById(int id);
    }
}
