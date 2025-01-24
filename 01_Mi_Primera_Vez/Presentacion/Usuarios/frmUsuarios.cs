using _01_Mi_Primera_Vez.Datos;
using _01_Mi_Primera_Vez.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion.Usuarios
{
    public partial class frmUsuarios : Form
    {
        public bool RegistroNuevo = true;
        public int idUser;
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cls_usuarios usuarioController = new cls_usuarios();
            dto_usuarios usuario = new dto_usuarios
            {
                Cedula = txtCedula.Text,
                NombresApellidos = txtNombres.Text,
                DireccionDomicilio = txtDireccion.Text,
                CodigoPostal = txtCodigoPostal.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Pais = Convert.ToInt32(cmbPais.SelectedValue)
            };

            if (RegistroNuevo)
            {
                bool result = usuarioController.InsertUsuario(usuario);
                if (result)
                {
                    MessageBox.Show("Usuario registrado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al registrar el usuario.");
                }
            }
            else
            {
                usuario.IdUsuario = Convert.ToInt32(idUser);
                bool result = usuarioController.UpdateUsuario(usuario);
                if (result)
                {
                    MessageBox.Show("Usuario actualizado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al actualizar el usuario.");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
