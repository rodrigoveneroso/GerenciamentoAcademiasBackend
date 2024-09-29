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
    public class FuncionariosController : ControllerBase
    {
        // Controller responsavel por lidar com as operacoes relacionadas aos funcionarios

        private readonly IFuncionariosRepository _funcionariosRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public FuncionariosController(IFuncionariosRepository funcionariosRepository)
        {
            _funcionariosRepository = funcionariosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MFuncionarios>>> BuscarFuncionarios()
        {
            List<MFuncionarios> funcionario = await _funcionariosRepository.BuscarFuncionarios();
            return Ok(funcionario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MFuncionarios>> BuscarFuncionarioPorId(int id)
        {
            MFuncionarios funcionario = await _funcionariosRepository.BuscarFuncionarioPorId(id);
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<ActionResult<MFuncionarios>> Cadastrar([FromBody] MFuncionarios funcionarioModel)
        {
            MFuncionarios funcionario = await _funcionariosRepository.AdicionarFuncionario(funcionarioModel);

            return Ok(funcionario);
        }

        [HttpPut]
        public async Task<ActionResult<MFuncionarios>> AtualizarFuncionario(MFuncionarios funcionarioModel, int id)
        {
            return await _funcionariosRepository.AtualizarFuncionario(funcionarioModel, id);
        }

        [HttpDelete]
        public async Task<ActionResult<MFuncionarios>> DeletarFuncionario(int id)
        {
            var success = await _funcionariosRepository.ApagarFuncionario(id);
            return Ok(success);
        }

    }
}