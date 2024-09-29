using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de aulas; fornece metodos para o CRUD de aulas
    public class AulasRepository : IAulasRepository
    {
        private readonly AcademiaContext _context;
        public AulasRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca uma aula pelo ID
        public async Task<MAulas> BuscarAulaPorId(int id)
        {
            return await _context.Aulas.FirstOrDefaultAsync(a => a.Id_aula == id);
        }

        // Busca todas as aulas cadastradas
        public async Task<List<MAulas>> BuscarAulas()
        {
            return await _context.Aulas.ToListAsync();
        }

        // Adiciona uma aula
        public async Task<MAulas> AdicionarAula(MAulas aulaModel)
        {
            await _context.Aulas.AddAsync(aulaModel);
            await _context.SaveChangesAsync();
            return aulaModel;
        }

        // Atualiza uma aula
        public async Task<MAulas> AtualizarAula(MAulas aulaModel, int id)
        {
            var aula = await BuscarAulaPorId(id);
            if (aula == null)
            {
                throw new Exception($"Aula para o ID: {id} não foi encontrado no banco de dados.");
            }

            aula.Data_aula = aulaModel.Data_aula;
            aula.Descricao_aula = aulaModel.Descricao_aula;

            _context.Aulas.Update(aula);
            await _context.SaveChangesAsync();

            return aula;
        }

        // Apaga uma aula pelo ID
        public async Task<bool> ApagarAula(int id)
        {
            var aula = await BuscarAulaPorId(id);
            if (aula == null)
            {
                throw new Exception($"Aula para o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Aulas.Remove(aula);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
