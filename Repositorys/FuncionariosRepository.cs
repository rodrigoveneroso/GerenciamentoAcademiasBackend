using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de funcionarios; fornece metodos para o CRUD de funcionarios
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private readonly AcademiaContext _context;
        public FuncionariosRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca um funcionario pelo ID
        public async Task<MFuncionarios> BuscarFuncionarioPorId(int id)
        {
            return await _context.Funcionarios.FirstOrDefaultAsync(a => a.Id_funcionario == id);
        }

        // Busca todos os funcionarios cadastrados
        public async Task<List<MFuncionarios>> BuscarFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        // Adiciona um funcionario
        public async Task<MFuncionarios> AdicionarFuncionario(MFuncionarios funcionarioModel)
        {
            await _context.Funcionarios.AddAsync(funcionarioModel);
            await _context.SaveChangesAsync();
            return funcionarioModel;
        }

        // Atualiza um funcionário
        public async Task<MFuncionarios> AtualizarFuncionario(MFuncionarios funcionarioModel, int id)
        {
            var funcionario = await BuscarFuncionarioPorId(id);
            if (funcionario == null)
            {
                throw new Exception($"Funcionario para o ID: {id} não foi encontrado no banco de dados.");
            }

            funcionario.Nome_funcionario = funcionarioModel.Nome_funcionario;
            funcionario.Salario_funcionario = funcionarioModel.Salario_funcionario;
            funcionario.CPF_funcionario = funcionarioModel.CPF_funcionario;
            funcionario.Email_funcionario = funcionarioModel.Email_funcionario;
            funcionario.Cargo_Funcionario = funcionarioModel.Cargo_Funcionario;
            funcionario.Data_nascimento_funcionario = funcionarioModel.Data_nascimento_funcionario;

            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();

            return funcionario;
        }

        // Apaga um funcionario pelo ID
        public async Task<bool> ApagarFuncionario(int id)
        {
            var funcionario = await BuscarFuncionarioPorId(id);
            if (funcionario == null)
            {
                throw new Exception($"funcionario para o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
