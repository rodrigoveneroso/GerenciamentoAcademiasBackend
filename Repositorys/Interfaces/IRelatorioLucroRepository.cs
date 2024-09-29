using Academia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de relatorio de lucro
    public interface IRelatorioLucroRepository
    {
        Task<List<object>> BuscarLucroPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim);
    }
}
