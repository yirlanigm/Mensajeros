using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Mensajeros.Layers.Entities;

namespace UTN.Winform.Mensajeros.Layers.Interfaces
{
    interface IBLLMensajeros
    {

        List<Mensajero> GetMensajerosByFilter(string pDescripcion);
        Mensajero GetMensajeroById(string pId);
        List<Mensajero> GetAllMensajero();
        Mensajero SaveMensajero(Mensajero pMensajero);
        bool DeleteMensajero(string pId);
    }
}
