using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academia_Volvo.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    Id_item_inventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade_item_inventario = table.Column<int>(type: "int", nullable: false),
                    Descricao_item_inventario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id_item_inventario);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id_plano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao_plano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor_plano = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dias_plano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id_plano);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id_aluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF_aluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_nascimento_aluno = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Telefone_aluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_aluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome_aluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_endereco = table.Column<int>(type: "int", nullable: true),
                    Id_aula = table.Column<int>(type: "int", nullable: true),
                    Id_contrato = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id_aluno);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id_receita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_receita = table.Column<DateOnly>(type: "date", nullable: false),
                    Descricao_receita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor_receita = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_aluno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id_receita);
                    table.ForeignKey(
                        name: "FK_Receitas_Alunos_Id_aluno",
                        column: x => x.Id_aluno,
                        principalTable: "Alunos",
                        principalColumn: "Id_aluno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    Id_aula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao_aula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_aula = table.Column<DateOnly>(type: "date", nullable: false),
                    Id_funcionario = table.Column<int>(type: "int", nullable: false),
                    Id_aluno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Id_aula);
                    table.ForeignKey(
                        name: "FK_Aulas_Alunos_Id_aluno",
                        column: x => x.Id_aluno,
                        principalTable: "Alunos",
                        principalColumn: "Id_aluno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id_contrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_pagamento = table.Column<DateOnly>(type: "date", nullable: false),
                    Data_inicio_contrato = table.Column<DateOnly>(type: "date", nullable: false),
                    Id_aluno = table.Column<int>(type: "int", nullable: false),
                    Id_funcionario = table.Column<int>(type: "int", nullable: false),
                    Id_plano = table.Column<int>(type: "int", nullable: false),
                    Id_receita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id_contrato);
                    table.ForeignKey(
                        name: "FK_Contratos_Alunos_Id_aluno",
                        column: x => x.Id_aluno,
                        principalTable: "Alunos",
                        principalColumn: "Id_aluno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Planos_Id_plano",
                        column: x => x.Id_plano,
                        principalTable: "Planos",
                        principalColumn: "Id_plano",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Receitas_Id_receita",
                        column: x => x.Id_receita,
                        principalTable: "Receitas",
                        principalColumn: "Id_receita",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id_despesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_despesa = table.Column<DateOnly>(type: "date", nullable: false),
                    Descricao_despesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor_despesa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_funcionario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id_despesa);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id_endereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua_endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP_endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero_endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro_endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento_endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade_endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_funcionario = table.Column<int>(type: "int", nullable: true),
                    Id_aluno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id_endereco);
                    table.ForeignKey(
                        name: "FK_Enderecos_Alunos_Id_aluno",
                        column: x => x.Id_aluno,
                        principalTable: "Alunos",
                        principalColumn: "Id_aluno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id_funcionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF_funcionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_nascimento_funcionario = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Telefone_funcionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario_funcionario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email_funcionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome_funcionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo_Funcionario = table.Column<int>(type: "int", nullable: false),
                    Id_endereco = table.Column<int>(type: "int", nullable: true),
                    Id_despesas = table.Column<int>(type: "int", nullable: true),
                    Id_aula = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id_funcionario);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Aulas_Id_aula",
                        column: x => x.Id_aula,
                        principalTable: "Aulas",
                        principalColumn: "Id_aula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Despesas_Id_despesas",
                        column: x => x.Id_despesas,
                        principalTable: "Despesas",
                        principalColumn: "Id_despesa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Enderecos_Id_endereco",
                        column: x => x.Id_endereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id_endereco",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Id_aula",
                table: "Alunos",
                column: "Id_aula");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Id_contrato",
                table: "Alunos",
                column: "Id_contrato");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Id_endereco",
                table: "Alunos",
                column: "Id_endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_Id_aluno",
                table: "Aulas",
                column: "Id_aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_Id_funcionario",
                table: "Aulas",
                column: "Id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Id_aluno",
                table: "Contratos",
                column: "Id_aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Id_funcionario",
                table: "Contratos",
                column: "Id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Id_plano",
                table: "Contratos",
                column: "Id_plano");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Id_receita",
                table: "Contratos",
                column: "Id_receita");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_Id_funcionario",
                table: "Despesas",
                column: "Id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_Id_aluno",
                table: "Enderecos",
                column: "Id_aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_Id_funcionario",
                table: "Enderecos",
                column: "Id_funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Id_aula",
                table: "Funcionarios",
                column: "Id_aula");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Id_despesas",
                table: "Funcionarios",
                column: "Id_despesas");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Id_endereco",
                table: "Funcionarios",
                column: "Id_endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_Id_aluno",
                table: "Receitas",
                column: "Id_aluno");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Aulas_Id_aula",
                table: "Alunos",
                column: "Id_aula",
                principalTable: "Aulas",
                principalColumn: "Id_aula",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Contratos_Id_contrato",
                table: "Alunos",
                column: "Id_contrato",
                principalTable: "Contratos",
                principalColumn: "Id_contrato",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Enderecos_Id_endereco",
                table: "Alunos",
                column: "Id_endereco",
                principalTable: "Enderecos",
                principalColumn: "Id_endereco",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Funcionarios_Id_funcionario",
                table: "Aulas",
                column: "Id_funcionario",
                principalTable: "Funcionarios",
                principalColumn: "Id_funcionario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Funcionarios_Id_funcionario",
                table: "Contratos",
                column: "Id_funcionario",
                principalTable: "Funcionarios",
                principalColumn: "Id_funcionario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Funcionarios_Id_funcionario",
                table: "Despesas",
                column: "Id_funcionario",
                principalTable: "Funcionarios",
                principalColumn: "Id_funcionario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Funcionarios_Id_funcionario",
                table: "Enderecos",
                column: "Id_funcionario",
                principalTable: "Funcionarios",
                principalColumn: "Id_funcionario",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Aulas_Id_aula",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Aulas_Id_aula",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Contratos_Id_contrato",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Enderecos_Id_endereco",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Enderecos_Id_endereco",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Funcionarios_Id_funcionario",
                table: "Despesas");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Despesas");
        }
    }
}
