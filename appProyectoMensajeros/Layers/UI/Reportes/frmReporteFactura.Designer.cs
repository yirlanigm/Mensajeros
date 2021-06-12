namespace UTN.Winform.Mensajeros.Layers.UI.Reportes
{
    partial class frmReporteFactura
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
            this.tspBarraSuperior = new System.Windows.Forms.ToolStrip();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.toolStripBtnExportarPDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnEnviarEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tspBarraSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspBarraSuperior
            // 
            this.tspBarraSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnExportarPDF,
            this.toolStripBtnEnviarEmail,
            this.toolStripBtnSalir});
            this.tspBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.tspBarraSuperior.Name = "tspBarraSuperior";
            this.tspBarraSuperior.Size = new System.Drawing.Size(694, 64);
            this.tspBarraSuperior.TabIndex = 0;
            this.tspBarraSuperior.Text = "toolStrip1";
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 424);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Size = new System.Drawing.Size(694, 22);
            this.sttBarraInferior.TabIndex = 1;
            this.sttBarraInferior.Text = "statusStrip1";
            // 
            // toolStripBtnExportarPDF
            // 
            this.toolStripBtnExportarPDF.Image = global::UTN.Winform.Mensajeros.Properties.Resources.pdfforge;
            this.toolStripBtnExportarPDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnExportarPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExportarPDF.Name = "toolStripBtnExportarPDF";
            this.toolStripBtnExportarPDF.Size = new System.Drawing.Size(126, 61);
            this.toolStripBtnExportarPDF.Text = "Exportar PDF";
            // 
            // toolStripBtnEnviarEmail
            // 
            this.toolStripBtnEnviarEmail.Image = global::UTN.Winform.Mensajeros.Properties.Resources.iconoEnviaremail1;
            this.toolStripBtnEnviarEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnEnviarEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEnviarEmail.Name = "toolStripBtnEnviarEmail";
            this.toolStripBtnEnviarEmail.Size = new System.Drawing.Size(132, 61);
            this.toolStripBtnEnviarEmail.Text = "Enviar Email";
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.Image = global::UTN.Winform.Mensajeros.Properties.Resources.window_close_2;
            this.toolStripBtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(81, 61);
            this.toolStripBtnSalir.Text = "Salir";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 64);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(694, 360);
            this.reportViewer1.TabIndex = 2;
            // 
            // frmReporteFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 446);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.tspBarraSuperior);
            this.Name = "frmReporteFactura";
            this.Text = "frmReporteFactura";
            this.Load += new System.EventHandler(this.frmReporteFactura_Load);
            this.tspBarraSuperior.ResumeLayout(false);
            this.tspBarraSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspBarraSuperior;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.ToolStripButton toolStripBtnExportarPDF;
        private System.Windows.Forms.ToolStripButton toolStripBtnEnviarEmail;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}