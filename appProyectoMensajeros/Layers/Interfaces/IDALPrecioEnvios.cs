﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Mensajeros.Layers.Entities;

namespace UTN.Winform.Mensajeros.Layers.Interfaces
{
    interface IDALPrecioEnvios
    {
        List<PrecioEnvios> GetPrecioEnviosByFilter(int pTipoEnvio);
        PrecioEnvios GetPrecioEnviosById(int pTipoEnvio);
        List<PrecioEnvios> GetAllPrecioEnvios();
        PrecioEnvios SavePrecioEnvios(PrecioEnvios oPrecioEnvios);
        bool DeletePrecioEnvios(int pTipoEnvio);
        PrecioEnvios UpdatePrecioEnvios(PrecioEnvios oPrecioEnvios);
        int GetNextNumeroEnvio();

        int GetCurrentNumeroEnvio();
    }
}
