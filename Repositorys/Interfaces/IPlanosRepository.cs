using Academia.Models;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de planos, define os metodos para o CRUD de itens
    public interface IPlanosRepository
    {
        Task<List<MPlanos>> BuscarPlanos();
        Task<MPlanos> BuscarPlanoPorId(int id);
        Task<MPlanos> AdicionarPlano(MPlanos PlanoModel);
        Task<MPlanos> AtualizarPlano(MPlanos PlanoModel, int id);
        Task<bool> ApagarPlano(int id);
    }
}
