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
    public partial class ListaProductos : Form
    {

        private conexion Conexion;

        public ListaProductos()
        {
            InitializeComponent();
            Conexion = new conexion();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            AgregarProducto agregarProducto = new AgregarProducto();
            agregarProducto.ShowDialog(this);
        }

        private void ListaProductos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos()
        {
            List<producto> Productos = Conexion.GetProductos();
            gridProductos.DataSource = Productos;
        }

        private void gridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)gridProductos.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value.ToString() == "Editar")
            {
                AgregarProducto agregarProducto1 = new AgregarProducto();
                agregarProducto1.CargarProducto(new producto
                {
                    Id = int.Parse((gridProductos.Rows[e.RowIndex].Cells[0]).Value.ToString()),
                    codigo = gridProductos.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    nombre = gridProductos.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    cantidad = int.Parse(gridProductos.Rows[e.RowIndex].Cells[3].Value.ToString()),
                    descripcion = gridProductos.Rows[e.RowIndex].Cells[4].Value.ToString(),
                });
                agregarProducto1.ShowDialog(this);
            }
            else if (cell.Value.ToString() == "Eliminar")
            {
                Conexion.EliminarProducto(int.Parse((gridProductos.Rows[e.RowIndex].Cells[0]).Value.ToString()));
                CargarDatos();
            }
        }
    }
}
