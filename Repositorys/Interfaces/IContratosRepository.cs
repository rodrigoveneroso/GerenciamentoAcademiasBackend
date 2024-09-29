using Academia.Models;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de contratos, define os metodos para o CRUD

    public interface IContratosRepository
    {
        Task<List<MContratos>> BuscarContratos();
        Task<MContratos> BuscarContratoPorId(int id);
        Task<MContratos> AdicionarContrato(MContratos contratoModel);
        Task<MContratos> AtualizarContrato(MContratos contratoModel, int id);
        Task<bool> ApagarContrato(int id);
    }
}
