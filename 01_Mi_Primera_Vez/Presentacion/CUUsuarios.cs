using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion
{
    public partial class CUUsuarios : UserControl
    {
        public CUUsuarios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuarios.frmUsuarios frmUser = new Usuarios.frmUsuarios();
            frmUser.RegistroNuevo = true;
            frmUser.ShowDialog();
        }

        private void dgvDatosUsuarios_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDatosUsuarios.CurrentRow != null)
            {
                int idUsuario = Convert.ToInt32(dgvDatosUsuarios.CurrentRow.Cells["IdUsuario"].Value);
                string cedula = dgvDatosUsuarios.CurrentRow.Cells["Cedula"].Value.ToString();
                string nombresApellidos = dgvDatosUsuarios.CurrentRow.Cells["NombresApellidos"].Value.ToString();
                string direccion = dgvDatosUsuarios.CurrentRow.Cells["DireccionDomicilio"].Value.ToString();
                string codigoPostal = dgvDatosUsuarios.CurrentRow.Cells["CodigoPostal"].Value.ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(dgvDatosUsuarios.CurrentRow.Cells["FechaNacimiento"].Value);
                int idPais = Convert.ToInt32(dgvDatosUsuarios.CurrentRow.Cells["IdPais"].Value);

                Usuarios.frmUsuarios frmUser = new Usuarios.frmUsuarios();

                frmUser.idUser = idUsuario;
                frmUser.txtCedula.Text = cedula;
                frmUser.txtNombres.Text = nombresApellidos;
                frmUser.txtDireccion.Text = direccion;
                frmUser.txtCodigoPostal.Text = codigoPostal;
                frmUser.dtpFechaNacimiento.Value = fechaNacimiento;
                frmUser.cmbPais.SelectedValue = idPais;

                frmUser.RegistroNuevo = false;

                frmUser.ShowDialog();
            }
        }

        private void dgvDatosUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
