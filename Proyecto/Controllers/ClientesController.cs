using Prueba.Servicio;
using Prueba.Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ClientesController : Controller
    {
        [System.Web.Http.Route("/ListarClientes")]
        [System.Web.Http.HttpPost]
        public ActionResult ListarClientes(int? cliente)
        {
            var requestFormData = Request.Form;
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            var _servicio = new Prueba.Servicio.ServicioClientes();
            var tmp = _servicio.ListarClientes(searchValue, sortColumn, sortColumnDir, skip, pageSize, cliente);

            //((IDisposable)_servicio).Dispose();
            var recordsTotal = tmp.Count();

            var toTake = pageSize;
            if (recordsTotal < pageSize)
            {
                toTake = recordsTotal;
            }
            tmp = tmp.Skip(skip).Take(toTake).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = tmp });
        }
        //[System.Web.Http.Route("/ListarClientesFiltro")]
        //[System.Web.Http.ActionName("ListarClientesFiltro")]
        //[System.Web.Http.HttpGet]
        //public List<ClientesVM> ListarClientesFiltro()
        //{
        //    Prueba.Servicio.ServicioClientes _servicio = new Prueba.Servicio.ServicioClientes();
        //    var tmp = _servicio.ListarClientesFiltro();

        //    return tmp;
        //}      
        public JsonResult ListarClientesFiltro()
        {
            Prueba.Servicio.ServicioClientes _servicio = new Prueba.Servicio.ServicioClientes();
            var tmp = _servicio.ListarClientesFiltro();

            var models = tmp.Select(x => new ClientesVM
            {
                ID = x.ID,
                nombresApellidos = x.nombresApellidos
            }).ToList();

            return Json(models, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AbrirCliente(int idCliente)
        {
            ServicioClientes _servicio = new ServicioClientes();
            var tmp = _servicio.AbrirCliente(idCliente);

            var model = new ClientesVM
            {
                ID = tmp.ID,
                nombres = tmp.nombres,
                apellidos = tmp.apellidos,
                fechaNacimiento = tmp.fechaNacimiento,
                cuit = tmp.cuit,
                domicilio = tmp.domicilio,
                telefono = tmp.telefono,
                mail = tmp.mail,
                nombresApellidos = tmp.nombresApellidos
            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        //[System.Web.Http.Route("/AbrirCliente")]
        //[System.Web.Http.ActionName("AbrirCliente")]
        //[System.Web.Http.HttpGet]
        //public ClientesVM AbrirCliente(int idCliente)
        //{
        //    ServicioClientes _servicio = new ServicioClientes();
        //    var tmp = _servicio.AbrirCliente(idCliente);
        //    return tmp;
        //}
        public int GuardarEdicion(ClientesVM cliente)
        {
            try
            {
                ServicioClientes _servicio = new ServicioClientes();
                var tmp = _servicio.GuardarEdicion(cliente);

                return tmp;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public int GuardarNuevo(ClientesVM cliente)
        {
            try
            {
                ServicioClientes _servicio = new ServicioClientes();
                var tmp = _servicio.GuardarNuevo(cliente);

                return tmp;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }
}
