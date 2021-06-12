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
    class BLLMensajeros : IBLLMensajeros
    {
        public bool DeleteMensajero(string pId)
        {
            IDALMensajeros _DALMensajeros = new DALMensajeros();

            return _DALMensajeros.DeleteMensajero(pId);
        }

        public List<Mensajero> GetAllMensajero()
        {
            IDALMensajeros _DALMensajeros = new DALMensajeros();

            return _DALMensajeros.GetAllMensajero();
        }

        public Mensajero GetMensajeroById(string pId)
        {
            IDALMensajeros _DALMensajeros = new DALMensajeros();

            return _DALMensajeros.GetMensajeroById(pId);
        }

        public List<Mensajero> GetMensajerosByFilter(string pDescripcion)
        {
            IDALMensajeros _DALMensajeros = new DALMensajeros();

            return _DALMensajeros.GetMensajerosByFilter(pDescripcion);
        }

        public Mensajero SaveMensajero(Mensajero pMensajero)
        {
            IDALMensajeros _DALMensajeros = new DALMensajeros();
            Mensajero oMensajero = null;

            if (_DALMensajeros.GetMensajeroById(pMensajero.idMensajero) == null)
                oMensajero = _DALMensajeros.SaveMensajero(pMensajero);
            else
                oMensajero = _DALMensajeros.UpdateMensajero(pMensajero);


            return oMensajero;
        }
    }
}
