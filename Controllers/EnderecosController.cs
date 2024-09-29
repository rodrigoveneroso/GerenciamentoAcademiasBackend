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
    public class EnderecosController : ControllerBase
    {
        // Controller responsável por lidar com as operações relacionadas aos endereços

        private readonly IEnderecosRepository _enderecosRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public EnderecosController(IEnderecosRepository enderecosRepository)
        {
            _enderecosRepository = enderecosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MEnderecos>>> BuscarEnderecos()
        {
            try
            {
                List<MEnderecos> enderecos = await _enderecosRepository.BuscarEnderecos();
                return Ok(enderecos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar endereços.");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MEnderecos>> BuscarEnderecoPorId(int id)
        {
            try
            {
                MEnderecos endereco = await _enderecosRepository.BuscarEnderecoPorId(id);
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao buscar endereço com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MEnderecos>> Cadastrar([FromBody] MEnderecos enderecoModel)
        {
            try
            {
                MEnderecos endereco = await _enderecosRepository.AdicionarEndereco(enderecoModel);
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao cadastrar endereço.");
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MEnderecos>> AtualizarEndereco(MEnderecos enderecoModel, int id)
        {
            try
            {
                return await _enderecosRepository.AtualizarEndereco(enderecoModel, id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao atualizar endereço com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MEnderecos>> DeletarEndereco(int id)
        {
            try
            {
                var success = await _enderecosRepository.ApagarEndereco(id);
                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao deletar endereço com ID {id}.");
                return StatusCode(500);
            }
        }
    }
}
