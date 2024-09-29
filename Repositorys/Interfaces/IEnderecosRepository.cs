using Academia.Models;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de enderecos, define os metodos para o CRUD

    public interface IEnderecosRepository
    {
        Task<List<MEnderecos>> BuscarEnderecos();
        Task<MEnderecos> BuscarEnderecoPorId(int id);
        Task<MEnderecos> AdicionarEndereco(MEnderecos enderecoModel);
        Task<MEnderecos> AtualizarEndereco(MEnderecos enderecoModel, int id);
        Task<bool> ApagarEndereco(int id);
    }
}
