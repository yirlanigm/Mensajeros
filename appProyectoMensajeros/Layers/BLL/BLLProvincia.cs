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
    class BLLProvincia : IBLLProvincia
    {


        List<Provincia> IBLLProvincia.GetAllProvincia()
        {
            IDALProvincia _DALProvincia = new DALProvincia();

            return _DALProvincia.GetAllProvincia();
        }
    }
}