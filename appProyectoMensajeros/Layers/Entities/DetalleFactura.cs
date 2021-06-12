using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Mensajeros.Layers.Entities
{
    class DetalleFactura
    {
        public String idFactura { get; set; }
        public int Secuencia { get; set; }
        public int CantidadPaquetes { get; set; }
        public double Kilometros { get; set; }
        public double PrecioCalculado { get; set; }
        public double Impuesto { get; set; }
        public String DescripcionRuta { get; set; }
        public int IdTipoEnvio { get; set; }
    }
}
