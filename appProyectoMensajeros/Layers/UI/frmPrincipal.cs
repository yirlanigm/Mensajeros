using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.Mensajeros.Layers.UI.Mantenimientos;
using UTN.Winform.Mensajeros.Layers.UI.Procesos;
using UTN.Winform.Mensajeros.Layers.UI.Reportes;

namespace appProyectoMensajeros.Layers.UI
{
    public partial class frmPrincipal : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItemAcercaDe_Click(object sender, EventArgs e)
        {
            frmAcercaDe ofrmAcercade;
            try
            {
                ofrmAcercade = new frmAcercaDe();
                ofrmAcercade.MdiParent = this;
                ofrmAcercade.Show();
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoCliente ofrmMantenimientoCliente;

            try
            {
                ofrmMantenimientoCliente = new frmMantenimientoCliente();
                ofrmMantenimientoCliente.MdiParent = this;
                ofrmMantenimientoCliente.Show();

            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void mensajeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoMensajero ofrmMantenimientoMensajero;

            try
            {
                ofrmMantenimientoMensajero = new frmMantenimientoMensajero();
                ofrmMantenimientoMensajero.MdiParent = this;
                ofrmMantenimientoMensajero.Show();

            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void precioPorEnvióToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoPrecioEnvios ofrmMantenimientoPrecioEnvios;

            try
            {
                ofrmMantenimientoPrecioEnvios = new frmMantenimientoPrecioEnvios();
                ofrmMantenimientoPrecioEnvios.MdiParent = this;
                ofrmMantenimientoPrecioEnvios.Show();

            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturacion ofrmFacturacion;

            try
            {
                ofrmFacturacion = new frmFacturacion();
                ofrmFacturacion.MdiParent = this;
                ofrmFacturacion.Show();
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void porRangoDeFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteXRangoFecha ofrmReporteXRangoFecha;
            try
            {
                ofrmReporteXRangoFecha = new frmReporteXRangoFecha();
                ofrmReporteXRangoFecha.MdiParent = this;
                ofrmReporteXRangoFecha.Show();
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void graficoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comprasClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteGraficoXComprasCliente ofrmReporteGraficoXComprasCliente;
            try
            {
                ofrmReporteGraficoXComprasCliente = new frmReporteGraficoXComprasCliente();
                ofrmReporteGraficoXComprasCliente.MdiParent = this;
                ofrmReporteGraficoXComprasCliente.Show();
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);

                // Log error
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        

      
        }
    }

}
