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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarProducto agregarProducto = new AgregarProducto();
            agregarProducto.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListaProductos listaProductos = new ListaProductos();
            listaProductos.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MovimientosProducto movimientosProducto = new MovimientosProducto();
            movimientosProducto.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
