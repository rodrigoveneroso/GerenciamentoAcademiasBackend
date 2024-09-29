using Academia.Models;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de receitas, define os metodos para o CRUD de itens

    public interface IReceitasRepository
    {
        Task<List<MReceitas>> BuscarReceitas();
        Task<MReceitas> BuscarReceitaPorId(int id);
        Task<MReceitas> AdicionarReceita(MReceitas receitaModel);
        Task<MReceitas> AtualizarReceita(MReceitas receitaModel, int id);
        Task<bool> ApagarReceita(int id);
    }
}
