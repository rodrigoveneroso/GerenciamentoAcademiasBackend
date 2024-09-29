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
    public class RelatorioPlanosAtivosController : ControllerBase
    {
        // Controller responsavel por lidar com as operações relacionadas ao relatorio de planos ativos

        private readonly IRelatorioPlanosAtivosRepository _relatorioPlanosAtivosRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public RelatorioPlanosAtivosController(IRelatorioPlanosAtivosRepository relatorioPlanosAtivosRepository)
        {
            _relatorioPlanosAtivosRepository = relatorioPlanosAtivosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<List<object>>>> BuscarPlanosAtivos(DateOnly dataAtual)
        {
            try
            {
                List<object> planos = await _relatorioPlanosAtivosRepository.BuscarPlanosAtivos(dataAtual);
                return Ok(planos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar relatório de planos ativos.");
                return StatusCode(500);
            }
        }

    }
}
