using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Mensajeros.Layers.Entities
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public int Provincia { get; set; }
        public string Direccion { get; set; }
        
        public override string ToString() => $"{Nombre} {Apellido1}";
    }
}
