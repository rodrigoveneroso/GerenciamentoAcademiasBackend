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
    public class RelatorioFaturamentoController : ControllerBase
    {
        // Controller responsavel por lidar com as operações relacionadas ao relatorio de faturamento

        private readonly IRelatorioFaturamentoRepository _relatorioFaturamentoRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public RelatorioFaturamentoController(IRelatorioFaturamentoRepository relatorioFaturamentoRepository)
        {
            _relatorioFaturamentoRepository = relatorioFaturamentoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<List<object>>>> BuscarContratosPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim)
        {
            try
            {
                List<object> contratos = await _relatorioFaturamentoRepository.BuscarContratosPorIntervaloDataInicio(dataInicio, dataFim);
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar relatório de faturamento por intervalo de data.");
                return StatusCode(500);
            }
        }
    }
}
