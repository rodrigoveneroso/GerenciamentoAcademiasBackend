using Academia.Models;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de inventario, define os metodos para o CRUD de itens

    public interface IInventarioRepository
    {
        Task<List<MInventario>> BuscarItemsInventario();
        Task<MInventario> BuscarItemInventarioPorId(int id);
        Task<MInventario> AdicionarItemInventario(MInventario itemModel);
        Task<MInventario> AtualizarItemInventario(MInventario itemModel, int id);
        Task<bool> ApagarItemInventario(int id);
    }
}
