using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorys
{
    public class AlunosRepository : IAlunosRepository
    {
        // Implementacao do repositorio de alunos; fornece metodos para o CRUD de alunos

        private readonly AcademiaContext _context;
        public AlunosRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca um aluno pelo ID
        public async Task<MAlunos> BuscarAlunoPorId(int id)
        {
            return await _context.Alunos.FirstOrDefaultAsync(a => a.Id_aluno == id);
        }

        // Busca todos os alunos cadastrados
        public async Task<List<MAlunos>> BuscarAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }

        // Adiciona um aluno
        public async Task<MAlunos> AdicionarAluno(MAlunos alunoModel)
        {
            await _context.Alunos.AddAsync(alunoModel);
            await _context.SaveChangesAsync();
            return alunoModel;
        }

        // Atualiza um aluno 
        public async Task<MAlunos> AtualizarAluno(MAlunos alunoModel, int id)
        {
            var aluno = await BuscarAlunoPorId(id);
            if(aluno == null)
            {
                throw new Exception($"Aluno para o ID: {id} não foi encontrado no banco de dados.");
            }

            aluno.Nome_aluno = alunoModel.Nome_aluno;
            aluno.Email_aluno = alunoModel.Email_aluno;

            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        // Apaga um aluno pelo ID
        public async Task<bool> ApagarAluno(int id)
        {
            var aluno = await BuscarAlunoPorId(id);
            if (aluno == null)
            {
                throw new Exception($"Aluno para o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
