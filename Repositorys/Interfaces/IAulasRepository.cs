using Academia.Models;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de aulas, define os metodos para o CRUD
    public interface IAulasRepository
    {
        Task<List<MAulas>> BuscarAulas();
        Task<MAulas> BuscarAulaPorId(int id);
        Task<MAulas> AdicionarAula(MAulas aulaModel);
        Task<MAulas> AtualizarAula(MAulas aulaModel, int id);
        Task<bool> ApagarAula(int id);
    }
}
