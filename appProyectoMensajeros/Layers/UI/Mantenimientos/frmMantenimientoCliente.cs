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
    public partial class frmMantenimientoCliente : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoCliente()
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Ninguno);
        }

        private void frmMantenimientoCliente_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
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

        #region Methods


        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.mskIdentificacion.Clear();
            this.txtNombre.Clear();
            this.txtApellido1.Clear();
            this.txtApellido2.Clear();
            this.mskTelefono.Clear();
            this.txtDireccion.Clear();

            this.mskIdentificacion.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellido1.Enabled = false;
            this.txtApellido2.Enabled = false;
            this.mskTelefono.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cmbProvincia.Enabled = false;



            // Coloca el primer item por defecto
            if (cmbProvincia.Items.Count > 0)
                this.cmbProvincia.SelectedIndex = 0;


            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.mskIdentificacion.Enabled = true;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.mskTelefono.Enabled = true;
                    this.txtDireccion.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.cmbProvincia.Enabled = true;
                    mskIdentificacion.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.mskIdentificacion.Enabled = false;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.mskTelefono.Enabled = true;
                    this.txtDireccion.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.cmbProvincia.Enabled = true;
                    mskIdentificacion.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }


        private void CargarDatos()
        {
            IBLLCliente _IBLLCliente = new BLLCliente();
            IBLLProvincia _BLLProvincia = new BLLProvincia();
            List<Provincia> lista = new List<Provincia>();

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            //// Configuracion del DataGridView para que se vea bien la imagen.
            //dgvDatos.AutoGenerateColumns = false;
            //dgvDatos.RowTemplate.Height = 100;
            //dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Cargar el DataGridView
            this.dgvDatos.DataSource = _IBLLCliente.GetAllCliente();

            // Cargar el combo
            this.cmbProvincia.Items.Clear();
            lista = _BLLProvincia.GetAllProvincia();
            foreach (Provincia oProvincia in lista)
            {
                this.cmbProvincia.Items.Add(oProvincia);
            }
            // Colocar el primero como default
            this.cmbProvincia.SelectedIndex = 0;


        }

        



        #endregion

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Nuevo);
        }

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            Cliente oCliente = null;
            IBLLCliente _BLLCliente = new BLLCliente();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.CambiarEstado(EstadoMantenimiento.Editar);
                    oCliente = this.dgvDatos.SelectedRows[0].DataBoundItem as Cliente;
                    this.mskIdentificacion.Text = oCliente.IdCliente;
                    this.txtNombre.Text = oCliente.Nombre;
                    this.txtApellido1.Text = oCliente.Apellido1;
                    this.txtApellido2.Text = oCliente.Apellido2;
                    this.mskTelefono.Text = oCliente.Telefono;
                    cmbProvincia.SelectedIndex = cmbProvincia.FindString(oCliente.Provincia.ToString());
                    this.txtDireccion.Text = oCliente.Direccion;
                    
                    _BLLCliente.SaveCliente(oCliente);

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
            IBLLCliente _BLLCliente = new BLLCliente();

            try
            {
                Cliente oCliente = new Cliente();


                if (string.IsNullOrEmpty(mskIdentificacion.Text))
                {
                    MessageBox.Show("Identificador del cliente es un dato requerido!");
                    mskIdentificacion.Focus();
                    return;
                }

                oCliente.IdCliente = this.mskIdentificacion.Text;
                oCliente.Nombre = this.txtNombre.Text;
                oCliente.Apellido1 = this.txtApellido1.Text;
                oCliente.Apellido2 = this.txtApellido2.Text;
                oCliente.Direccion = this.txtDireccion.Text;
                oCliente.Telefono =  (this.mskTelefono.Text);
                oCliente.Provincia = (cmbProvincia.SelectedItem as Provincia).IdProvincia; 

                oCliente = _BLLCliente.SaveCliente(oCliente);

                

                

                //frmReporteXClienteId reporte = new frmReporteXClienteId(oCliente.IdCliente);
                //reporte.ShowDialog();

                if (oCliente != null)
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
            IBLLCliente _IBLLCliente = new BLLCliente();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.CambiarEstado(EstadoMantenimiento.Borrar);

                    Cliente oCliente = this.dgvDatos.SelectedRows[0].DataBoundItem as Cliente;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oCliente.IdCliente} {oCliente.Nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _IBLLCliente.DeleteCliente(oCliente.IdCliente);
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

