using Academia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de relatorio de planos ativos

    public interface IRelatorioPlanosAtivosRepository
    {
        Task<List<object>> BuscarPlanosAtivos(DateOnly dataAtual);
    }
}
