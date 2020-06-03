# Cadastro de Ordem de Serviços para Laboratórios Clínicos com Angular, C# .Net Code, Swagger, PostgreSQL e Docker
Exemplo de cadastro de ordem de serviços para laboratórios clínicos com C#, .Net Core, Swagger e PostgreSQL no backend e Angular v9 no frontend, sendo executados em container Docker através do Docker-Compose.

## Database com PostgreSQL
* Utiliza a imagem Docker oficial do PostgreSQL para publicação do banco de dados
* É necessário criar uma pasta local `/PostgreSQL/db` para armazenar os arquivos físicos do banco de dados

## Backend com C# .Net Core
* Utiliza o pacote `Swashbuckle.AspNetCore@5.4.1` para documentação das API via Swagger com possibilidade para testa-las
* Utiliza o pacote `Microsoft.EntityFrameworkCore.Tools@3.1.4` e `Npgsql.EntityFrameworkCore.PostgreSQL@3.1.4` para conexão com o banco de dados PostgreSQL através do Entity Framework Core
* Utiliza o pacote `FluentValidation@8.6.2` para validação das regras de negócios das entidades do domínio
* Utiliza a imagem Docker oficial do .Net Core (alpine) para publicação das API's

## Frontend com Angular v9
* Aplicação criada através do `ng new <myapp>`
* Utiliza o pacote `bootstrap@4.5.0` para o design do layout

* Utiliza o pacote `react-router-dom@^5.2.0` para fazer o roteamento das páginas da aplicação
* Utiliza o pacote `axios@0.19.2` para comunicação com API do backend


## Executar a aplicação
* É necessario a instalação do [Docker](https://www.docker.com/products/docker-desktop).

### Docker-Compose
1. Executar `docker-compose up --force-recreate` através do terminar ou Docker Quickstart Terminal (para Windows 10 Home).
2. Navegar para `http://localhost` ou `http://<container ip>`