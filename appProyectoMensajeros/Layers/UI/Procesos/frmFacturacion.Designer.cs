namespace UTN.Winform.Mensajeros.Layers.UI.Procesos
{
    partial class frmFacturacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFacturar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSalir = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBoxDetalleEnvio = new System.Windows.Forms.GroupBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCantidadPaquetes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKilometros = new System.Windows.Forms.TextBox();
            this.lstDireccion = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMostrarRuta = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAcercarse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAlejarse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLimpiarRuta = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNuevaRuta = new System.Windows.Forms.ToolStripButton();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.dgvDetalleEnvio = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxFacturacion = new System.Windows.Forms.GroupBox();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNombreMensajero = new System.Windows.Forms.TextBox();
            this.btnFiltrarMensajero = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdMensajero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTarjeta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtClienteId = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnFiltrarCliente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.erpError = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            this.groupBoxDetalleEnvio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleEnvio)).BeginInit();
            this.groupBoxFacturacion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNuevo,
            this.toolStripButtonFacturar,
            this.toolStripButtonSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1112, 57);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "tspBarraPrincipal";
            // 
            // toolStripButtonNuevo
            // 
            this.toolStripButtonNuevo.Image = global::UTN.Winform.Mensajeros.Properties.Resources.iconoNuevo;
            this.toolStripButtonNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNuevo.Name = "toolStripButtonNuevo";
            this.toolStripButtonNuevo.Size = new System.Drawing.Size(93, 54);
            this.toolStripButtonNuevo.Text = "Nuevo";
            this.toolStripButtonNuevo.Click += new System.EventHandler(this.toolStripButtonNuevo_Click_1);
            // 
            // toolStripButtonFacturar
            // 
            this.toolStripButtonFacturar.Image = global::UTN.Winform.Mensajeros.Properties.Resources.iconofac;
            this.toolStripButtonFacturar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonFacturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFacturar.Name = "toolStripButtonFacturar";
            this.toolStripButtonFacturar.Size = new System.Drawing.Size(97, 54);
            this.toolStripButtonFacturar.Text = "Facturar";
            this.toolStripButtonFacturar.Click += new System.EventHandler(this.toolStripButtonFacturar_Click);
            // 
            // toolStripButtonSalir
            // 
            this.toolStripButtonSalir.Image = global::UTN.Winform.Mensajeros.Properties.Resources.window_close_2;
            this.toolStripButtonSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSalir.Name = "toolStripButtonSalir";
            this.toolStripButtonSalir.Size = new System.Drawing.Size(81, 54);
            this.toolStripButtonSalir.Text = "Salir";
            this.toolStripButtonSalir.Click += new System.EventHandler(this.toolStripButtonSalir_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1112, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "sttBarraInferior";
            // 
            // groupBoxDetalleEnvio
            // 
            this.groupBoxDetalleEnvio.Controls.Add(this.txtPrecio);
            this.groupBoxDetalleEnvio.Controls.Add(this.label13);
            this.groupBoxDetalleEnvio.Controls.Add(this.btnGuardar);
            this.groupBoxDetalleEnvio.Controls.Add(this.txtCantidadPaquetes);
            this.groupBoxDetalleEnvio.Controls.Add(this.label7);
            this.groupBoxDetalleEnvio.Controls.Add(this.label6);
            this.groupBoxDetalleEnvio.Controls.Add(this.label1);
            this.groupBoxDetalleEnvio.Controls.Add(this.txtKilometros);
            this.groupBoxDetalleEnvio.Controls.Add(this.lstDireccion);
            this.groupBoxDetalleEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDetalleEnvio.Location = new System.Drawing.Point(8, 318);
            this.groupBoxDetalleEnvio.Name = "groupBoxDetalleEnvio";
            this.groupBoxDetalleEnvio.Size = new System.Drawing.Size(424, 170);
            this.groupBoxDetalleEnvio.TabIndex = 2;
            this.groupBoxDetalleEnvio.TabStop = false;
            this.groupBoxDetalleEnvio.Text = "Detalle Envio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(135, 73);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(205, 20);
            this.txtPrecio.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Precio";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Sitka Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::UTN.Winform.Mensajeros.Properties.Resources.dialog_accept;
            this.btnGuardar.Location = new System.Drawing.Point(356, 108);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(52, 56);
            this.btnGuardar.TabIndex = 28;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCantidadPaquetes
            // 
            this.txtCantidadPaquetes.Location = new System.Drawing.Point(135, 17);
            this.txtCantidadPaquetes.Name = "txtCantidadPaquetes";
            this.txtCantidadPaquetes.Size = new System.Drawing.Size(205, 20);
            this.txtCantidadPaquetes.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Kilometros";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cantidad Paquetes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Descripcion";
            // 
            // txtKilometros
            // 
            this.txtKilometros.Enabled = false;
            this.txtKilometros.Location = new System.Drawing.Point(135, 43);
            this.txtKilometros.Name = "txtKilometros";
            this.txtKilometros.Size = new System.Drawing.Size(205, 20);
            this.txtKilometros.TabIndex = 5;
            this.txtKilometros.TextChanged += new System.EventHandler(this.txtKilometros_TextChanged);
            // 
            // lstDireccion
            // 
            this.lstDireccion.Enabled = false;
            this.lstDireccion.FormattingEnabled = true;
            this.lstDireccion.Location = new System.Drawing.Point(135, 108);
            this.lstDireccion.Name = "lstDireccion";
            this.lstDireccion.Size = new System.Drawing.Size(205, 56);
            this.lstDireccion.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(438, 44);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetalleEnvio);
            this.splitContainer1.Size = new System.Drawing.Size(650, 531);
            this.splitContainer1.SplitterDistance = 311;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.gmap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 307);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMostrarRuta,
            this.toolStripButtonAcercarse,
            this.toolStripButtonAlejarse,
            this.toolStripButtonLimpiarRuta,
            this.toolStripButtonNuevaRuta});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(646, 75);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonMostrarRuta
            // 
            this.toolStripButtonMostrarRuta.Image = global::UTN.Winform.Mensajeros.Properties.Resources.iconoLupa;
            this.toolStripButtonMostrarRuta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonMostrarRuta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMostrarRuta.Name = "toolStripButtonMostrarRuta";
            this.toolStripButtonMostrarRuta.Size = new System.Drawing.Size(147, 72);
            this.toolStripButtonMostrarRuta.Text = "Mostrar Ruta";
            this.toolStripButtonMostrarRuta.Click += new System.EventHandler(this.toolStripButtonMostrarRuta_Click);
            // 
            // toolStripButtonAcercarse
            // 
            this.toolStripButtonAcercarse.Image = global::UTN.Winform.Mensajeros.Properties.Resources.zoom_in_3;
            this.toolStripButtonAcercarse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAcercarse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAcercarse.Name = "toolStripButtonAcercarse";
            this.toolStripButtonAcercarse.Size = new System.Drawing.Size(126, 72);
            this.toolStripButtonAcercarse.Text = "Acercarse";
            this.toolStripButtonAcercarse.Click += new System.EventHandler(this.toolStripButtonAcercarse_Click);
            // 
            // toolStripButtonAlejarse
            // 
            this.toolStripButtonAlejarse.Image = global::UTN.Winform.Mensajeros.Properties.Resources.zoom_out_3;
            this.toolStripButtonAlejarse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAlejarse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAlejarse.Name = "toolStripButtonAlejarse";
            this.toolStripButtonAlejarse.Size = new System.Drawing.Size(116, 72);
            this.toolStripButtonAlejarse.Text = "Alejarse";
            this.toolStripButtonAlejarse.Click += new System.EventHandler(this.toolStripButtonAlejarse_Click);
            // 
            // toolStripButtonLimpiarRuta
            // 
            this.toolStripButtonLimpiarRuta.Image = global::UTN.Winform.Mensajeros.Properties.Resources.iconoEscoba;
            this.toolStripButtonLimpiarRuta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonLimpiarRuta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLimpiarRuta.Name = "toolStripButtonLimpiarRuta";
            this.toolStripButtonLimpiarRuta.Size = new System.Drawing.Size(129, 72);
            this.toolStripButtonLimpiarRuta.Text = "Limpiar Ruta";
            this.toolStripButtonLimpiarRuta.Click += new System.EventHandler(this.toolStripButtonLimpiarRuta_Click);
            // 
            // toolStripButtonNuevaRuta
            // 
            this.toolStripButtonNuevaRuta.Image = global::UTN.Winform.Mensajeros.Properties.Resources.descarga11111;
            this.toolStripButtonNuevaRuta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonNuevaRuta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNuevaRuta.Name = "toolStripButtonNuevaRuta";
            this.toolStripButtonNuevaRuta.Size = new System.Drawing.Size(117, 72);
            this.toolStripButtonNuevaRuta.Text = "Nueva Ruta";
            this.toolStripButtonNuevaRuta.Click += new System.EventHandler(this.toolStripButtonNuevaRuta_Click);
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(3, 60);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(690, 239);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            this.gmap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseDoubleClick);
            // 
            // dgvDetalleEnvio
            // 
            this.dgvDetalleEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleEnvio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column6});
            this.dgvDetalleEnvio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleEnvio.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalleEnvio.Name = "dgvDetalleEnvio";
            this.dgvDetalleEnvio.Size = new System.Drawing.Size(646, 212);
            this.dgvDetalleEnvio.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cantidad Paquetes";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Kilometros";
            this.Column2.Name = "Column2";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Total";
            this.Column6.Name = "Column6";
            // 
            // groupBoxFacturacion
            // 
            this.groupBoxFacturacion.Controls.Add(this.txtNumeroTarjeta);
            this.groupBoxFacturacion.Controls.Add(this.label14);
            this.groupBoxFacturacion.Controls.Add(this.txtNombreMensajero);
            this.groupBoxFacturacion.Controls.Add(this.btnFiltrarMensajero);
            this.groupBoxFacturacion.Controls.Add(this.label5);
            this.groupBoxFacturacion.Controls.Add(this.txtIdMensajero);
            this.groupBoxFacturacion.Controls.Add(this.label2);
            this.groupBoxFacturacion.Controls.Add(this.cmbTarjeta);
            this.groupBoxFacturacion.Controls.Add(this.label4);
            this.groupBoxFacturacion.Controls.Add(this.txtNumeroFactura);
            this.groupBoxFacturacion.Controls.Add(this.label11);
            this.groupBoxFacturacion.Controls.Add(this.txtClienteId);
            this.groupBoxFacturacion.Controls.Add(this.txtNombreCliente);
            this.groupBoxFacturacion.Controls.Add(this.label3);
            this.groupBoxFacturacion.Controls.Add(this.label12);
            this.groupBoxFacturacion.Controls.Add(this.btnFiltrarCliente);
            this.groupBoxFacturacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFacturacion.Location = new System.Drawing.Point(8, 60);
            this.groupBoxFacturacion.Name = "groupBoxFacturacion";
            this.groupBoxFacturacion.Size = new System.Drawing.Size(429, 252);
            this.groupBoxFacturacion.TabIndex = 4;
            this.groupBoxFacturacion.TabStop = false;
            this.groupBoxFacturacion.Text = "Facturacion";
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(89, 81);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(279, 20);
            this.txtNumeroTarjeta.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "No.Tarjeta";
            // 
            // txtNombreMensajero
            // 
            this.txtNombreMensajero.Location = new System.Drawing.Point(127, 222);
            this.txtNombreMensajero.Name = "txtNombreMensajero";
            this.txtNombreMensajero.ReadOnly = true;
            this.txtNombreMensajero.Size = new System.Drawing.Size(213, 20);
            this.txtNombreMensajero.TabIndex = 28;
            // 
            // btnFiltrarMensajero
            // 
            this.btnFiltrarMensajero.Font = new System.Drawing.Font("Sitka Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarMensajero.Image = global::UTN.Winform.Mensajeros.Properties.Resources.iconLupaFiltro;
            this.btnFiltrarMensajero.Location = new System.Drawing.Point(356, 184);
            this.btnFiltrarMensajero.Name = "btnFiltrarMensajero";
            this.btnFiltrarMensajero.Size = new System.Drawing.Size(52, 58);
            this.btnFiltrarMensajero.TabIndex = 27;
            this.btnFiltrarMensajero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrarMensajero.UseVisualStyleBackColor = true;
            this.btnFiltrarMensajero.Click += new System.EventHandler(this.btnFiltrarMensajero_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Nombre Mensajero";
            // 
            // txtIdMensajero
            // 
            this.txtIdMensajero.Location = new System.Drawing.Point(127, 187);
            this.txtIdMensajero.Name = "txtIdMensajero";
            this.txtIdMensajero.Size = new System.Drawing.Size(213, 20);
            this.txtIdMensajero.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Id Mensajero";
            // 
            // cmbTarjeta
            // 
            this.cmbTarjeta.FormattingEnabled = true;
            this.cmbTarjeta.Location = new System.Drawing.Point(89, 48);
            this.cmbTarjeta.Name = "cmbTarjeta";
            this.cmbTarjeta.Size = new System.Drawing.Size(251, 21);
            this.cmbTarjeta.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tarjeta";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(89, 25);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.ReadOnly = true;
            this.txtNumeroFactura.Size = new System.Drawing.Size(251, 20);
            this.txtNumeroFactura.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "No. Factura";
            // 
            // txtClienteId
            // 
            this.txtClienteId.Location = new System.Drawing.Point(61, 107);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.Size = new System.Drawing.Size(279, 20);
            this.txtClienteId.TabIndex = 17;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(127, 137);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(213, 20);
            this.txtNombreCliente.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Cliente";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Nombre Cliente";
            // 
            // btnFiltrarCliente
            // 
            this.btnFiltrarCliente.Font = new System.Drawing.Font("Sitka Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarCliente.Image = global::UTN.Winform.Mensajeros.Properties.Resources.iconLupaFiltro;
            this.btnFiltrarCliente.Location = new System.Drawing.Point(356, 107);
            this.btnFiltrarCliente.Name = "btnFiltrarCliente";
            this.btnFiltrarCliente.Size = new System.Drawing.Size(52, 50);
            this.btnFiltrarCliente.TabIndex = 0;
            this.btnFiltrarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrarCliente.UseVisualStyleBackColor = true;
            this.btnFiltrarCliente.Click += new System.EventHandler(this.btnFiltrarCliente_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.txtImpuesto);
            this.groupBox1.Controls.Add(this.txtSubtotal);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 494);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 106);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(83, 71);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(117, 20);
            this.txtTotal.TabIndex = 5;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Location = new System.Drawing.Point(83, 42);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Size = new System.Drawing.Size(117, 20);
            this.txtImpuesto.TabIndex = 4;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(83, 18);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(117, 20);
            this.txtSubtotal.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Impuesto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sub Total";
            // 
            // erpError
            // 
            this.erpError.ContainerControl = this;
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 600);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxFacturacion);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBoxDetalleEnvio);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxDetalleEnvio.ResumeLayout(false);
            this.groupBoxDetalleEnvio.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleEnvio)).EndInit();
            this.groupBoxFacturacion.ResumeLayout(false);
            this.groupBoxFacturacion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNuevo;
        private System.Windows.Forms.ToolStripButton toolStripButtonFacturar;
        private System.Windows.Forms.ToolStripButton toolStripButtonSalir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBoxDetalleEnvio;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonMostrarRuta;
        private System.Windows.Forms.ToolStripButton toolStripButtonAcercarse;
        private System.Windows.Forms.ToolStripButton toolStripButtonAlejarse;
        private System.Windows.Forms.ToolStripButton toolStripButtonLimpiarRuta;
        private System.Windows.Forms.ToolStripButton toolStripButtonNuevaRuta;
        private System.Windows.Forms.GroupBox groupBoxFacturacion;
        private System.Windows.Forms.DataGridView dgvDetalleEnvio;
        private System.Windows.Forms.ComboBox cmbTarjeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtClienteId;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnFiltrarCliente;
        private System.Windows.Forms.Button btnFiltrarMensajero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdMensajero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantidadPaquetes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKilometros;
        private System.Windows.Forms.ListBox lstDireccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.TextBox txtNombreMensajero;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider erpError;
        private System.Windows.Forms.TextBox txtNumeroTarjeta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}