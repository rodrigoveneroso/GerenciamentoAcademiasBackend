using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de relatorio de planos a vencer
    public class RelatorioPlanosAVencerRepository : IRelatorioPlanosAVencerRepository
        {
        private readonly AcademiaContext _context;
        public RelatorioPlanosAVencerRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca uma lista de planos a vencer dentro de um intervalo de tempo 
        public async Task<List<object>> BuscarPlanosAVencer(DateOnly dataAtual, int diasAteVencer)
        {

            var contratosAtivos = await(from contrato in _context.Contratos
                                        join aluno in _context.Alunos on contrato.Id_aluno equals aluno.Id_aluno
                                        join plano in _context.Planos on contrato.Id_plano equals plano.Id_plano
                                        where (contrato.Data_inicio_contrato.AddDays(plano.Dias_plano) >= dataAtual && contrato.Data_inicio_contrato.AddDays(plano.Dias_plano) <= dataAtual.AddDays(diasAteVencer))
                                        select new
                                        {
                                            Contrato = contrato,
                                            Aluno = aluno,
                                            Plano = plano
                                        }).ToListAsync();

            if (contratosAtivos == null || contratosAtivos.Count == 0)
            {
                throw new Exception($"Nenhum contrato a vencer encontrado na data atual {dataAtual}.");
            }

            return contratosAtivos.Cast<object>().ToList();
        }
    }
}
