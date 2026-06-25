using MySqlConnector;
namespace Proyecto_menustrip;

public class SqlConnect
{
    public static MySqlConnection miConexion()
    {
        return new MySqlConnection("server=localhost;uid=root;pwd=240624;database=pos");
    }
}