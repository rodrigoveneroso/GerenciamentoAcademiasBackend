
using Academia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de relatorio de planos a vencer
    public interface IRelatorioPlanosAVencerRepository
    {
        Task<List<object>> BuscarPlanosAVencer(DateOnly dataAtual, int diasAteVencer);
    }
}
