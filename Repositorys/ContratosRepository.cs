using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de contratos; fornece metodos para o CRUD de contratos
    public class ContratosRepository : IContratosRepository
    {
        private readonly AcademiaContext _context;
        public ContratosRepository(AcademiaContext context)
        {
            _context = context;
        }


        // Busca um contrato pelo ID
        public async Task<MContratos> BuscarContratoPorId(int id)
        {
            return await _context.Contratos.FirstOrDefaultAsync(a => a.Id_contrato == id);
        }

        // Busca todos os contratos cadastrados
        public async Task<List<MContratos>> BuscarContratos()
        {
            return await _context.Contratos.ToListAsync();
        }

        // Adiciona um contrato
        public async Task<MContratos> AdicionarContrato(MContratos contratoModel)
        {
            await _context.Contratos.AddAsync(contratoModel);
            await _context.SaveChangesAsync();
            return contratoModel;
        }

        // Atualiza um contrato
        public async Task<MContratos> AtualizarContrato(MContratos contratoModel, int id)
        {
            var contrato = await BuscarContratoPorId(id);
            if (contrato == null)
            {
                throw new Exception($"Contrato para o ID: {id} não foi encontrado no banco de dados.");
            }

            contrato.Data_inicio_contrato = contratoModel.Data_inicio_contrato;
            contrato.Id_plano = contratoModel.Id_plano;

            _context.Contratos.Update(contrato);
            await _context.SaveChangesAsync();

            return contrato;
        }

        // Apaga um contrato pelo ID
        public async Task<bool> ApagarContrato(int id)
        {
            var contrato = await BuscarContratoPorId(id);
            if (contrato == null)
            {
                throw new Exception($"Contrato para o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
