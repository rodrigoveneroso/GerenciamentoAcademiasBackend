using Academia.Models;
using Academia.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Academia.Repositorys
{
    // Implementacao do repositorio de enderecos; fornece metodos para o CRUD de enderecos
    public class EnderecosRepository : IEnderecosRepository
    {
        private readonly AcademiaContext _context;
        public EnderecosRepository(AcademiaContext context)
        {
            _context = context;
        }

        // Busca um endereco pelo ID
        public async Task<MEnderecos> BuscarEnderecoPorId(int id)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(a => a.Id_endereco == id);
        }

        // Busca todos os enderecos cadastrados
        public async Task<List<MEnderecos>> BuscarEnderecos()
        {
            return await _context.Enderecos.ToListAsync();
        }

        // Adiciona um endereco
        public async Task<MEnderecos> AdicionarEndereco(MEnderecos enderecoModel)
        {
            await _context.Enderecos.AddAsync(enderecoModel);
            await _context.SaveChangesAsync();
            return enderecoModel;
        }

        // Atualiza um endereco
        public async Task<MEnderecos> AtualizarEndereco(MEnderecos enderecoModel, int id)
        {
            var endereco = await BuscarEnderecoPorId(id);
            if (endereco == null)
            {
                throw new Exception($"Contrato para o ID: {id} não foi encontrado no banco de dados.");
            }

            endereco.CEP_endereco = enderecoModel.CEP_endereco;
            endereco.Rua_endereco = enderecoModel.Rua_endereco;
            endereco.Bairro_endereco = enderecoModel.Bairro_endereco;
            endereco.Numero_endereco = enderecoModel.Numero_endereco;
            endereco.Cidade_endereco = enderecoModel.Cidade_endereco;

            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }

        // Apaga um endereco pelo ID
        public async Task<bool> ApagarEndereco(int id)
        {
            var endereco = await BuscarEnderecoPorId(id);
            if (endereco == null)
            {
                throw new Exception($"Endereco para o ID: {id} não foi encontrado no banco de dados.");
            }
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();

            return true;
        }



    }
}
