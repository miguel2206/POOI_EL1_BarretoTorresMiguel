using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab02
{
    public partial class Form1 : Form
    {
        Libro l = new Libro();
        List<Libro> libros = new List<Libro>();
        int numero=1;

        public Form1()
        {
            InitializeComponent();
            btnRegistrar.Enabled = false;
            l.Codigo = numero.ToString();
            txtCodigo.Text = l.GenerarCod(Convert.ToInt32(l.Codigo));
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviarFecha_Click(object sender, EventArgs e)
        {
            txtFecha.Text = monthCalendar1.SelectionStart.Day.ToString() + "/" +
                monthCalendar1.SelectionStart.Month.ToString() + "/" +
                monthCalendar1.SelectionStart.Year.ToString();

            btnRegistrar.Enabled = true;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtFecha.Text == "" || txtFecha == null)
            {
                mensaje("Ingrese fecha");
            }else if (cboGenero.Text == "Seleccionar")
            {
                mensaje("Seleccione un género válido");
            }
            else
            {
                Libro l1 = libros.Find(x => x.Nombre == txtNombreLibro.Text);
                if (l1 == null)
                {
                    Libro l_nuevo = new Libro();
                    l_nuevo.Codigo = txtCodigo.Text;
                    l_nuevo.Nombre = txtNombreLibro.Text;
                    l_nuevo.FechaRegistro = txtFecha.Text.ToString();
                    l_nuevo.Genero = cboGenero.Text;
                    l_nuevo.Nombre_autor = txtNombreAutor.Text;

                    libros.Add(l_nuevo);
                    Listar();
                    limpieza();
                    txtNombreLibro.Focus();

                    numero += 1;
                    l.Codigo = numero.ToString();
                    txtCodigo.Text = l.GenerarCod(Convert.ToInt32(l.Codigo));
                }
                else
                {
                    Libro l2 = libros.Find(x => x.Nombre == txtNombreLibro.Text);
                    MessageBox.Show("El libro '" + l2.Nombre + "' ya se encuentra registrado!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        void Listar()
        {
            //listView
            lvwLista.Items.Clear();
            foreach (var l in libros)
            {
                ListViewItem item = new ListViewItem(l.Codigo);
                item.SubItems.Add(l.Nombre);
                item.SubItems.Add(l.FechaRegistro);
                item.SubItems.Add(l.Genero);
                item.SubItems.Add(l.Nombre_autor);
                lvwLista.Items.Add(item);
            }
        }

        void limpieza()
        {
            txtNombreLibro.Text = "";
            txtFecha.Text = "";
            txtNombreAutor.Text = "";
            cboGenero.Text = "Seleccionar";
        }

        void mensaje(String s)
        {
            MessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Listar();
            txtNombreLibro.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Libro l_modificar = libros.Find(x => x.Codigo == txtCodigo.Text);
            if (l_modificar != null)
            {
                //Actualizaciones datos
                l_modificar.Nombre = txtNombreLibro.Text;
                l_modificar.FechaRegistro = txtFecha.Text;
                l_modificar.Genero = cboGenero.Text;
                l_modificar.Nombre_autor = txtNombreAutor.Text;
           
                Listar();
                limpieza();
                txtBuscarCodigo.Text = "";
                
                l.Codigo = numero.ToString();
                txtCodigo.Text = l.GenerarCod(Convert.ToInt32(l.Codigo));
                txtNombreLibro.Focus();
            }
            else
            {
                MessageBox.Show("El Código no se encuentra registrado!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Libro l_modificar = libros.Find(x => x.Codigo == txtBuscarCodigo.Text);
         
            if (l_modificar != null)
            {
                //Actualizaciones datos
                txtCodigo.Text = l_modificar.Codigo;
                txtNombreLibro.Text = l_modificar.Nombre;
                txtFecha.Text = l_modificar.FechaRegistro;
                cboGenero.Text = l_modificar.Genero;
                txtNombreAutor.Text = l_modificar.Nombre_autor;
            }
            else
            {
                MessageBox.Show("El Código no se encuentra registrado!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBuscarCodigo.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int l_Eliminar = libros.FindIndex(x => x.Codigo == txtBuscarEliminar.Text);
           
            if (l_Eliminar != -1)
            {
                DialogResult result = MessageBox.Show("Seguro de eliminar la fila del código " + txtBuscarEliminar.Text + "?", "Salir", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    lvwLista.Items.RemoveAt(l_Eliminar);
                    limpieza();
                    MessageBox.Show("Eliminación exitosa");
                    txtBuscarEliminar.Text = "";
                    txtNombreLibro.Focus();

                    numero = numero-1;
                    l.Codigo = numero.ToString();
                    txtCodigo.Text = l.GenerarCod(Convert.ToInt32(l.Codigo));
                    txtNombreLibro.Focus();

                }
                else if (result == DialogResult.No)
                {

                }
                else if (result == DialogResult.Cancel)
                {
                }
               
            }
            else
            {
                MessageBox.Show("El Código no se encuentra registrado!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
