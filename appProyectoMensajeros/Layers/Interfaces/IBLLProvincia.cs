using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Mensajeros.Layers.Entities;

namespace UTN.Winform.Mensajeros.Layers.Interfaces
{
    interface IBLLProvincia
    {
        List<Provincia> GetAllProvincia();
    }
}
