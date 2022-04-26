using Datos.Repositorios;
using Examen_III_Parcial.Data;
using Examen_III_Parcial.Interfaces;
using Modelos;

namespace Examen_III_Parcial.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly MySqlConfigurations _configuration;
        private UsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio(MySqlConfigurations configuration)
        {
            _configuration = configuration;
            usuarioRepositorio = new UsuarioRepositorio(configuration.CadenaConexion);
        }

        public async Task<IEnumerable<Usuario>> GetLista()
        {
            return await usuarioRepositorio.GetLista();
        }

        public async Task<Usuario> GetPorCodigo(string codigo)
        {
            return await usuarioRepositorio.GetPorCodigo(codigo);
        }

    }
}
