using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de despesas; fornece metodos para o CRUD de despesas
    public class DespesasRepository : IDespesasRepository
    {
        private readonly AcademiaContext _context;
        public DespesasRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca uma despesa pelo ID
        public async Task<MDespesas> BuscarDespesaPorId(int id)
        {
            return await _context.Despesas.FirstOrDefaultAsync(a => a.Id_despesa == id);
        }

        // Busca todas as despesas cadastrados
        public async Task<List<MDespesas>> BuscarDespesas()
        {
            return await _context.Despesas.ToListAsync();
        }

        // Adiciona uma despesa
        public async Task<MDespesas> AdicionarDespesa(MDespesas despesaModel)
        {
            await _context.Despesas.AddAsync(despesaModel);
            await _context.SaveChangesAsync();
            return despesaModel;
        }

        // Atualiza uma despesa
        public async Task<MDespesas> AtualizarDespesa(MDespesas despesaModel, int id)
        {
            var despesa = await BuscarDespesaPorId(id);
            if (despesa == null)
            {
                throw new Exception($"Contrato para o ID: {id} não foi encontrado no banco de dados.");
            }

            despesa.Data_despesa = despesaModel.Data_despesa;
            despesa.Valor_despesa = despesaModel.Valor_despesa;
            despesa.Descricao_despesa = despesaModel.Descricao_despesa;

            _context.Despesas.Update(despesa);
            await _context.SaveChangesAsync();

            return despesa;
        }

        // Apaga uma despesa pelo ID
        public async Task<bool> ApagarDespesa(int id)
        {
            var despesa = await BuscarDespesaPorId(id);
            if (despesa == null)
            {
                throw new Exception($"Despesa para o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Despesas.Remove(despesa);
            await _context.SaveChangesAsync();

            return true; 
        }

    }
}
