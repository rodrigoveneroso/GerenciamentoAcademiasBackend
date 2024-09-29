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
    public class RelatorioVendasController : ControllerBase
    {
        // Controller responsavel por lidar com as operacoes relacionadas ao relatorio de vendas

        private readonly IRelatorioVendasRepository _relatorioVendasRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public RelatorioVendasController(IRelatorioVendasRepository relatorioVendasRepository)
        {
            _relatorioVendasRepository = relatorioVendasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<int>> BuscarVendasPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim)
        {
            try
            {
                var contratos = await _relatorioVendasRepository.BuscarVendasPorIntervaloDataInicio(dataInicio, dataFim);
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar relatório de vendas por intervalo de data.");
                return StatusCode(500);
            }
        }

        [HttpGet("/api/RelatorioVendas/lista")]
        public async Task<ActionResult<IEnumerable<List<object>>>> BuscarListaVendasPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim)
        {
            try
            {
                var contratos = await _relatorioVendasRepository.BuscarListaVendasPorIntervaloDataInicio(dataInicio, dataFim);
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar lista de vendas por intervalo de data.");
                return StatusCode(500);
            }
        }
    }
}
