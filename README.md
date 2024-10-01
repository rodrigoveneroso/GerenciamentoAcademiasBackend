# Sistema de Gerenciamento de academias (Back End)

## [Vídeo rápido do programa funcionando](https://www.youtube.com/watch?v=GYMiqaH4Nrk)

[![YouTube Thumbnail](https://img.youtube.com/vi/GYMiqaH4Nrk/maxresdefault.jpg)](https://www.youtube.com/watch?v=GYMiqaH4Nrk)

## Projeto desenvolvido para o programa de Estágio em Desenvolvimento de Aplicações da VOLVO em Fevereiro de 2024.
   
## [Clique aqui para acessar o repositório do Front End do programa](https://github.com/rodrigoveneroso/GerenciamentoAcademiasFrontend)


## Autores
Phillip Dylan e Rodrigo Kenji

## Tecnologias utilizadas
1. Back-end: .NET e Entity Framework
2. Banco de dados: SQL Server
3. Front-end: Windows Forms

   O Código foi criado com base nos padrões de projeto MVC (Model-View-Controller) e Repository.

## Sobre o programa
O projeto consiste em um sistema de gerenciamento de academia, contendo várias funcionalidades que podem ser necessárias para uma boa gestão de seus alunos, planos, funcionarios e financias.

## Funcionalidades
- Realizar o CRUD (Create, Read, Update e Delete) de alunos, funcionarios, planos, despesas e itens do inventário  
- Gerar relatórios de Faturamento, Vendas, Despesas, Lucro, Planos ativos e Planos a vencer, tudo por uma interface amigável e intuitiva ao usuário.

## Tutorial de utilizaçãoo
- Clone os projetos no github (tanto o Back End quanto o Front End)

- Troque as variávies de ambiente (Arquivo ConfigResource.resx) e colocar em BaseApiURL o endereço principal do backend (exemplo: https://localhost:5146?api) e no backend alterar em lauchSettings.json em "applicationUrl" em https e http o endereço (exemplo: https://localhost:5146?api) 

- Ao rodar a IDE, rode simultaneamente backend em HTTP o e o front-end normalmente.
