using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab01
{
    public partial class Form1 : Form
    {
        List<Cusco> Pedidos = new List<Cusco>();
        Cusco c = new Cusco();
        
        public Form1()
        {
            InitializeComponent();
            btnAgregar.Enabled = false;
        }

        private void cboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.Sucursal = cboSucursal.Text;
            c.Modelo = cboModelo.Text;
            txtPrecio.Text = c.CalcularPrecio().ToString();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {

            //Mostrar resultados

            if (cboSucursal.SelectedIndex < 0)
            {
                mensaje("Seleccione Sucursal");
                txtPrecio.Text = "";
            }
            else if (cboModelo.SelectedIndex < 0)
            {
                mensaje("Seleccione un Modelo");
                txtPrecio.Text = "";
            }
            else if (txtCantidad.Text == "" || Convert.ToInt32(txtCantidad.Text) == 0 || txtCantidad == null)
            {
                c.Cantidad = 2;
                txtCantidad.Text = "2";
            }
            else
            {
                c.Sucursal = cboSucursal.Text;
                c.Modelo = cboModelo.Text;
                c.Precio = Convert.ToDouble(txtPrecio.Text);
                c.Cantidad = Convert.ToInt32(txtCantidad.Text);

                // Mostrar en sección de resultados
                txtSubTotal.Text = c.CalcularSubTotal().ToString();
                txtDescuento.Text = c.Descuento().ToString();
                txtTotal.Text = c.CalcularTotal().ToString();

                btnAgregar.Enabled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
           c.Sucursal = cboSucursal.Text;
           c.Modelo = cboModelo.Text;
           c.Precio = Convert.ToDouble(txtPrecio.Text);
           c.Cantidad = Convert.ToInt32(txtCantidad.Text);

           Pedidos.Add(c);
           Listar();
        }

        void Listar()
        {
            //listView
            lvwLista.Items.Clear();
            foreach (var p in Pedidos)
            {
                ListViewItem item = new ListViewItem(p.Sucursal);
                item.SubItems.Add(p.Modelo);
                item.SubItems.Add(p.Precio.ToString());
                item.SubItems.Add(p.Cantidad.ToString());
                item.SubItems.Add(p.CalcularSubTotal().ToString());
                item.SubItems.Add(p.Descuento().ToString());
                item.SubItems.Add(p.CalcularTotal().ToString());
                lvwLista.Items.Add(item);

            }
        }

        void mensaje(String s)
        {
            MessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
