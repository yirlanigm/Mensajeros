using appProyectoMensajeros.Util;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.Mensajeros.Layers.BLL;
using UTN.Winform.Mensajeros.Layers.Entities;
using UTN.Winform.Mensajeros.Layers.Interfaces;
using UTN.Winform.Mensajeros.Layers.UI.Filtros;
using UTN.Winform.Mensajeros.Layers.UI.Reportes;

namespace UTN.Winform.Mensajeros.Layers.UI.Procesos
{
    public partial class frmFacturacion : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private Cliente _Cliente = null;
        private Mensajero _Mensajero = null;
        private EncabezadoFactura _FacturaEncabezado = null;
        int idTipoEnvio = 0;

        public frmFacturacion()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Carga el formulario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            IBLLFactura _BLLFactura = new BLLFactura();
            try
            {
                // Mostar Numero de factura
                this.txtNumeroFactura.Text = _BLLFactura.GetCurrentNumeroFactura().ToString();
                CargarMapa();
                CargarTarjeta();
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Mensaje    :{0}\n", er.Message);
                msg.AppendFormat("Source     :{0}\n", er.Source);
                msg.AppendFormat("StackTrace :{0}\n", er.StackTrace);
                MessageBox.Show(msg.ToString(), "Atención");

            }
        }

        /// <summary>
        /// Carga el combo Tarjeta, VISA,MASTERD CARD,AMERICAN EXPRESS
        /// </summary>
        private void CargarTarjeta()
        {
            IBLLTarjeta _BLLTarjeta = new BLLTarjeta();
            foreach (var oTarjeta in _BLLTarjeta.GetAllTarjeta())
            {
                this.cmbTarjeta.Items.Add(oTarjeta);
            }
            cmbTarjeta.SelectedIndex = 0;
        }

        // Cargar el mapa
        private void CargarMapa()
        {

            gmap.Zoom = 2;
            gmap.MaxZoom = 35;
            gmap.MinZoom = 2;
            gmap.MouseWheelZoomEnabled = true;
            gmap.RoutesEnabled = true;


            // Esto para que funcione el boton izquierdo del Mouse para mover el mapa
            gmap.DragButton = MouseButtons.Left;
            // Si esta detras de un Proxy
            // GMapProvider.WebProxy = new WebProxy("192.168.120.7", 3128);
            // Se coloca el tipo de mapa 
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            // Colocar la posicion default
            gmap.Position = new PointLatLng(9.9999579356370845, -84.204883575439453);
            // Zoom por defecto
            gmap.Zoom = 13;


        }

        /// <summary>
        /// General el evento para las ubicaciones del mapa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double latitud = 0;
            double longitud = 0;
            List<Placemark> place = null;

            try
            {
                // Obtiene la longitud y latitud
                if (e.Button == MouseButtons.Left)
                {
                    latitud = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
                    longitud = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                }

                // Una sóla línea
                var st = GMapProviders.GoogleMap.GetPlacemarks(gmap.FromLocalToLatLng(e.X, e.Y), out place);

                if (st == GeoCoderStatusCode.G_GEO_SUCCESS && place != null)
                {
                    Direccion oDireccion = new Direccion()
                    {
                        Latitud = latitud,
                        Longitud = longitud,
                        Ubicacion = place[0].CountryName + " " + place[0].DistrictName + " " +
                        place[0].Address,

                    };
                    // Agrega la direcci/n a la lista
                    this.lstDireccion.Items.Add(oDireccion);


                }
            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Mensaje    :{0}\n", er.Message);
                msg.AppendFormat("Source     :{0}\n", er.Source);
                msg.AppendFormat("StackTrace :{0}\n", er.StackTrace);
                MessageBox.Show(msg.ToString(), "Atención");
            }
        }


        /// <summary>
        /// Boton que acerca el mapa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAcercarse_Click(object sender, EventArgs e)
        {
            try
            {
                gmap.Zoom += 1;
            }
            catch (Exception er)
            {


                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Mensaje    :{0}\n", er.Message);
                msg.AppendFormat("Source     :{0}\n", er.Source);
                msg.AppendFormat("StackTrace :{0}\n", er.StackTrace);
                MessageBox.Show(msg.ToString(), "Atención");
            }
            
        }

        /// <summary>
        /// Boton que aleja el mapa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAlejarse_Click(object sender, EventArgs e)
        {
            try
            {
                gmap.Zoom -= 1;
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Mensaje    :{0}\n", er.Message);
                msg.AppendFormat("Source     :{0}\n", er.Source);
                msg.AppendFormat("StackTrace :{0}\n", er.StackTrace);
                MessageBox.Show(msg.ToString(), "Atención");
            }
           
        }

        /// <summary>
        /// Limpia la ruta en el mapa 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonLimpiarRuta_Click(object sender, EventArgs e)
        {
            // Esto se hace para refrescar el mapa sin los Overlays
            gmap.Overlays.Clear();
            gmap.ReloadMap();
            gmap.Update();

        }

        /// <summary>
        /// Muestra la ruta recorrida en el mapa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonMostrarRuta_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstDireccion.Items.Count >= 2)
                {

                    Direccion inicial = lstDireccion.Items[0] as Direccion;
                    Direccion final = lstDireccion.Items[1] as Direccion;
                    // re zoom
                    gmap.Zoom = 13;

                    // marca ruta
                    PointLatLng start = new PointLatLng(inicial.Latitud, inicial.Longitud);
                    PointLatLng end = new PointLatLng(final.Latitud, final.Longitud);

                    MapRoute oMapRoute = BingMapProvider.Instance.GetRoute
                                         (start, end, false, false, 5);

                    if (oMapRoute == null)
                    {

                        MessageBox.Show("Error al obtener ruta, puede ser un error de conexión con internet",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    GMapRoute oGMapRoute = new GMapRoute(oMapRoute.Points, "Mi ruta");
                    GMapOverlay routesOverlay = new GMapOverlay("rutas");
                    routesOverlay.Routes.Add(oGMapRoute);
                    // Limpiar antiguas rutas
                    gmap.Overlays.Clear();
                    gmap.Overlays.Add(routesOverlay);
                    // Actualizar posicion
                    gmap.UpdateRouteLocalPosition(oGMapRoute);


                    this.txtKilometros.Text = Math.Round(oMapRoute.Distance, 2).ToString();

                }
                else
                {
                    MessageBox.Show(
                     "Debe escoger las rutas dando doble click en dos puntos del mapa",
                      "Atención");

                }

            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Mensaje    :{0}\n", er.Message);
                msg.AppendFormat("Source     :{0}\n", er.Source);
                msg.AppendFormat("StackTrace :{0}\n", er.StackTrace);

                MessageBox.Show(msg.ToString(), "Atención");
            }

        }

        /// <summary>
        /// Opcion para crear nueva ruta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonNuevaRuta_Click(object sender, EventArgs e)
        {
            this.lstDireccion.Items.Clear();
            this.txtKilometros.Text = "";
            // Otra forma de limpiar un TextBox


            // Esto se hace para refrescar el mapa sin los Overlays
            gmap.Overlays.Clear();
            gmap.ReloadMap();
            gmap.Update();
        }

        /// <summary>
        /// Filtra el cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFiltrarCliente_Click(object sender, EventArgs e)
        {
            frmFiltroCliente ofrmFiltroCliente = new frmFiltroCliente();
            IBLLCliente _BLLCliente = new BLLCliente();
            try
            {
                erpError.Clear();

                if (!string.IsNullOrEmpty(this.txtClienteId.Text))
                {
                    _Cliente = _BLLCliente.GetClienteById(this.txtClienteId.Text);
                }
                else
                {
                    // Mostrar ventan de filtro
                    ofrmFiltroCliente.ShowDialog();
                    if (ofrmFiltroCliente.DialogResult == DialogResult.OK)
                    {
                        _Cliente = ofrmFiltroCliente._Cliente;
                    }
                }

                if (_Cliente == null)
                {
                    MessageBox.Show("No existe el Cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (string.IsNullOrEmpty(this.txtNumeroTarjeta.Text))
                {
                    erpError.SetError(txtNumeroTarjeta, "Debe indicar un numero de tarjeta");
                    MessageBox.Show("Debe indicar un numero de tarjeta", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
              
                _FacturaEncabezado = new EncabezadoFactura()
                {

                    idNumeroFactura = this.txtNumeroFactura.Text,
                    fecha = DateTime.Now,
                    //montoTotal = double.Parse(this.txtPrecio.Text),
                    idCliente = _Cliente,
                    //idMensajero = _Mensajero,
                    //tipoTarjeta = cmbTarjeta.SelectedItem as Tarjeta,
                    

                };



                this.txtNombreCliente.Text = _Cliente.Nombre.ToString() + " " +
                                              _Cliente.Apellido1.ToString() + " " +
                                               _Cliente.Apellido2.ToString();


                this.txtClienteId.Text = _Cliente.IdCliente;
                this.lstDireccion.Text = _Cliente.Direccion;



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
        /// Evento que genera los precios segun los kilometros y el precio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKilometros_TextChanged(object sender, EventArgs e)
        {
            try
            {
                IBLLPrecioEnvios _BllPrecioEnvio = new BLLPrecioEnvios();
                List<PrecioEnvios> lista = new List<PrecioEnvios>();
                lista = _BllPrecioEnvio.GetAllPrecioEnvios();
                foreach (PrecioEnvios item in lista)
                {
                    if (item.KilometroInicial < (double.Parse(txtKilometros.Text)) && item.KilometroFinal > (double.Parse(txtKilometros.Text)))
                    {
                        txtPrecio.Text = item.Precio.ToString();
                        idTipoEnvio = 0;
                    }
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

        /// <summary>
        /// Boton que guarda la informacion digitada y la muestra en el dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            IBLLImpuesto _BLLImpuesto = new BLLImpuesto();
           DetalleFactura oFacturaDetalle = new DetalleFactura();

            try
            {
                erpError.Clear();

                if (_FacturaEncabezado == null)
                {
                    MessageBox.Show("Debe agregar los datos del encabezado de la factura para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            
                if (string.IsNullOrEmpty(this.txtCantidadPaquetes.Text))
                {
                    txtCantidadPaquetes.Focus();
                    erpError.SetError(txtCantidadPaquetes, "Debe ingresar la cantidad de paquetes");
                    return;
                }



                if (double.Parse(this.txtCantidadPaquetes.Text) <= 0)
                {
                    txtCantidadPaquetes.Focus();
                    erpError.SetError(txtCantidadPaquetes, "La cantidad debe ser mayor a CERO");
                    return;
                }

                if (double.Parse(this.txtCantidadPaquetes.Text) > double.Parse(this.txtCantidadPaquetes.Text))
                {
                    txtCantidadPaquetes.Focus();
                    MessageBox.Show("Insuficiente cantidad", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    erpError.SetError(txtCantidadPaquetes, "Insuficiente cantidad");
                    return;
                }

                oFacturaDetalle.CantidadPaquetes = (int.Parse(txtCantidadPaquetes.Text));
                oFacturaDetalle.Kilometros = double.Parse(txtKilometros.Text);
                oFacturaDetalle.PrecioCalculado = double.Parse(this.txtPrecio.Text);
                oFacturaDetalle.DescripcionRuta = this.lstDireccion.Text;
                
                // Calcular el Impuesto
                oFacturaDetalle.Impuesto = ((double)_BLLImpuesto.GetImpuesto().Porcentaje / 100D) * oFacturaDetalle.PrecioCalculado * oFacturaDetalle.CantidadPaquetes;
                // Enumerar la secuencia
                oFacturaDetalle.Secuencia = _FacturaEncabezado._ListaFacturaDetalle.Count == 0 ?
                                                 1 : _FacturaEncabezado._ListaFacturaDetalle.Max(p => p.Secuencia) + 1;
                // Agregar
                _FacturaEncabezado.AddDetalle(oFacturaDetalle);


                string[] lineaFactura = {oFacturaDetalle.Secuencia.ToString(),
                                         this.txtCantidadPaquetes.Text,
                                         this.txtKilometros.Text,
                                         this.txtPrecio.Text,
                                         

                                         oFacturaDetalle.Impuesto.ToString(),
                                         oFacturaDetalle.PrecioCalculado.ToString(),
                                         oFacturaDetalle.DescripcionRuta.ToString(),
                                         (oFacturaDetalle.CantidadPaquetes * oFacturaDetalle.PrecioCalculado).ToString()
                                         };

                this.dgvDetalleEnvio.Rows.Add(lineaFactura);

                this.txtSubtotal.Text = _FacturaEncabezado.GetSubTotal().ToString();
                this.txtImpuesto.Text = _FacturaEncabezado.GetImpuesto().ToString();
                this.txtTotal.Text = (_FacturaEncabezado.GetSubTotal() + _FacturaEncabezado.GetImpuesto()).ToString();

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
        /// Filtra el Mensajero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFiltrarMensajero_Click(object sender, EventArgs e)
        {
            frmFiltroMensajero ofrmFiltroMensajero = new frmFiltroMensajero();
            IBLLMensajeros _BLLMensajeros = new BLLMensajeros();
            try
            {
                erpError.Clear();

                if (!string.IsNullOrEmpty(this.txtIdMensajero.Text))
                {
                    _Mensajero = _BLLMensajeros.GetMensajeroById(this.txtIdMensajero.Text);
                }
                else
                {
                    // Mostrar ventan de filtro
                    ofrmFiltroMensajero.ShowDialog();
                    if (ofrmFiltroMensajero.DialogResult == DialogResult.OK)
                    {
                        _Mensajero = ofrmFiltroMensajero._Mensajero;
                    }
                }

                if (_Mensajero == null)
                {
                    MessageBox.Show("No existe el Mensajero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _FacturaEncabezado = new EncabezadoFactura()
                {

                    idNumeroFactura = this.txtNumeroFactura.Text,
                    fecha = DateTime.Now,
                    //montoTotal = double.Parse(this.txtPrecio.Text),
                    //idCliente = _Cliente,
                    idMensajero = _Mensajero,
                    //tipoTarjeta = cmbTarjeta.SelectedItem as Tarjeta,
                    

                };



                this.txtNombreMensajero.Text = _Mensajero.nombre.ToString() + " " +
                                              _Mensajero.Apellido1.ToString() + " " +
                                               _Mensajero.Apellido2.ToString();


                this.txtIdMensajero.Text = _Mensajero.idMensajero;
                


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

        //private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        //{

        //}

        /// <summary>
        /// Boton que limpia todos los campos del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonNuevo_Click_1(object sender, EventArgs e)
        {
            IBLLFactura _BLLFactura = new BLLFactura();

            try
            {

                _Cliente = null;
                _Mensajero = null;
                this.cmbTarjeta.SelectedIndex = 0;
                this.txtNumeroTarjeta.Text = "";
                this.txtClienteId.Text = "";
                this.txtNombreCliente.Text = "-";
                this.txtIdMensajero.Text = "";
                this.txtNombreMensajero.Text = "-";
                this.txtCantidadPaquetes.Text = "";
                this.txtPrecio.Text = ""; 
                this.txtSubtotal.Text = "";
                this.txtImpuesto.Text = "";
                this.txtTotal.Text = "";
                this.lstDireccion.Items.Clear();
                this.txtKilometros.Text = "";
               
                // Esto se hace para refrescar el mapa sin los Overlays
                gmap.Overlays.Clear();
                gmap.ReloadMap();
                gmap.Update();


                txtNumeroTarjeta.Focus();
                _FacturaEncabezado = null;
                this.dgvDetalleEnvio.Rows.Clear();
                // Mostar Numero de factura
                this.txtNumeroFactura.Text = _BLLFactura.GetNextNumeroFactura().ToString();
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
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonFacturar_Click(object sender, EventArgs e)
        {
            IBLLFactura _BLLFactura = new BLLFactura();
            string rutaImagen = @"c:\temp\qr.png";
            double numeroFactura = 0d;
            try
            {
                if (_Cliente == null)
                {
                    MessageBox.Show("Debe Seleccionar un Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtClienteId.Focus();
                    return;
                }

                if (_FacturaEncabezado == null)
                {
                    MessageBox.Show("No hay datos por facturar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_FacturaEncabezado._ListaFacturaDetalle.Count == 0)
                {
                    MessageBox.Show("No hay items en la factura ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _FacturaEncabezado = _BLLFactura.SaveFactura(_FacturaEncabezado);

                numeroFactura = double.Parse(_FacturaEncabezado.idNumeroFactura);

                if (_FacturaEncabezado == null)
                    MessageBox.Show("Error al crear factura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    toolStripButtonNuevo_Click_1(null, null);


                // Si existe borrelo
                if (File.Exists(rutaImagen))
                    File.Delete(rutaImagen);

                // Crear imagen quickresponse
                Image quickResponseImage = QuickResponse.QuickResponseGenerador(numeroFactura.ToString(), 53);

                // Salvarla en c:\temp para luego ser leida
                quickResponseImage.Save(rutaImagen, ImageFormat.Png);

                //frmReporteFactura ofrmReporteFactura = new frmReporteFactura((decimal)numeroFactura);
                //ofrmReporteFactura.ShowDialog();
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
