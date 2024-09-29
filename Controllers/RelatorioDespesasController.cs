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
    public class RelatorioDespesasController : ControllerBase
    {
        // Controller responsavel por lidar com as operações relacionadas a despesas

        private readonly IRelatorioDespesasRepository _relatorioDespesasRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public RelatorioDespesasController(IRelatorioDespesasRepository relatorioDespesasRepository)
        {
            _relatorioDespesasRepository = relatorioDespesasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<List<object>>>> BuscarContratosPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim)
        {
            try
            {
                List<object> despesas = await _relatorioDespesasRepository.BuscarDespesasPorIntervaloDataInicio(dataInicio, dataFim);
                return Ok(despesas);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar relatório de despesas por intervalo de data.");
                return StatusCode(500);
            }
        }
    }
}
