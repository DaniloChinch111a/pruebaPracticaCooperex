using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaPracticaCooperex
{
    public partial class AgregarProducto : Form
    {

        private conexion Conexion;
        private producto _producto;

        public AgregarProducto()
        {
            InitializeComponent();
            Conexion = new conexion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            producto producto = new producto();
            producto.codigo = txtcodigo.Text;
            producto.nombre = txtnombre.Text;
            producto.cantidad = int.Parse(txtcantidad.Text);
            producto.descripcion = txtdescripcion.Text;

            producto.Id = _producto != null ? _producto.Id : 0;    

            if (producto.Id == 0)
                Conexion.InsertarProducto(producto);
            else
                Conexion.ActualizarProducto(producto);

            this.Close();

            ((ListaProductos)this.Owner).CargarDatos();
        }


        public void CargarProducto(producto Producto)
        {
            _producto = Producto;
            if (Producto != null) 
            {
                txtcodigo.Text = Producto.codigo;
                txtnombre.Text = Producto.nombre;
                txtcantidad.Text = Producto.cantidad.ToString();
                txtdescripcion.Text = Producto.descripcion;
            }
        }

        public void limpiarFormulario()
        {
            txtcodigo.Text = string.Empty;
            txtnombre.Text = string.Empty;
            txtcantidad.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
        }
    }
}
