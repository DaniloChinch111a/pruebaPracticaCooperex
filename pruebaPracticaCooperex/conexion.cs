using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaPracticaCooperex
{
    public class conexion
    {
        private SqlConnection conn = new SqlConnection("server=LAPTOP-1QUQBCMV ; database=PruebaPracticaCooperex ; integrated security = true");

        public void InsertarProducto(producto Producto)
        {
            try
            {
                conn.Open();
                string query = @"EXEC InsertarProducto @CodigoProducto, @NombreProducto, @Cantidad, @Descripcion";

                SqlParameter CodigoProducto = new SqlParameter("@CodigoProducto", Producto.codigo);
                SqlParameter NombreProducto = new SqlParameter("@NombreProducto", Producto.nombre);
                SqlParameter Cantidad = new SqlParameter("@Cantidad", Producto.cantidad);
                SqlParameter Descripcion = new SqlParameter("@Descripcion", Producto.descripcion);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(CodigoProducto);
                command.Parameters.Add(NombreProducto);
                command.Parameters.Add(Cantidad);
                command.Parameters.Add(Descripcion);

                command.ExecuteNonQuery();  

            }
            catch (Exception) 
            {
                throw;
            }
            finally { conn.Close(); }   
        }

        public List<producto> GetProductos()
        {

            List<producto> Productos = new List<producto>();

            try
            {
                conn.Open();
                string query = @"SELECT idProducto, CodigoProducto, NombreProducto, Cantidad, Descripcion
                                 FROM Producto WHERE Estado = 1";

                SqlCommand command = new SqlCommand(query, conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Productos.Add(new producto()
                    {
                        Id = int.Parse(reader["idProducto"].ToString()),
                        codigo = reader["CodigoProducto"].ToString(),
                        nombre = reader["NombreProducto"].ToString(),
                        cantidad = int.Parse(reader["Cantidad"].ToString()),
                        descripcion = reader["Descripcion"].ToString(),
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return Productos;
        }

        public void ActualizarProducto(producto Producto)
        {
            try
            {
                conn.Open();
                string query = @"EXEC ActualizarProducto @Id,@CodigoProducto,@NombreProducto,@Cantidad,@Descripcion";

                SqlParameter Id = new SqlParameter("@Id", Producto.Id);
                SqlParameter CodigoProducto = new SqlParameter("@CodigoProducto", Producto.codigo);
                SqlParameter NombreProducto = new SqlParameter("@NombreProducto", Producto.nombre);
                SqlParameter Cantidad = new SqlParameter("@Cantidad", Producto.cantidad);
                SqlParameter Descripcion = new SqlParameter("@Descripcion", Producto.descripcion);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(Id);
                command.Parameters.Add(CodigoProducto);
                command.Parameters.Add(NombreProducto);
                command.Parameters.Add(Cantidad);
                command.Parameters.Add(Descripcion);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
        }

        public void EliminarProducto(int id)
        {
            try
            {
                conn.Open();
                string query = @"UPDATE Producto SET Estado = 0 WHERE idProducto = @Id";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@Id", id));

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
        }

        public void SalidaProducto(int id, int cantidad)
        {
            try
            {
                conn.Open();
                string query = @"EXEC SalidaProducto @Id, @Cantidad";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.Parameters.Add(new SqlParameter("@Cantidad", cantidad));

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
        }

        public void EntradaProducto(int id, int cantidad)
        {
            try
            {
                conn.Open();
                string query = @"EXEC EntradaProducto @Id, @Cantidad";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.Parameters.Add(new SqlParameter("@Cantidad", cantidad));

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
        }
    }
}
