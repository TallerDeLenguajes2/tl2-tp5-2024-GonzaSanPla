using espacioPresupuestos;
using Microsoft.Data.Sqlite;

namespace espacioPresupuestoRepository;
public class PresupuestoRepository  
{  
    string cadenaConexion = @"Data Source=Tienda.db;Cache=Shared";
    public void CrearNuevo(Presupuesto pres)        // Que tipo es fecha? Porque en la BD es un string 
    {
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES (@Nombre, @Fecha)";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@Nombre", pres.NombreDestinatario));
            command.Parameters.Add(new SqliteParameter("@Fecha", pres.FechaCreacion));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

}
