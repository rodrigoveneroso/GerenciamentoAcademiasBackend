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
    public class InventariosController : ControllerBase
    {
        // Controller responsãvel por lidar com as operacoes relacionadas ao inventario

        private readonly IInventarioRepository _inventarioRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public InventariosController(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MInventario>>> BuscarItemsInventario()
        {
            try
            {
                List<MInventario> item = await _inventarioRepository.BuscarItemsInventario();
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar itens do inventário.");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MInventario>> BuscarItemInventarioPorId(int id)
        {
            try
            {
                MInventario item = await _inventarioRepository.BuscarItemInventarioPorId(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao buscar item do inventário com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MInventario>> AdicionarItemInventario([FromBody] MInventario inventarioModel)
        {
            try
            {
                MInventario item = await _inventarioRepository.AdicionarItemInventario(inventarioModel);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao adicionar item ao inventário.");
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MInventario>> AtualizarItemInventario(MInventario inventarioModel, int id)
        {
            try
            {
                return await _inventarioRepository.AtualizarItemInventario(inventarioModel, id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao atualizar item do inventário com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<MInventario>> ApagarItemInventario(int id)
        {
            try
            {
                var success = await _inventarioRepository.ApagarItemInventario(id);
                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao apagar item do inventário com ID {id}.");
                return StatusCode(500);
            }
        }

    }
}