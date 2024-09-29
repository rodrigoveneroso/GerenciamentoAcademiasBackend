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
    public class ContratosController : ControllerBase
    {
        // Controller responsável por lidar com as operações relacionadas aos contratos

        private readonly IContratosRepository _contratosRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public ContratosController(IContratosRepository contratosRepository)
        {
            _contratosRepository = contratosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MContratos>>> BuscarContratos()
        {
            try
            {
                List<MContratos> contratos = await _contratosRepository.BuscarContratos();
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar contratos.");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MContratos>> BuscarContratosPorId(int id)
        {
            try
            {
                MContratos contrato = await _contratosRepository.BuscarContratoPorId(id);
                return Ok(contrato);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao buscar contrato com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MContratos>> Cadastrar([FromBody] MContratos contratoModel)
        {
            try
            {
                MContratos contrato = await _contratosRepository.AdicionarContrato(contratoModel);
                return Ok(contrato);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao cadastrar contrato.");
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MContratos>> AtualizarContrato(MContratos contratoModel, int id)
        {
            try
            {
                return await _contratosRepository.AtualizarContrato(contratoModel, id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao atualizar contrato com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MContratos>> DeletarContrato(int id)
        {
            try
            {
                var success = await _contratosRepository.ApagarContrato(id);
                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao deletar contrato com ID {id}.");
                return StatusCode(500);
            }
        }

    }
}
