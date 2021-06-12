using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.Mensajeros.Layers.BLL;
using UTN.Winform.Mensajeros.Layers.Entities;
using UTN.Winform.Mensajeros.Layers.Interfaces;

namespace UTN.Winform.Mensajeros.Layers.UI.Mantenimientos
{
    public partial class frmMantenimientoMensajero : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmMantenimientoMensajero()
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

        private void frmMantenimientoMensajero_Load(object sender, EventArgs e)
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
        private void CargarDatos()
        {
            IBLLMensajeros _IBLLMensajeros = new BLLMensajeros();
            //IBLLBodega _BLLBodega = new BLLBodega();
            //List<Bodega> lista = null;

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            // Configuracion del DataGridView para que se vea bien la imagen.
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            
            this.pbImagen.Enabled = false;

            // Cargar el DataGridView
            this.dgvDatos.DataSource = _IBLLMensajeros.GetAllMensajero();

         

            // Colocar la imagen de Word por defecto
            
            this.pbImagen.Image = Mensajeros.Properties.Resources.camera_web_2;
            this.pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;



        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.mskIdentificacion.Clear();
            this.txtNombre.Clear();
            this.txtApellido1.Clear();
            this.txtApellido2.Clear();
            this.mskCelular.Clear();
            this.pbImagen.Tag = null;
            this.txtEmail.Clear();

            this.mskIdentificacion.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellido1.Enabled = false;
            this.txtApellido2.Enabled = false;
            this.mskCelular.Enabled = false;
            this.pbImagen.Enabled = false;
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.txtEmail.Enabled = false;
            this.rdbFemenino.Enabled = false;
            this.rdbMasculino.Enabled = false;
            

            // Colocar la imagen de Word por defecto
            
            this.pbImagen.Image = Mensajeros.Properties.Resources.camera_web_2;
            this.pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;
            

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.mskIdentificacion.Enabled = true;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.mskCelular.Enabled = true;
                    this.pbImagen.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.txtEmail.Enabled = true;
                    this.rdbFemenino.Enabled = true;
                    this.rdbMasculino.Enabled = true;
                    rdbFemenino.Focus();
                    mskIdentificacion.Focus();
                    break;
                case EstadoMantenimiento.Editar:
                    this.mskIdentificacion.Enabled = false;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.mskCelular.Enabled = true;
                    this.pbImagen.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.txtEmail.Enabled = true; ;
                    mskIdentificacion.Focus();
                    break;
                case EstadoMantenimiento.Borrar:
                    break;
                case EstadoMantenimiento.Ninguno:
                    break;
            }
        }


        #endregion

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Nuevo);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Ninguno);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Mensajero oMensajero = null;

            try
            {
                IBLLMensajeros _IBLLMensajeros = new BLLMensajeros();


                if (this.pbImagen.Tag == null)
                {

                    MessageBox.Show("La Imagen  es un dato requerido !", "Atención");
                    return;
                }

           

                oMensajero = new Mensajero();

                oMensajero.idMensajero = this.mskIdentificacion.Text;
                oMensajero.nombre = this.txtNombre.Text;
                oMensajero.Apellido1 = this.txtApellido1.Text;
                oMensajero.Apellido2 = this.txtApellido2.Text;
                oMensajero.Fotografia = (byte[])this.pbImagen.Tag;
                oMensajero.Email = this.txtEmail.Text;
                oMensajero.Telefono = this.mskCelular.Text;
                oMensajero.sexo = rdbFemenino.Checked ? true : false; 
                

                oMensajero = _IBLLMensajeros.SaveMensajero(oMensajero);

                if (oMensajero != null)
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

        private void verImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pbImagen.Tag != null)
                {

                    if (!Directory.Exists(@"C:\temp"))
                        Directory.CreateDirectory(@"C:\temp");

                    File.WriteAllBytes(@"C:\temp\imagen.jpg", (byte[])this.pbImagen.Tag);
                    Process.Start(@"C:\temp\imagen.jpg");
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

        private void pbImagen_Click(object sender, EventArgs e)
        {
             try
            {
                OpenFileDialog opt = new OpenFileDialog();
                opt.Title = "Seleccione la Imagen ";
                opt.SupportMultiDottedExtensions = true;
                opt.DefaultExt = "*.jpg";
                opt.Filter = "Archivos de Imagenes (*.jpg)|*.jpg| All files (*.*)|*.*";
                opt.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                opt.FileName = "";

                if (opt.ShowDialog(this) == DialogResult.OK)
                {

                    //ruta = opt.FileName.Trim();
                    this.pbImagen.ImageLocation = opt.FileName;
                    pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

                    byte[] cadenaBytes = File.ReadAllBytes(opt.FileName);

                    // Guarla la imagenen Bytes en el Tag de la imagen.
                    pbImagen.Tag = (byte[])cadenaBytes;

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

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            Mensajero oMensajero = null;
            IBLLMensajeros _BLLMensajero = new BLLMensajeros();

            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    // Cambiar de estado
                    this.CambiarEstado(EstadoMantenimiento.Editar);
                    oMensajero = this.dgvDatos.SelectedRows[0].DataBoundItem as Mensajero;
                    this.mskIdentificacion.Text = oMensajero.idMensajero;
                    this.txtNombre.Text = oMensajero.nombre;
                    this.txtApellido1.Text = oMensajero.Apellido1;
                    this.txtApellido2.Text = oMensajero.Apellido2;
                    this.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pbImagen.Image = new Bitmap(new MemoryStream(oMensajero.Fotografia));
                    this.pbImagen.Tag = oMensajero.Fotografia;
                    this.txtEmail.Text = oMensajero.Email;
                    this.mskCelular.Text = oMensajero.Telefono;
                    

                    _BLLMensajero.SaveMensajero(oMensajero);

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

        private void toolStripBtnBorrar_Click(object sender, EventArgs e)
        {
            IBLLMensajeros _BLLMensajeros = new BLLMensajeros();

            try
            {

                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    this.CambiarEstado(EstadoMantenimiento.Borrar);

                    Mensajero oMensajero = this.dgvDatos.SelectedRows[0].DataBoundItem as Mensajero;
                    if (MessageBox.Show($"¿Seguro que desea borrar el registro {oMensajero.idMensajero} {oMensajero.nombre}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _BLLMensajeros.DeleteMensajero(oMensajero.idMensajero);
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
