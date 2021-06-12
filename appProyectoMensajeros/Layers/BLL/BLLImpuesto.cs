using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Mensajeros.Layers.DAL;
using UTN.Winform.Mensajeros.Layers.Entities;
using UTN.Winform.Mensajeros.Layers.Interfaces;

namespace UTN.Winform.Mensajeros.Layers.BLL
{
    class BLLImpuesto : IBLLImpuesto
    {
        public Impuesto GetImpuesto()
        {
            IDALImpuesto _DALImpuesto = new DALImpuesto();

            return _DALImpuesto.GetImpuesto();
        }
    }
}
