using Prueba.Model;
using Prueba.Servicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Web;


namespace Prueba.Servicio
{
    public class ServicioClientes
    {
        PruebaEntities db = new PruebaEntities();
        public List<ClientesVM> ListarClientes(string filtro, string orden, string direccion, int skip, int pageSize, int? cliente)
        {
            List<ClientesVM> clientes = new List<ClientesVM>();
            using (var db = new PruebaEntities())
            {
                IQueryable<ClientesVM> query = (from c in db.Clientes

                                                select new ClientesVM
                                                {
                                                    ID = c.ID,
                                                    nombres = c.nombres,
                                                    apellidos = c.apellidos,
                                                    fechaNacimiento = c.fechaNacimiento,
                                                    cuit = c.cuit,
                                                    mail = c.mail,
                                                    telefono = c.telefono,

                                                }).OrderBy(x => x.ID);
                var prueba = query.ToList();


                if ((filtro != "") && !(string.IsNullOrEmpty(filtro)))
                {
                    query = query.Where(c => c.nombres.Contains(filtro) || c.apellidos.Contains(filtro));
                }
                if (cliente != null)
                {
                    query = query.Where(c => c.ID == cliente);
                }

                var lista = query.ToList();
                return lista;
            }
        }
        public List<ClientesVM> ListarClientesFiltro()
        {
            List<ClientesVM> lista = null;
            {
                lista =
                (from c in db.Clientes

                 select new ClientesVM
                 {
                     ID = c.ID,
                     nombresApellidos = c.nombres + " " + c.apellidos,
                 }).Where(x => x.nombresApellidos != "").ToList();

            }
            return lista.OrderBy(x => x.nombresApellidos).ToList();
        }

        public ClientesVM AbrirCliente(int idCliente)
        {
            var tmp = (from x in db.Clientes
                       where x.ID == idCliente
                       select new ClientesVM
                       {
                           ID = x.ID,
                           nombres = x.nombres,
                           apellidos = x.apellidos,
                           fechaNacimiento = x.fechaNacimiento,
                           cuit = x.cuit,
                           domicilio = x.domicilio,
                           mail = x.mail,
                           telefono = x.telefono,
                       }).FirstOrDefault();
            return tmp;
        }

        public int GuardarEdicion(ClientesVM cliente)
        {
            try
            {
                var unCliente = db.Clientes.Where(x => x.ID == cliente.ID).FirstOrDefault();
                unCliente.nombres = cliente.nombres;
                unCliente.apellidos = cliente.apellidos;
                unCliente.fechaNacimiento = cliente.fechaNacimiento;
                unCliente.cuit = cliente.cuit;
                unCliente.domicilio = cliente.domicilio;
                unCliente.telefono = cliente.telefono;
                unCliente.mail = cliente.mail;

                db.SaveChanges();
                return 200;
            }
            catch (Exception e)
            {
                var ex = e.GetBaseException();
                return 0;
            }
        }
        public int GuardarNuevo(ClientesVM cliente)
        {
            Clientes nuevoCliente = new Clientes();
            try
            {
                nuevoCliente.nombres = cliente.nombres;
                nuevoCliente.apellidos = cliente.apellidos;
                nuevoCliente.fechaNacimiento = cliente.fechaNacimiento;
                nuevoCliente.cuit = cliente.cuit;
                nuevoCliente.domicilio = cliente.domicilio;
                nuevoCliente.telefono = cliente.telefono;
                nuevoCliente.mail = cliente.mail;
                db.Clientes.Add(nuevoCliente);
                db.SaveChanges();

                return 200;
            }
            catch (Exception e)
            {
                var ex = e.GetBaseException();
                return 0;
            }
        }
    }
}

