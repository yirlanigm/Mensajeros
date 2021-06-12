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
using UTN.Winform.Mensajeros.Layers.BLL;
using UTN.Winform.Mensajeros.Layers.Entities;
using UTN.Winform.Mensajeros.Layers.Interfaces;

namespace UTN.Winform.Mensajeros.Layers.UI.Mantenimientos
{
    public partial class frmMantenimientoPrecioEnvios : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        
        public frmMantenimientoPrecioEnvios()
        {
            InitializeComponent();
        }
        /// <summary>
        /// boton salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Carga el formulario Factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMantenimientoPrecioEnvios_Load(object sender, EventArgs e)
        {
            IBLLPrecioEnvios _BLLPrecioEnvios = new BLLPrecioEnvios();
            try
            {
                CargarDatos();
                // Mostar Numero de envio
                this.nudId.Text = _BLLPrecioEnvios.GetCurrentNumeroEnvio().ToString();
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

        /// <summary>
        /// Carga los Datos
        /// </summary>
        private void CargarDatos()
        {
            IBLLPrecioEnvios _IBLLPrecioEnvios = new BLLPrecioEnvios();


            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            ////Configuracion del DataGridView para que se vea bien la imagen.
            //dgvDatos.AutoGenerateColumns = false;
            //dgvDatos.RowTemplate.Height = 100;
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;



            // Cargar el DataGridView
            this.dgvDatos.DataSource = _IBLLPrecioEnvios.GetAllPrecioEnvios();

        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            IBLLPrecioEnvios _BLLPrecioEnvios = new BLLPrecioEnvios();
            this.txtPrecioEnvio.Clear();

            this.nudId.Enabled = false;
            this.txtPrecioEnvio.Enabled = false;
            this.nudKilometroInicial.Enabled = false;
            this.nudKilometroFinal.Enabled = false;
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;


            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.nudId.Enabled = false;
                    this.txtPrecioEnvio.Enabled = true;
                    this.nudKilometroInicial.Enabled = true;
                    this.nudKilometroFinal.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    // Mostar Numero de factura
                    this.nudId.Text = _BLLPrecioEnvios.GetNextNumeroEnvio().ToString();

                    nudId.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.nudId.Enabled = false;
                    this.txtPrecioEnvio.Enabled = true;
                    this.nudKilometroInicial.Enabled = true;
                    this.nudKilometroFinal.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    nudId.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            
            this.CambiarEstado(EstadoMantenimiento.Nuevo);
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Ninguno);
        }

        private void tspPrincipal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            PrecioEnvios oPrecioEnvios = null;
            IBLLPrecioEnvios _BLLPrecioEnvios = new BLLPrecioEnvios();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.CambiarEstado(EstadoMantenimiento.Editar);
                    oPrecioEnvios = this.dgvDatos.SelectedRows[0].DataBoundItem as PrecioEnvios;
                    this.nudId.Text = oPrecioEnvios.TipoEnvio.ToString();
                    this.nudKilometroInicial.Text = oPrecioEnvios.KilometroInicial.ToString();
                    this.nudKilometroFinal.Text = oPrecioEnvios.KilometroFinal.ToString();
                    this.txtPrecioEnvio.Text = oPrecioEnvios.Precio.ToString();
                   

                    _BLLPrecioEnvios.SavePrecioEnvios(oPrecioEnvios);

                }
                else
                {
                    MessageBox.Show("Seleccione el registro !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLPrecioEnvios _BLLPrecioEnvios = new BLLPrecioEnvios();

            try
            {
                PrecioEnvios oPrecioEnvios = new PrecioEnvios();

                oPrecioEnvios.TipoEnvio = int.Parse(this.nudId.Text);
                oPrecioEnvios.KilometroInicial =int.Parse(this.nudKilometroInicial.Text);
                oPrecioEnvios.KilometroFinal = int.Parse(this.nudKilometroFinal.Text);
                oPrecioEnvios.Precio = double.Parse(this.txtPrecioEnvio.Text);
            

                oPrecioEnvios = _BLLPrecioEnvios.SavePrecioEnvios(oPrecioEnvios);


                if (oPrecioEnvios != null)
                    this.CargarDatos();

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

        private void toolStripBtnBorrar_Click(object sender, EventArgs e)
        {
            IBLLPrecioEnvios _IBLLPrecioEnvios = new BLLPrecioEnvios();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.CambiarEstado(EstadoMantenimiento.Borrar);

                    PrecioEnvios oPrecioEnvios = this.dgvDatos.SelectedRows[0].DataBoundItem as PrecioEnvios;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oPrecioEnvios.TipoEnvio} {oPrecioEnvios.Precio}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _IBLLPrecioEnvios.DeletePrecioEnvios(oPrecioEnvios.TipoEnvio);
                        this.CargarDatos();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el registro !", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
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
    }
}
