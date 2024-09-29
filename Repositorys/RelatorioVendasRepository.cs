using Academia.Models;
using Academia.Repositorys.Interfaces;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Numerics;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de relatorio de vendas
    public class RelatorioVendasRepository : IRelatorioVendasRepository
    {
        private readonly AcademiaContext _context;
        public RelatorioVendasRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task<List<object>> BuscarListaVendasPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim)
        {
            var resultado = await(from contrato in _context.Contratos
             .Where(contrato => contrato.Data_pagamento >= dataInicio && contrato.Data_pagamento <= dataFim)
                select new
                {
                    Contrato = contrato
                }).ToListAsync();

            if (resultado == null)
            {
                throw new Exception($"Nenhuma venda entres esse periodo {dataInicio} e {dataFim} foi encontrado no banco de dados.");
            }

            return resultado.Cast<object>().ToList();
        }

        // Busca a quantidade de vendas dentro de um intervalo de tempo
        public async Task<int> BuscarVendasPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim)
        {

            var resultado = await _context.Contratos
                .Where(contrato => contrato.Data_pagamento >= dataInicio && contrato.Data_pagamento <= dataFim)
                .CountAsync();

            if (resultado == null)
            {
                throw new Exception($"Nenhuma venda entres esse periodo {dataInicio} e {dataFim} foi encontrado no banco de dados.");
            }

            return resultado;

        }
    }
}