namespace appProyectoMensajeros.Layers.UI
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.mspMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mensajeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.precioPorEnvióToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porRangoDeFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mspMenuPrincipal.SuspendLayout();
            this.sttBarraInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMenuPrincipal
            // 
            this.mspMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientosToolStripMenuItem,
            this.procesosToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.administracionToolStripMenuItem,
            this.ToolStripMenuItemAcercaDe,
            this.salirToolStripMenuItem});
            this.mspMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mspMenuPrincipal.Name = "mspMenuPrincipal";
            this.mspMenuPrincipal.Size = new System.Drawing.Size(765, 65);
            this.mspMenuPrincipal.TabIndex = 0;
            this.mspMenuPrincipal.Text = "menuStrip1";
            // 
            // mantenimientosToolStripMenuItem
            // 
            this.mantenimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.mensajeroToolStripMenuItem,
            this.precioPorEnvióToolStripMenuItem});
            this.mantenimientosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mantenimientosToolStripMenuItem.Image")));
            this.mantenimientosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            this.mantenimientosToolStripMenuItem.Size = new System.Drawing.Size(163, 61);
            this.mantenimientosToolStripMenuItem.Text = "Mantenimientos";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clienteToolStripMenuItem.Image")));
            this.clienteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(193, 54);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // mensajeroToolStripMenuItem
            // 
            this.mensajeroToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mensajeroToolStripMenuItem.Image")));
            this.mensajeroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mensajeroToolStripMenuItem.Name = "mensajeroToolStripMenuItem";
            this.mensajeroToolStripMenuItem.Size = new System.Drawing.Size(193, 54);
            this.mensajeroToolStripMenuItem.Text = "Mensajero";
            this.mensajeroToolStripMenuItem.Click += new System.EventHandler(this.mensajeroToolStripMenuItem_Click);
            // 
            // precioPorEnvióToolStripMenuItem
            // 
            this.precioPorEnvióToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("precioPorEnvióToolStripMenuItem.Image")));
            this.precioPorEnvióToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.precioPorEnvióToolStripMenuItem.Name = "precioPorEnvióToolStripMenuItem";
            this.precioPorEnvióToolStripMenuItem.Size = new System.Drawing.Size(193, 54);
            this.precioPorEnvióToolStripMenuItem.Text = "Precio por envió";
            this.precioPorEnvióToolStripMenuItem.Click += new System.EventHandler(this.precioPorEnvióToolStripMenuItem_Click);
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturacionToolStripMenuItem});
            this.procesosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("procesosToolStripMenuItem.Image")));
            this.procesosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            this.procesosToolStripMenuItem.Size = new System.Drawing.Size(114, 61);
            this.procesosToolStripMenuItem.Text = "Procesos";
            // 
            // facturacionToolStripMenuItem
            // 
            this.facturacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("facturacionToolStripMenuItem.Image")));
            this.facturacionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.facturacionToolStripMenuItem.Name = "facturacionToolStripMenuItem";
            this.facturacionToolStripMenuItem.Size = new System.Drawing.Size(179, 56);
            this.facturacionToolStripMenuItem.Text = "Facturacion";
            this.facturacionToolStripMenuItem.Click += new System.EventHandler(this.facturacionToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porRangoDeFechaToolStripMenuItem,
            this.graficoToolStripMenuItem});
            this.reportesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportesToolStripMenuItem.Image")));
            this.reportesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(108, 61);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // porRangoDeFechaToolStripMenuItem
            // 
            this.porRangoDeFechaToolStripMenuItem.Image = global::UTN.Winform.Mensajeros.Properties.Resources.iconocalendario;
            this.porRangoDeFechaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.porRangoDeFechaToolStripMenuItem.Name = "porRangoDeFechaToolStripMenuItem";
            this.porRangoDeFechaToolStripMenuItem.Size = new System.Drawing.Size(206, 54);
            this.porRangoDeFechaToolStripMenuItem.Text = "Por rango de fecha";
            this.porRangoDeFechaToolStripMenuItem.Click += new System.EventHandler(this.porRangoDeFechaToolStripMenuItem_Click);
            // 
            // graficoToolStripMenuItem
            // 
            this.graficoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprasClienteToolStripMenuItem});
            this.graficoToolStripMenuItem.Image = global::UTN.Winform.Mensajeros.Properties.Resources.office_chart_pie;
            this.graficoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.graficoToolStripMenuItem.Name = "graficoToolStripMenuItem";
            this.graficoToolStripMenuItem.Size = new System.Drawing.Size(206, 54);
            this.graficoToolStripMenuItem.Text = "Grafico";
            this.graficoToolStripMenuItem.Click += new System.EventHandler(this.graficoToolStripMenuItem_Click);
            // 
            // comprasClienteToolStripMenuItem
            // 
            this.comprasClienteToolStripMenuItem.Image = global::UTN.Winform.Mensajeros.Properties.Resources.iconocompras;
            this.comprasClienteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.comprasClienteToolStripMenuItem.Name = "comprasClienteToolStripMenuItem";
            this.comprasClienteToolStripMenuItem.Size = new System.Drawing.Size(193, 54);
            this.comprasClienteToolStripMenuItem.Text = "Compras Cliente";
            this.comprasClienteToolStripMenuItem.Click += new System.EventHandler(this.comprasClienteToolStripMenuItem_Click);
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem});
            this.administracionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administracionToolStripMenuItem.Image")));
            this.administracionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(144, 61);
            this.administracionToolStripMenuItem.Text = "Administracion";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Image = global::UTN.Winform.Mensajeros.Properties.Resources.user_new_3;
            this.usuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(151, 54);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // ToolStripMenuItemAcercaDe
            // 
            this.ToolStripMenuItemAcercaDe.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItemAcercaDe.Image")));
            this.ToolStripMenuItemAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolStripMenuItemAcercaDe.Name = "ToolStripMenuItemAcercaDe";
            this.ToolStripMenuItemAcercaDe.Size = new System.Drawing.Size(125, 61);
            this.ToolStripMenuItemAcercaDe.Text = "Acerca de..";
            this.ToolStripMenuItemAcercaDe.Click += new System.EventHandler(this.ToolStripMenuItemAcercaDe_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::UTN.Winform.Mensajeros.Properties.Resources.window_close_2;
            this.salirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(89, 61);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click_1);
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 432);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Size = new System.Drawing.Size(765, 22);
            this.sttBarraInferior.TabIndex = 1;
            this.sttBarraInferior.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel1.Text = "-";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(765, 454);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.mspMenuPrincipal);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mspMenuPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mspMenuPrincipal.ResumeLayout(false);
            this.mspMenuPrincipal.PerformLayout();
            this.sttBarraInferior.ResumeLayout(false);
            this.sttBarraInferior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspMenuPrincipal;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.ToolStripMenuItem mantenimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAcercaDe;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mensajeroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem precioPorEnvióToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porRangoDeFechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graficoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}