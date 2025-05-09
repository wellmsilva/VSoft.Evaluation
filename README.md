# Projeto de avaliação da VSoft

--- 
## Contexto da Aplicação

 

Este sistema visa automatizar a gestão das aulas teóricas para candidatos à obtenção da
Carteira Nacional de Habilitação (CNH), facilitando a interação entre Centros de Formação
de Condutores (CFCs) e Departamentos de Trânsito (Detrans).
Os CFCs poderão cadastrar alunos, agendar aulas e acompanhar o progresso dos
candidatos, garantindo que cumpram os requisitos necessários para a prova prática. Os
Detrans terão acesso ao sistema para verificar se os alunos completaram o número mínimo
de aulas teóricas exigidas.
Os alunos poderão acompanhar seu progresso e visualizar quando estarão aptos para
realizar a prova prática, com base no número de aulas realizadas. O objetivo do sistema é
integrar os fluxos de trabalho entre CFCs, alunos e Detrans, proporcionando maior controle
e automação no processo de habilitação. Além disso, o sistema deve fornecer uma interface
que permita a interação do usuário.


## Tecnologias utilizadas:

- Backend:

    -  **.NET 8.0:** -  https://github.com/dotnet/core

    - **C#:** -  https://github.com/dotnet/csharplang


 - Frontend:
    - **Vue:** - 
    - **Vuetify:** - 
    - **Vite:** - 
    - **VeeValidate** -    

- Banco de dados:
    - **EF Core:** https://github.com/dotnet/efcore
    - **Postgress:** - 
- Mensageria:
    - **Rabbitmq:**
    - **MassTransit** https://github.com/MassTransit/MassTransit

   

## Estrutura do Projeto

## Como executar a API

### 1. Executando com Docker Compose (Recomendado)
Navegue até o diretório de backend:

```sh
cd backend
```

Execute o seguinte comando para iniciar os serviços:

```sh
docker compose up -d
```

### 2. Aplicando Migrações de Banco de Dados

Após iniciar os serviços, aplique as migrações:

```sh
dotnet ef database update -s .\src\VSoft.Evaluation.WebApi\ -p .\src\VSoft.Evaluation.Infrastructure\
```
## Documentação da API

Você pode acessar a documentação da API via Swagger:

```
https://localhost:8081/swagger/index.html
```