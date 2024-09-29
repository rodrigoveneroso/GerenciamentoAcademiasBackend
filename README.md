# Sistema de Gerenciamento de academias (Back End, o Front End está em outro projeto, chamado GerenciamentoAcademiasFrontEnd)

## Projeto desenvolvido para o programa de Estágio em Desenvolvimento de Aplicações da VOLVO.

## [Vídeo rápido do programa funcionando](https://www.youtube.com/watch?v=GYMiqaH4Nrk)

## Autores
Phillip Dylan e Rodrigo Kenji

## Tecnologias utilizadas
1. Back-end: .NET e Entity Framework
2. Banco de dados: SQL Server
3. Front-end: Windows Forms

## Sobre o programa:
O projeto consiste em um sistema de gerenciamento de academia, contendo várias funcionalidades que podem ser necessárias para uma boa gestão de seus alunos, planos, funcionarios e financias.
Pelo programa é possível realizar o CRUD (Create, Read, Update e Delete) de alunos, funcionarios, planos, despesas e itens do inventario, além de gerar relatórios de Faturamento, Vendas, Despesas, Lucro, Planos ativos e Planos a vencer, tudo por uma interface amigável e intuitiva ao usuário.

O Código foi criado com base nos padrões de projeto MVC (Model-View-Controller) e Repository.

## Tutorial de utilizaçãoo:
Primeiramente faça o Download do projeto no github [Clique aqui para acessar o projeto](https://github.com/Rocket-Galaxy/Academia_GUI)

Trocar as variávies de ambiente (Arquivo ConfigResource.resx) e colocar em BaseApiURL o endereço principal do backend (exemplo: https://localhost:5146?api) e no backend alterar em lauchSettings.json em "applicationUrl" em https e http o endereço (exemplo: https://localhost:5146?api) 

Ao rodar a IDE, rode simultaneamente backend em HTTP o e o front-end normalmente.
