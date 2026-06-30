using MySqlConnector;
namespace Proyecto_menustrip;

public class SqlConnect
{
    public static MySqlConnection MiConexion()
    {
        return new MySqlConnection("server=localhost;uid=root;pwd=240624;database=pos");
    }
}