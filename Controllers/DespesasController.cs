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
    public class DespesasController : ControllerBase
    {
        // Controller responsável por lidar com as operações relacionadas às despesas

        private readonly IDespesasRepository _despesasRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public DespesasController(IDespesasRepository despesasRepository)
        {
            _despesasRepository = despesasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MDespesas>>> BuscarDespesas()
        {
            try
            {
                List<MDespesas> despesas = await _despesasRepository.BuscarDespesas();
                return Ok(despesas);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar despesas.");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MDespesas>> BuscarDespesaPorId(int id)
        {
            try
            {
                MDespesas despesa = await _despesasRepository.BuscarDespesaPorId(id);
                return Ok(despesa);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao buscar despesa com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MDespesas>> Cadastrar([FromBody] MDespesas despesaModel)
        {
            try
            {
                MDespesas despesa = await _despesasRepository.AdicionarDespesa(despesaModel);
                return Ok(despesa);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao cadastrar despesa.");
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MDespesas>> AtualizarDespesa(MDespesas despesaModel, int id)
        {
            try
            {
                return await _despesasRepository.AtualizarDespesa(despesaModel, id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao atualizar despesa com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MDespesas>> DeletarDespesa(int id)
        {
            try
            {
                var success = await _despesasRepository.ApagarDespesa(id);
                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao deletar despesa com ID {id}.");
                return StatusCode(500);
            }
        }

    }
}
