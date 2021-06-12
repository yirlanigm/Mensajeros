using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.Winform.Mensajeros.Layers.Entities
{
    class Provincia
    {
        public int IdProvincia { set; get; }
        public string Descripcion { set; get; }

        public override string ToString() => IdProvincia + " " + Descripcion;
    }
}
