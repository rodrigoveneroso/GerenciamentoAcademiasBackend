using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de inventario; fornece metodos para o CRUD de itens do inventario
    public class InventarioRepository : IInventarioRepository
    {
        private readonly AcademiaContext _context;
        public InventarioRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca um item do inventario pelo ID
        public async Task<MInventario> BuscarItemInventarioPorId(int id)
        {
            return await _context.Inventario.FirstOrDefaultAsync(a => a.Id_item_inventario == id);
        }

        // Busca todos os itens do inventario cadastrados
        public async Task<List<MInventario>> BuscarItemsInventario()
        {
            return await _context.Inventario.ToListAsync();
        }

        // Adiciona um item ao inventario
        public async Task<MInventario> AdicionarItemInventario(MInventario itemModel)
        {
            await _context.Inventario.AddAsync(itemModel);
            await _context.SaveChangesAsync();
            return itemModel;
        }

        // Atualiza um item do inventario
        public async Task<MInventario> AtualizarItemInventario(MInventario itemModel, int id)
        {
            var item = await BuscarItemInventarioPorId(id);
            if (item == null)
            {
                throw new Exception($"Item para o ID: {id} não foi encontrado no banco de dados.");
            }

            item.Quantidade_item_inventario = itemModel.Quantidade_item_inventario;
            item.Descricao_item_inventario = itemModel.Descricao_item_inventario;


            _context.Inventario.Update(item);
            await _context.SaveChangesAsync();

            return item;
        }

        // Apaga um item do inventario pelo ID
        public async Task<bool> ApagarItemInventario(int id)
        {
            var item = await BuscarItemInventarioPorId(id);
            if (item == null)
            {
                throw new Exception($"Item para o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Inventario.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
