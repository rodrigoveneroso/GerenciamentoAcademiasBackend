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
    // Implementacao do repositorio de relatorio de faturamento
    public class RelatorioFaturamentoRepository : IRelatorioFaturamentoRepository
    {
        private readonly AcademiaContext _context;
        public RelatorioFaturamentoRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca uma lista de contrato, receita e aluno dentro de um intervalo de tempo
        public async Task<List<object>> BuscarContratosPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim)
        {
            var resultado = await (from contrato in _context.Contratos
                                   join receita in _context.Receitas on contrato.Id_receita equals receita.Id_receita
                                   join aluno in _context.Alunos on contrato.Id_aluno equals aluno.Id_aluno
                                   where contrato.Data_pagamento >= dataInicio && contrato.Data_pagamento <= dataFim
                                   select new
                                   {
                                       Contrato = contrato,
                                       Receita = receita,
                                       Aluno = aluno
                                       
                                   }).ToListAsync();

            if (resultado == null || resultado.Count == 0)
            {
                throw new Exception($"Nenhum contrato entre {dataInicio} e {dataFim} foi encontrado no banco de dados.");
            }

            return resultado.Cast<object>().ToList();
        }
    }
}
