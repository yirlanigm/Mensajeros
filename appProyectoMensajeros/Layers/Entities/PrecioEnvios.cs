using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Mensajeros.Layers.Entities
{
    class PrecioEnvios
    {
        public int TipoEnvio { get; set; }
        public int KilometroInicial { get; set; }
        public int KilometroFinal { get; set; }
        public double Precio { get; set; }
      
        public override string ToString() => $"{TipoEnvio} {KilometroInicial} {KilometroFinal} {Precio}";
    }
}
