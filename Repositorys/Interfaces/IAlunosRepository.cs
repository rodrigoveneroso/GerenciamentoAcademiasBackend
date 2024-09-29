using Academia.Models;

namespace Academia.Repositorys.Interfaces
{
    // Interface para o repositorio de alunos, define os metodos para o CRUD

    public interface IAlunosRepository
    {
        Task<List<MAlunos>> BuscarAlunos();
        Task<MAlunos> BuscarAlunoPorId(int id);
        Task<MAlunos> AdicionarAluno(MAlunos alunoModel);
        Task<MAlunos> AtualizarAluno(MAlunos alunoModel, int id);
        Task<bool> ApagarAluno(int id);
    }
}
