using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTN.Winform.Mensajeros.Layers.UI.Reportes
{
    public partial class frmReporteFactura : Form
    {
        public frmReporteFactura()
        {
            InitializeComponent();
        }

        private void frmReporteFactura_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
