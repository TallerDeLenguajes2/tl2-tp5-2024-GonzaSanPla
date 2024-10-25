using espacioProducto;
using Microsoft.Data.Sqlite;

namespace espacioProductoRepository;
public class ProductoRepository
{  
    string cadenaConexion=@"Data Source=Tienda.db;Cache=Shared";
    public List<Producto> ListarProductos()
        {
            List<Producto> listaProd = new List<Producto>();
            using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                string query = "SELECT * FROM Productos;";
                SqliteCommand command = new SqliteCommand(query, connection);
                connection.Open();
                using(SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var prod = new Producto();
                        prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
                        prod.Descripcion = reader["Descripcion"].ToString();
                        prod.Precio = Convert.ToInt32(reader["Precio"]);
                        listaProd.Add(prod);
                    }
                }
                connection.Close();

            }
            return listaProd;
        } 


}