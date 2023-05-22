using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Prueba.Servicio.Models
{
    public class ClientesVM
    {
        public int ID { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public string cuit { get; set; }
        public string domicilio { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public string nombresApellidos { get; set; }        

    }
}
