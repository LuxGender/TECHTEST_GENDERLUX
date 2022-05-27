using Back_datosUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//oficial
namespace Back_datosUs.Controllers
{
    public class DatosUsuarioController : ApiController
    {
        // GET: api/DatosUsuario
        public IEnumerable<DatosUsuario> Get()
        {
            GestorDatosUsuario gDatos = new GestorDatosUsuario();
            return gDatos.getDatosUsuario();
            //return gDatos.getdatosUs();
        }

        // GET: api/DatosUsuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DatosUsuario
        public bool Post([FromBody]DatosUsuario datos)
        {
            GestorDatosUsuario gDatos = new GestorDatosUsuario();
            bool res = gDatos.DatosUsuarioAdd(datos);

            return res;

        }

        // PUT: api/DatosUsuario/5
        public bool Put(int id, [FromBody]DatosUsuario datos)
        {
            GestorDatosUsuario gDatos = new GestorDatosUsuario();
            bool res = gDatos.UpdateDatosUsuario(id, datos);

            return res;

        }

        // DELETE: api/DatosUsuario/5
        public bool Delete(int id)
        {
            GestorDatosUsuario gDatos = new GestorDatosUsuario();
            bool res = gDatos.DeleteDatosUsuario(id);

            return res;
        }
    }
}
