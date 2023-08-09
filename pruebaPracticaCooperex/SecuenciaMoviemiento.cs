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
    public partial class SecuenciaMoviemiento : Form
    {

        private string TipoMovimiento;
        private conexion Conexion;
        private int Id;

        public SecuenciaMoviemiento()
        {
            InitializeComponent();
            Conexion = new conexion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargarProducto(producto Producto, string tipoMovimiento)
        {
            if (Producto != null)
            {
                txtcodigo.Text = Producto.codigo;
                txtnombre.Text = Producto.nombre;
                txtcantidad.Text = Producto.cantidad.ToString();
                TipoMovimiento = tipoMovimiento;
                Id = Producto.Id;

                if (TipoMovimiento == "Entrada")
                {
                    lbltitulo.Text = "Entrada de Producto";
                    lblmovimiento.Text = "Cantidad para ingresar";
                }
                else if (TipoMovimiento == "Salida")
                {
                    lbltitulo.Text = "Salida de Producto";
                    lblmovimiento.Text = "Cantidad para sacar";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TipoMovimiento == "Entrada")
            {
                Conexion.EntradaProducto(Id,int.Parse(txtmovimiento.Text));
                this.Close();
                ((MovimientosProducto)this.Owner).CargarDatos();
            }
            else if (TipoMovimiento == "Salida")
            {
                Conexion.SalidaProducto(Id, int.Parse(txtmovimiento.Text));
                this.Close();
                ((MovimientosProducto)this.Owner).CargarDatos();
            }
        }
    }
}
