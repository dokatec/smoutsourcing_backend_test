# SM Outsourcing Frontend Teste

## Descrição

Desenvolvimento de uma API RESTful  utilizando ASP.Net Core e PostgreSQL. Implementando os seguintes requisitos:

1. Criar um endpoint para listar todos os usuários cadastrados no sistema.
2. Criar um endpoint para cadastrar um novo usuário no sistema.
3. Criar um endpoint para atualizar as informações de um usuário existente.
4. Criar um endpoint para excluir um usuário do sistema.
5. Implementar validações de entrada de dados nos endpoints.
6. Utilizar o padrão CQS (Command Query Separation) para separar operações de leitura (query) e operações de escrita (command).
7. Realizar testes unitários utilizando XUnit para garantir a qualidade do código.
8. Expor as APIs utilizando o Swagger.



## Tecnologias Utilizadas

<!-- - **Frontend:** [Javascript, HTML, CSS, Angular 18, Axios, RxJS, Validator] -->
- **backend:** [Asp.net core 8, Clean, Xunit, CQC, Swagger]
- **Banco de dados:** [Postgres]
- **Outras:** []

## Pré-requisitos

- **.Net Core:** [--version 8]

## Instalação

1. **Clonar o repositório:**

   ```bash
   git clone https://github.com/dokatec/smoutsourcing_backend_test.git

   ```

2. **Acessar a pasta via CLI:**

   ```bash
   cd smoutsourcing_backend_test

   ```

3. **Fazer o update com os context para criar o banco de dados e tabelas e iniciar a API via CLI:**

   ```bash
   dotnet ef database update --context UserDbContext

   dotnet ef database update --context AuthDbContext

   dotnet run


   ```

4. **Acessar a aplicação pelo localhost:**

   ```bash
   http://localhost:5029/swagger

   Por favor verificar a porta padrão 5029 caso esteja em uso com outra aplicação o proprio CLI irá informar a porta padrão.

   ```   

5. **Endereço padrão do backend da API .Net Core 8 com asp.net**

   ```bash

      Endereço da API para cadastro de usuarios.
    
      GET ->  http://localhost:5029/api/user
      POST -> http://localhost:5029/api/user
      GET ->  http://localhost:5029/api/user/{id}
      PUT ->  http://localhost:5029/api/user/{id}
      DELETE ->  http://localhost:5029/api/user/{id}

   ```
6. **Conteudo Adicional do backend da API .Net Core 8 com asp.net para acessar via frontend**

   ```bash

      Endereço da API para login e cadastro de usuarios para acessar o sistema via frontend
    
      POST -> http://localhost:5029/api/auth/register
      POST -> http://localhost:5029/api/auth/login
     

   ```

