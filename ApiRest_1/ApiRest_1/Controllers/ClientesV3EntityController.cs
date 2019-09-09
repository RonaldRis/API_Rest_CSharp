using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ApiRest_1.Models;

namespace ApiRest_1.Controllers
{
    /*
    Puede que la clase WebApiConfig requiera cambios adicionales para agregar una ruta para este controlador. Combine estas instrucciones en el método Register de la clase WebApiConfig según corresponda. Tenga en cuenta que las direcciones URL de OData distinguen mayúsculas de minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ApiRest_1.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Cliente>("ClientesV3Entity");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ClientesV3EntityController : ODataController
    {
        private Model1 db = new Model1();

        // GET: odata/ClientesV3Entity
        [EnableQuery]
        public IQueryable<Cliente> GetClientesV3Entity()
        {
            return db.Cliente;
        }

        // GET: odata/ClientesV3Entity(5)
        [EnableQuery]
        public SingleResult<Cliente> GetCliente([FromODataUri] int key)
        {
            return SingleResult.Create(db.Cliente.Where(cliente => cliente.id == key));
        }

        // PUT: odata/ClientesV3Entity(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Cliente> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cliente cliente = db.Cliente.Find(key);
            if (cliente == null)
            {
                return NotFound();
            }

            patch.Put(cliente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cliente);
        }

        // POST: odata/ClientesV3Entity
        public IHttpActionResult Post(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cliente.Add(cliente);
            db.SaveChanges();

            return Created(cliente);
        }

        // PATCH: odata/ClientesV3Entity(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Cliente> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cliente cliente = db.Cliente.Find(key);
            if (cliente == null)
            {
                return NotFound();
            }

            patch.Patch(cliente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cliente);
        }

        // DELETE: odata/ClientesV3Entity(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Cliente cliente = db.Cliente.Find(key);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Cliente.Remove(cliente);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int key)
        {
            return db.Cliente.Count(e => e.id == key) > 0;
        }
    }
}
