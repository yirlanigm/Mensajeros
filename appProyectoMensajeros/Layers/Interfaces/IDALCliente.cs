using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Mensajeros.Layers.Entities;

namespace UTN.Winform.Mensajeros.Layers.Interfaces
{
    interface IDALCliente
    {
        List<Cliente> GetClienteByFilter(string pDescripcion);
        Cliente GetClienteById(string pId);
        List<Cliente> GetAllCliente();
        Cliente SaveCliente(Cliente pCliente);
        Cliente UpdateCliente(Cliente pCliente);
        bool DeleteCliente(string pId);
    }
}
