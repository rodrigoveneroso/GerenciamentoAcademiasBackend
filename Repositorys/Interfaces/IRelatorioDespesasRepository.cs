using Academia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de relatorio de despesas

    public interface IRelatorioDespesasRepository
    {
        Task<List<object>> BuscarDespesasPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim);
    }
}
