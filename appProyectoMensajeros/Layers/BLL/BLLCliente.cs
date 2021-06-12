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
    class BLLCliente : IBLLCliente
    {
        public bool DeleteCliente(string pId)
        {
            IDALCliente _DALCliente = new DALCliente();

            return _DALCliente.DeleteCliente(pId);
        }

        public List<Cliente> GetAllCliente()
        {
            IDALCliente _DALCliente = new DALCliente();
            return _DALCliente.GetAllCliente();
        }

        public List<Cliente> GetClienteByFilter(string pDescripcion)
        {
            IDALCliente _DALCliente = new DALCliente();
            return _DALCliente.GetClienteByFilter(pDescripcion);
        }

        public Cliente GetClienteById(string pIdCliente)
        {
            IDALCliente _DALCliente = new DALCliente();
            return _DALCliente.GetClienteById(pIdCliente);
        }

        public Cliente SaveCliente(Cliente pCliente)
        {
            IDALCliente _DALCliente = new DALCliente();
            Cliente oCliente = null;

            if (_DALCliente.GetClienteById(pCliente.IdCliente) == null)
                oCliente  = _DALCliente.SaveCliente(pCliente);
            else
                oCliente = _DALCliente.UpdateCliente(pCliente);


            

            return oCliente;
        }
    }
}