using Academia.Models;
using Microsoft.AspNetCore.Mvc;

using Academia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de relatório de faturamento

    public interface IRelatorioFaturamentoRepository
    {
        Task<List<object>> BuscarContratosPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim);
    }
}
