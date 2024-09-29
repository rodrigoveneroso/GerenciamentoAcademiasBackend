using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de receitas; fornece metodos para o CRUD de receitas
    public class ReceitasRepository : IReceitasRepository
    {
        private readonly AcademiaContext _context;
        public ReceitasRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca uma receita pelo ID
        public async Task<MReceitas> BuscarReceitaPorId(int id)
        {
            return await _context.Receitas.FirstOrDefaultAsync(a => a.Id_receita == id);
        }

        // Busca todas as receitas cadastrados
        public async Task<List<MReceitas>> BuscarReceitas()
        {
            return await _context.Receitas.ToListAsync();
        }

        // Adiciona uma receita
        public async Task<MReceitas> AdicionarReceita(MReceitas receitaModel)
        {
            await _context.Receitas.AddAsync(receitaModel);
            await _context.SaveChangesAsync();
            return receitaModel;
        }

        // Atualiza uma receita
        public async Task<MReceitas> AtualizarReceita(MReceitas receitaModel, int id)
        {
            var receita = await BuscarReceitaPorId(id);
            if (receita == null)
            {
                throw new Exception($"Receita para o ID: {id} não foi encontrado no banco de dados.");
            }

            receita.Descricao_receita = receitaModel.Descricao_receita;
            receita.Valor_receita = receitaModel.Valor_receita;
            receita.Data_receita = receitaModel.Data_receita;
            receita.Id_aluno = receitaModel.Id_aluno;

            _context.Receitas.Update(receita);
            await _context.SaveChangesAsync();

            return receita;
        }

        // Apaga uma receita pelo ID
        public async Task<bool> ApagarReceita(int id)
        {
            var receita = await BuscarReceitaPorId(id);
            if (receita == null)
            {
                throw new Exception($"Receita para o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
