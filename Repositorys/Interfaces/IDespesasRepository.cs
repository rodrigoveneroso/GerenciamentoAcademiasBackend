using Academia.Models;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de despesas, define os metodos para o CRUD
    public interface IDespesasRepository
    {
        Task<List<MDespesas>> BuscarDespesas();
        Task<MDespesas> BuscarDespesaPorId(int id);
        Task<MDespesas> AdicionarDespesa(MDespesas despesaModel);
        Task<MDespesas> AtualizarDespesa(MDespesas despesaModel, int id);
        Task<bool> ApagarDespesa(int id);
    }
}
