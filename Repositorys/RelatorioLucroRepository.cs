using Academia.Enums;
using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de relatorio de lucro
    public class RelatorioLucroRepository : IRelatorioLucroRepository
    {
        private readonly AcademiaContext _context;
        public RelatorioLucroRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca uma lista de lucro dentro de um intervalo de tempo, fornecendo as receitas e despesas
        public async Task<List<object>> BuscarLucroPorIntervaloDataInicio(DateOnly dataInicio, DateOnly dataFim)
        {
            var receitas = await (from receita in _context.Receitas
                                  join aluno in _context.Alunos on receita.Id_aluno equals aluno.Id_aluno into gjAluno
                                  from aluno in gjAluno.DefaultIfEmpty()
                                  where (receita.Data_receita >= dataInicio && receita.Data_receita <= dataFim)
                                  select new
                                  {
                                      Receita = receita,
                                      Aluno = aluno
                                  }).ToListAsync();

            var despesas = await (from despesa in _context.Despesas
                                  where (despesa.Data_despesa >= dataInicio && despesa.Data_despesa <= dataFim)
                                  select new
                                  {
                                      Despesa = despesa.Valor_despesa
                                  }).ToListAsync();
            var funcionarios = await (from funcionario in _context.Funcionarios
                                      where funcionario.Status == EStatus.Ativo
                                      select new
                                      {
                                          Funcionario = funcionario.Salario_funcionario
                                      }).ToListAsync();

            var lucro = new List<object>
            {
                new { Tipo = "Receita", Dados = receitas.Cast<object>().ToList() },
                new { Tipo = "Despesa", Dados = despesas.Cast<object>().ToList() },
                new { Tipo = "DespesaFuncionario", Dados = funcionarios.Cast<object>().ToList() }
            };

            return lucro;
        }
    }
}
