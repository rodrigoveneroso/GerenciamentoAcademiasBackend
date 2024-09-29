using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de planos; fornece metodos para o CRUD de planos
    public class PlanosRepository : IPlanosRepository
    {
        private readonly AcademiaContext _context;
        public PlanosRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca um plano pelo ID
        public async Task<MPlanos> BuscarPlanoPorId(int id)
        {
            return await _context.Planos.FirstOrDefaultAsync(a => a.Id_plano == id);
        }

        // Busca todos os planos cadastrados
        public async Task<List<MPlanos>> BuscarPlanos()
        {
            return await _context.Planos.ToListAsync();
        }

        // Adiciona um plano
        public async Task<MPlanos> AdicionarPlano(MPlanos planoModel)
        {
            await _context.Planos.AddAsync(planoModel);
            await _context.SaveChangesAsync();
            return planoModel;
        }

        // Atualiza um plano
        public async Task<MPlanos> AtualizarPlano(MPlanos planoModel, int id)
        {
            var plano = await BuscarPlanoPorId(id);
            if (plano == null)
            {
                throw new Exception($"Plano para o ID: {id} não foi encontrado no banco de dados.");
            }

            plano.Descricao_plano = planoModel.Descricao_plano;
            plano.Valor_plano = planoModel.Valor_plano;
            plano.Dias_plano = planoModel.Dias_plano;

            _context.Planos.Update(plano);
            await _context.SaveChangesAsync();

            return plano;
        }

        // Apaga um plano pelo ID
        public async Task<bool> ApagarPlano(int id)
        {
            var plano = await BuscarPlanoPorId(id);
            if (plano == null)
            {
                throw new Exception($"Plano para o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Planos.Remove(plano);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
