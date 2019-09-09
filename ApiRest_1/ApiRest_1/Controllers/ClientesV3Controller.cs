using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using ApiRest_1.Models;
using Microsoft.Data.OData;

namespace ApiRest_1.Controllers
{
    /*
    Puede que la clase WebApiConfig requiera cambios adicionales para agregar una ruta para este controlador. Combine estas instrucciones en el método Register de la clase WebApiConfig según corresponda. Tenga en cuenta que las direcciones URL de OData distinguen mayúsculas de minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ApiRest_1.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Cliente>("ClientesV3");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ClientesV3Controller : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/ClientesV3
        public IHttpActionResult GetClientesV3(ODataQueryOptions<Cliente> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<Cliente>>(clientes);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/ClientesV3(5)
        public IHttpActionResult GetCliente([FromODataUri] int key, ODataQueryOptions<Cliente> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Cliente>(cliente);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/ClientesV3(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Cliente> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(cliente);

            // TODO: Save the patched entity.

            // return Updated(cliente);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/ClientesV3
        public IHttpActionResult Post(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(cliente);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/ClientesV3(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Cliente> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(cliente);

            // TODO: Save the patched entity.

            // return Updated(cliente);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/ClientesV3(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
