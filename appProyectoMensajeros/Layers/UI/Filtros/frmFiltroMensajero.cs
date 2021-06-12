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

namespace UTN.Winform.Mensajeros.Layers.UI.Filtros
{
    public partial class frmFiltroMensajero : Form
    {
        private static readonly ILog _MyLogControlEventos =
         log4net.LogManager.GetLogger("MyControlEventos");

        public Mensajero _Mensajero { get; private set; } = null;
        public frmFiltroMensajero()
        {
            InitializeComponent();
        }

        private void toolStripButtonSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            this.txtFiltro.Clear();
            this.dgvDatos.DataSource = null;
            txtFiltro.Focus();
        }

        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {
            IBLLMensajeros _BLLMensajeros = new BLLMensajeros();
            string filtro = string.Empty;
            try
            {
                filtro = this.txtFiltro.Text;
                filtro = filtro.Replace(' ', '%');
                filtro = "%" + filtro + "%";
                this.dgvDatos.AutoGenerateColumns = false;
                this.dgvDatos.DataSource = _BLLMensajeros.GetMensajerosByFilter(filtro);

            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat("Message        {0}\n", er.Message);
                msg.AppendFormat("Source         {0}\n", er.Source);
                msg.AppendFormat("InnerException {0}\n", er.InnerException);
                msg.AppendFormat("StackTrace     {0}\n", er.StackTrace);
                msg.AppendFormat("TargetSite     {0}\n", er.TargetSite);
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDatos.RowCount > 0 && dgvDatos.SelectedRows.Count > 0)
                {
                    if (dgvDatos.CurrentCell.Selected)
                    {
                        _Mensajero = dgvDatos.SelectedRows[0].DataBoundItem as Mensajero;
                        this.DialogResult = DialogResult.OK;
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
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
