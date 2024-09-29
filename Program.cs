using Academia.Models;
using Academia.Repositorys;
using Academia.Repositorys.Interfaces;
using Academia.Repositorys;
using Academia.Repositorys.Interfaces;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace Academia
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Configurando o log de erros
            var logger = LogManager.GetCurrentClassLogger();

            // Cria o construtor da aplicacao Web
            var builder = WebApplication.CreateBuilder(args);


            // Configuracoes da aplicacao Web
            builder.Services.AddControllers();
            builder.Services.AddDbContext<AcademiaContext>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adiciona os repositorios e interfaces aos servicos
            builder.Services.AddScoped<IAlunosRepository, AlunosRepository>();
            builder.Services.AddScoped<IAulasRepository, AulasRepository>();
            builder.Services.AddScoped<IContratosRepository, ContratosRepository>();
            builder.Services.AddScoped<IDespesasRepository, DespesasRepository>();
            builder.Services.AddScoped<IEnderecosRepository, EnderecosRepository>();
            builder.Services.AddScoped<IFuncionariosRepository, FuncionariosRepository>();
            builder.Services.AddScoped<IInventarioRepository, InventarioRepository>();
            builder.Services.AddScoped<IPlanosRepository, PlanosRepository>();
            builder.Services.AddScoped<IReceitasRepository, ReceitasRepository>();
            builder.Services.AddScoped<IRelatorioFaturamentoRepository, RelatorioFaturamentoRepository>();
            builder.Services.AddScoped<IRelatorioPlanosAtivosRepository, RelatorioPlanosAtivosRepository>();
            builder.Services.AddScoped<IRelatorioVendasRepository, RelatorioVendasRepository>();
            builder.Services.AddScoped<IRelatorioDespesasRepository, RelatorioDespesasRepository>();
            builder.Services.AddScoped<IRelatorioLucroRepository, RelatorioLucroRepository>();
            builder.Services.AddScoped<IRelatorioPlanosAVencerRepository, RelatorioPlanosAVencerRepository>();


            // Constroi o aplicativo
            var app = builder.Build();

            // Verifica se o aplicativo esta rodando e configura o swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configura o redirecionamento HTTPS
            app.UseHttpsRedirection();

            // Configura a autorizacao
            app.UseAuthorization();

            // Mapeia os controllers
            app.MapControllers();

            // Roda a aplicacao
            app.Run();
        }
    }
}
