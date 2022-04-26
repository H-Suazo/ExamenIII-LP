namespace Examen_III_Parcial.Data
{
    public class MySqlConfigurations
    {
        public string CadenaConexion { get; }

        public MySqlConfigurations(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }
    }
}
