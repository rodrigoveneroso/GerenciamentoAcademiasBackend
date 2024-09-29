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
    public class PlanosController : ControllerBase
    {
        // Controller responsavel por lidar com as operacoes relacionadas aos planos

        private readonly IPlanosRepository _planosRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public PlanosController(IPlanosRepository planosRepository)
        {
            _planosRepository = planosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MPlanos>>> BuscarPlanos()
        {
            try
            {
                List<MPlanos> planos = await _planosRepository.BuscarPlanos();
                return Ok(planos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar planos.");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MPlanos>> BuscarPlanoPorId(int id)
        {
            try
            {
                MPlanos plano = await _planosRepository.BuscarPlanoPorId(id);
                return Ok(plano);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao buscar plano com ID {id}.");
                return StatusCode(500);
            }
        }


        [HttpPost]
        public async Task<ActionResult<MPlanos>> Cadastrar([FromBody] MPlanos planoModel)
        {
            try
            {
                MPlanos plano = await _planosRepository.AdicionarPlano(planoModel);
                return Ok(plano);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao cadastrar plano.");
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MPlanos>> AtualizarPlano(MPlanos planoModel, int id)
        {
            try
            {
                return await _planosRepository.AtualizarPlano(planoModel, id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao atualizar plano com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<MPlanos>> DeletarPlano(int id)
        {
            try
            {
                var success = await _planosRepository.ApagarPlano(id);
                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao apagar plano com ID {id}.");
                return StatusCode(500);
            }
        }

    }
}