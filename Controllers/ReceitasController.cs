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
    public class ReceitasController : ControllerBase
    {
        // Controller responsavel por lidar com as operacoes relacionadas a receitas

        private readonly IReceitasRepository _receitasRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public ReceitasController(IReceitasRepository receitasRepository)
        {
            _receitasRepository = receitasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MReceitas>>> BuscarReceitas()
        {
            try
            {
                List<MReceitas> receitas = await _receitasRepository.BuscarReceitas();
                return Ok(receitas);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar receitas.");
                return StatusCode(500);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MReceitas>> BuscarReceitaPorId(int id)
        {
            try
            {
                MReceitas receitas = await _receitasRepository.BuscarReceitaPorId(id);
                return Ok(receitas);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao buscar receita com ID {id}.");
                return StatusCode(500);
            }
        }


        [HttpPost]
        public async Task<ActionResult<MReceitas>> Cadastrar([FromBody] MReceitas receitaModel)
        {
            try
            {
                MReceitas receita = await _receitasRepository.AdicionarReceita(receitaModel);
                return Ok(receita);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao cadastrar receita.");
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MReceitas>> AtualizarReceita(MReceitas receitaModel, int id)
        {
            try
            {
                return await _receitasRepository.AtualizarReceita(receitaModel, id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao atualizar receita com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<MReceitas>> DeletarReceita(int id)
        {
            try
            {
                var success = await _receitasRepository.ApagarReceita(id);
                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao apagar receita com ID {id}.");
                return StatusCode(500);
            }
        }

    }
}