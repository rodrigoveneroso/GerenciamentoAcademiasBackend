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
    public class RelatorioLucroController : ControllerBase
    {
        // Controller responsavel por lidar com as operações relacionadas ao relatório de lucro

        private readonly IRelatorioLucroRepository _relatorioLucroRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public RelatorioLucroController(IRelatorioLucroRepository relatorioLucroRepository)
        {
            _relatorioLucroRepository = relatorioLucroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<List<object>>>> BuscarLucroPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim)
        {
            try
            {
                List<object> lucro = await _relatorioLucroRepository.BuscarLucroPorIntervaloDataInicio(dataInicio, dataFim);
                return Ok(lucro);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar relatório de lucro por intervalo de data.");
                return StatusCode(500);
            }
        }
    }
}
