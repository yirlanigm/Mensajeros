﻿using appProyectoMensajeros.Layers.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appProyectoMensajeros
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmPrincipal());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin ofrmLogin = new frmLogin();

            ofrmLogin.ShowDialog();

            if (ofrmLogin.DialogResult == DialogResult.OK)
                Application.Run(new frmPrincipal());
        }
    }
}
