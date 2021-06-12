using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Mensajeros.Layers.DAL;
using UTN.Winform.Mensajeros.Layers.Interfaces;

namespace UTN.Winform.Mensajeros.Layers.BLL
{
    class BLLLogin : IBLLLogin
    {
        public bool Login(string pUsuario, string pContrasena)
        {
            IDALLogin _DALLogin = new DALLogin();
            return _DALLogin.Login(pUsuario, pContrasena);
        }
    }
}
