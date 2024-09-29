using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NLogger = NLog.ILogger;

namespace Academia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioPlanosAVencerController : ControllerBase
    {
        // Controller responsavel por lidar com as operacoes relacionadas ao relatorio de planos a vencer

        private readonly IRelatorioPlanosAVencerRepository _relatorioPlanosAVencerRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public RelatorioPlanosAVencerController(IRelatorioPlanosAVencerRepository relatorioPlanosAVencerRepository)
        {
            _relatorioPlanosAVencerRepository = relatorioPlanosAVencerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<int>> BuscarPlanosAVencer(DateOnly dataAtual, int diasAteVencer)
        {
            try
            {
                var planosAVencer = await _relatorioPlanosAVencerRepository.BuscarPlanosAVencer(dataAtual, diasAteVencer);
                return Ok(planosAVencer);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar relatório de planos a vencer.");
                return StatusCode(500);
            }
        }
    }
}
