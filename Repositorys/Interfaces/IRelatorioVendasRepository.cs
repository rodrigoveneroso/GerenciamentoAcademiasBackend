using Academia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de relatorio de vendas

    public interface IRelatorioVendasRepository
    {
        Task<int> BuscarVendasPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim);
        Task<List<object>> BuscarListaVendasPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim);
    }
}
