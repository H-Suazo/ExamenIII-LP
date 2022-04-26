using Modelos;

namespace Examen_III_Parcial.Interfaces;

    public interface IUsuarioServicio
    {
        Task<IEnumerable<Usuario>> GetLista();
        Task<Usuario> GetPorCodigo(string codigo);
    }

