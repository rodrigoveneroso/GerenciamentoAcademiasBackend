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

    public class AulasController : ControllerBase
    {
        // Controller responsável por lidar com as operações relacionadas às aulas

        private readonly IAulasRepository _aulasRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public AulasController(IAulasRepository aulasRepository)
        {
            _aulasRepository = aulasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MAulas>>> BuscarAulas()
        {
            try
            {
                List<MAulas> aulas = await _aulasRepository.BuscarAulas();
                return Ok(aulas);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar aulas.");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MAulas>> BuscarAulaPorId(int id)
        {
            try
            {
                MAulas aula = await _aulasRepository.BuscarAulaPorId(id);
                return Ok(aula);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao buscar aula com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MAulas>> Cadastrar([FromBody] MAulas aulaModel)
        {
            try
            {
                MAulas aula = await _aulasRepository.AdicionarAula(aulaModel);
                return Ok(aula);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao cadastrar aula.");
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MAulas>> AtualizarAula(MAulas aulaModel, int id)
        {
            try
            {
                return await _aulasRepository.AtualizarAula(aulaModel, id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao atualizar aula com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MAulas>> DeletarAula(int id)
        {
            try
            {
                var success = await _aulasRepository.ApagarAula(id);
                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao deletar aula com ID {id}.");
                return StatusCode(500);
            }
        }
    }
}
