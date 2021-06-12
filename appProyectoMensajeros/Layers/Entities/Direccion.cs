using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Mensajeros.Layers.Entities
{
    class Direccion
    {
        public double Latitud { set; get; }
        public double Longitud { set; get; }
        public string Ubicacion { set; get; }


        public override string ToString()
        {
            return string.Format("{0}", Ubicacion);
        }
    }
}
