using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Mensajeros.Layers.Entities
{
    public class Mensajero
    {
        public string idMensajero { get; set; }
        public string nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public bool sexo { get; set; }
        public string Telefono { get; set; }
        public byte[] Fotografia { get; set; }
        public string Email { get; set; } 
        
    }
}
