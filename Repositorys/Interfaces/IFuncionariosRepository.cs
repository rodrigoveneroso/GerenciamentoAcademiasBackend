using Academia.Models;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de funcionarios, define os metodos para o CRUD

    public interface IFuncionariosRepository
    {
        Task<List<MFuncionarios>> BuscarFuncionarios();
        Task<MFuncionarios> BuscarFuncionarioPorId(int id);
        Task<MFuncionarios> AdicionarFuncionario(MFuncionarios funcionarioModel);
        Task<MFuncionarios> AtualizarFuncionario(MFuncionarios funcionarioModel, int id);
        Task<bool> ApagarFuncionario(int id);
    }
}
