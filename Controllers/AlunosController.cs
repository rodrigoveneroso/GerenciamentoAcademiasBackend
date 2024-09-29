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

    public class AlunosController : ControllerBase
    {
        // Controller responsável por lidar com as operações relacionadas aos alunos

        private readonly IAlunosRepository _alunosRepository;
        private static readonly NLogger _logger = LogManager.GetCurrentClassLogger();

        public AlunosController(IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MAlunos>>> BuscarAlunos()
        {
            try
            {
                List<MAlunos> alunos = await _alunosRepository.BuscarAlunos();
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar alunos.");
                return StatusCode(500); 
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MAlunos>> BuscarAlunoPorId(int id)
        {
            try
            {
                MAlunos aluno = await _alunosRepository.BuscarAlunoPorId(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao buscar aluno com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MAlunos>> Cadastrar([FromBody] MAlunos alunoModel)
        {
            try
            {
                MAlunos aluno = await _alunosRepository.AdicionarAluno(alunoModel);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao cadastrar aluno.");
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MAlunos>> AtualizarAluno([FromBody]  MAlunos alunoModel, int id)
        {
            try
            { 
                var success = await _alunosRepository.AtualizarAluno(alunoModel, id);
                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao atualizar aluno com ID {id}.");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MAlunos>> DeletarAluno(int id)
        {
            try
            {
                var success = await _alunosRepository.ApagarAluno(id);
                return Ok(success);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao deletar aluno com ID {id}.");
                return StatusCode(500);
            }
        }


    }
}
