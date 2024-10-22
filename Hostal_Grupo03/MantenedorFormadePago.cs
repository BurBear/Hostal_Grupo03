using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostal_Grupo03
{
    public partial class MantenedorFormadePago : Form
    {
        public MantenedorFormadePago()
        {
            InitializeComponent();
        }

      private void habitacionesprecio(object sender, EventArgs e)
        {
            if (cmbHabitacion.SelectedIndex == 0)
            {
                lblprecio.Text = "60";
            }
            else if(cmbHabitacion.SelectedIndex == 1)
            {
                lblprecio.Text = "90";
            }
            else
            {
                lblprecio.Text = "120";
            }

        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Length > 8)
            {
                label5.Text = "El documento tiene que ser de 8 caracteres";
            }
            else if (txtDocumento.Text.Length != 8)
            {
                label5.Text = "El documento tiene que ser de 8 caracteres";
            }
            else 
            {
                label5.Text = "";
                Console.WriteLine($"El DNI ingresado es:{txtDocumento.Text}");
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string habitacion = cmbHabitacion.SelectedItem.ToString();
            string documento = txtDocumento.Text;
            string precio = lblprecio.Text;
            string nombre = txtNombre.Text;
            string cantidad = txtCantidad.Text;
            float preciofloat = float.Parse(precio);
            int cantidadint = int.Parse(cantidad);
            float total = preciofloat * cantidadint;
            string[] row = new string[] { documento, nombre, habitacion, precio, cantidad,total.ToString() };
            dgvLista.Rows.Add(row);
            calculartotal();
        }
        private void calculartotal()
        {
            float total = 0;
            foreach(DataGridViewRow row in dgvLista.Rows)
            {
                if (row.Cells["total"].Value != null)
                {
                    Console.WriteLine(float.Parse(row.Cells["total"].Value.ToString()));
                    total += float.Parse(row.Cells["total"].Value.ToString());
                }
            }
            lblTotalaPagar.Text = total.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        if(dgvLista.SelectedRows.Count > 0)
            {
                int rowIndex = dgvLista.SelectedRows[0].Index;
                dgvLista.Rows.RemoveAt(rowIndex);
                calculartotal();
            }
        }
    }
}
