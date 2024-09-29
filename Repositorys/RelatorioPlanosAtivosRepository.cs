using Academia.Models;
using Academia.Repositorys.Interfaces;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de relatorio de planos ativos
    public class RelatorioPlanosAtivosRepository : IRelatorioPlanosAtivosRepository
    {
        private readonly AcademiaContext _context;
        public RelatorioPlanosAtivosRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca uma lista de planos ativos dentro de um intervalo de tempo 
        public async Task<List<object>> BuscarPlanosAtivos(DateOnly dataAtual)
        {
            var contratosAtivos = await (from contrato in _context.Contratos
                                         join aluno in _context.Alunos on contrato.Id_aluno equals aluno.Id_aluno
                                         join plano in _context.Planos on contrato.Id_plano equals plano.Id_plano
                                         where (contrato.Data_inicio_contrato.AddDays(plano.Dias_plano) > dataAtual)
                                         select new
                                         {
                                             Contrato = contrato,
                                             Aluno = aluno,
                                             Plano = plano
                                         }).ToListAsync();

            if (contratosAtivos == null || contratosAtivos.Count == 0)
            {
                throw new Exception($"Nenhum contrato ativo foi encontrado na data atual {dataAtual}.");
            }

            return contratosAtivos.Cast<object>().ToList();
        }
    }
}
