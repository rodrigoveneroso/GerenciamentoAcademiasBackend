using Academia.Enums;
using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de relatorio de despesas
    public class RelatorioDespesasRepository : IRelatorioDespesasRepository
    {
        private readonly AcademiaContext _context;
        public RelatorioDespesasRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca uma lista de despesas dentro de um intervalo de tempo 
        public async Task<List<object>> BuscarDespesasPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim)
        {
            var despesas = await (from despesa in _context.Despesas
                                  where (despesa.Data_despesa >= dataInicio && despesa.Data_despesa <= dataFim)
                                  select new
                                  {
                                      Despesa = despesa.Valor_despesa
                                  }).ToListAsync();

            var funcionarios = await (from funcionario in _context.Funcionarios
                                  where funcionario.Status == EStatus.Ativo
                                  select new
                                  {
                                      Funcionario = funcionario.Salario_funcionario
                                  }).ToListAsync();

            var despesasEFuncionarios = new List<object>
            {
                new { Tipo = "despesas", Dados = despesas.Cast<object>().ToList() },
                new { Tipo = "funcionarios", Dados = funcionarios.Cast<object>().ToList() }
            };

            if (despesas == null || despesas.Count == 0)
            {
                throw new Exception($"Nenhuma despesa encontrada no intervalo de datas {dataInicio} a {dataFim}.");
            }

            return despesasEFuncionarios.Cast<object>().ToList();
        }
    }
}
