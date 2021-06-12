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
    class BLLPrecioEnvios : IBLLPrecioEnvios
    {
        public bool DeletePrecioEnvios(int pTipoEnvio)
        {
            IDALPrecioEnvios _DALPrecioEnvios = new DALPrecioEnvios();

            return _DALPrecioEnvios.DeletePrecioEnvios(pTipoEnvio);
        }

        public List<PrecioEnvios> GetAllPrecioEnvios()
        {
            IDALPrecioEnvios _DALPrecioEnvios = new DALPrecioEnvios();
            return _DALPrecioEnvios.GetAllPrecioEnvios();
        }

        public int GetCurrentNumeroEnvio()
        {
            IDALPrecioEnvios _DALPrecioEnvios = new DALPrecioEnvios();
            return _DALPrecioEnvios.GetCurrentNumeroEnvio();
        }

        public int GetNextNumeroEnvio()
        {
            IDALPrecioEnvios _DALPrecioEnvios = new DALPrecioEnvios();
            return _DALPrecioEnvios.GetNextNumeroEnvio();
        }

        public List<PrecioEnvios> GetPrecioEnviosByFilter(int pTipoEnvio)
        {
            IDALPrecioEnvios _DALPrecioEnvios = new DALPrecioEnvios();
            return _DALPrecioEnvios.GetPrecioEnviosByFilter(pTipoEnvio);
        }

        public PrecioEnvios GetPrecioEnviosById(int pTipoEnvio)
        {
            IDALPrecioEnvios _DALPrecioEnvios = new DALPrecioEnvios();
            return _DALPrecioEnvios.GetPrecioEnviosById(pTipoEnvio);
        }

        public PrecioEnvios SavePrecioEnvios(PrecioEnvios oPrecioEnvios)
        {
            IDALPrecioEnvios _DALPrecioEnvios = new DALPrecioEnvios();
            PrecioEnvios _PrecioEnvios = null;

            if (_DALPrecioEnvios.GetPrecioEnviosById(oPrecioEnvios.TipoEnvio) == null)
                _PrecioEnvios = _DALPrecioEnvios.SavePrecioEnvios(oPrecioEnvios);
            else
                _PrecioEnvios = _DALPrecioEnvios.UpdatePrecioEnvios(oPrecioEnvios);


            return _PrecioEnvios;
        }
    }
}
