# Home Finances

Projeto de desafio técnico para desenvolvedor Fullstack.

**OBS**: a documentação estará em português para facilitar a avaliação

**OBS 2**: o exercício opcional não foi feito


## Sobre o projeto

### WebApi
- Desenvolvido com .NET 10
- Utiliza Entity Framework
- Clean Architecture, separado nas camadas:
    - Domain: onde se concentram as entidades e regras de negócio da aplicação;
    - Application: onde ficam os serviços que fazem a orquestração das entidades, conversão de DTO para entidade e vice-versa;
    - API: projeto principal, onde ficam os controllers que são a "porta de entrada" para a API;
    - Infrastructure: onde ficam as implementações responsáveis pelo acesso ao banco de dados, como DBContext, repositórios e migrations; 
    - CrossCutting: projeto responsável pelas injeções de dependência. Ele que se preocupa com as referências transversais da aplicação.
- Foi aplicado conceitos de Domain Driven Design (DDD): centralizando as regras de negócio na camada Domain, priorizando domínios ricos.

### Frontend
- Desenvolvido com React 19
- Uso do pacote react-bootstrap para interface gráfica
- Vite como bundler do projeto


## Como executar o projeto

Recomenda-se utilizar o docker para executar uma instância do banco de dados. A seguir, comandos para auxiliar a instalação do docker em ambiente linux:
```bash
curl -fsSL https://get.docker.com -o get-docker.sh
sudo sh ./get-docker.sh --dry-run
```

A seguir, o passo a passo para execução do projeto:
```bash
# Executar container docker do PostgreSQL
docker run -p 5432:5432 -e POSTGRES_PASSWORD=1234 --name postgres -d postgres:18

# Executar a WebApi
dotnet watch --project HomeFinances.WebApi/HomeFinances.WebApi.Infrastructure

# Para o frontend é necessário antes criar um arquivo .env (variáveis de ambiente), dentro da pasta frontend, com a seguinte linha:
VITE_API_URL=http://localhost:5000

# Depois abra outra janela do terminal e execute o projeto
cd ./frontend/
npm i
npm run dev
```

## Funcionalidades

**Cadastro de pessoas (veja em src/pages/PersonPage no frontend e PersonController na webapi):**

Deverá ser implementado um cadastro contendo as funcionalidades básicas de gerenciamento: criação, deleção e listagem.

Em casos que se delete uma pessoa, todas a transações dessa pessoa deverão ser apagadas.

O cadastro de pessoa deverá conter:
- Identificador (deve ser um valor único gerado automaticamente);
- Nome (texto);
- Idade (número inteiro positivo);


**Cadastro de categorias (veja em src/pages/CategoryPage no frontend e CategoryController na webapi):**

Deverá ser implementado um cadastro contendo as funcionalidades básicas de gerenciamento: criação e listagem.

O cadastro de categoria deverá conter:
- Identificador (deve ser um valor único gerado automaticamente);
- Descrição (texto);
- Finalidade (despesa/receita/ambas)


**Cadastro de transações (veja em src/pages/TransactionPage no frontend e TransactionController na webapi):**

Deverá ser implementado um cadastro contendo as funcionalidades básicas de gerenciamento: criação e listagem.

Caso o usuário informe um menor de idade (menor de 18), apenas despesas deverão ser aceitas.

O cadastro de transação deverá conter:
- Identificador (deve ser um valor único gerado automaticamente);
- Descrição (texto);
- Valor (número decimal positivo);
- Tipo (despesa/receita);
- Categoria: restringir a utilização de categorias conforme o valor definido no campo finalidade. Ex.: se o tipo da transação é despesa, não poderá utilizar uma categoria que tenha a finalidade receita.
- Pessoa (identificador da pessoa do cadastro anterior);


**Consulta de totais por pessoa (veja em src/pages/HomePage no frontend e PersonController na webapi):**

Deverá listar todas as pessoas cadastradas, exibindo o total de receitas, despesas e o saldo (receita – despesa) de cada uma.

Ao final da listagem anterior, deverá exibir o total geral de todas as pessoas incluindo o total de receitas, total de despesas e o saldo líquido.


**Consulta de totais por categoria (não implementado):**

Deverá listar todas as categorias cadastradas, exibindo o total de receitas, despesas e o saldo (receita – despesa) de cada uma.

Ao final da listagem anterior, deverá exibir o total geral de todas as categorias incluindo o total de receitas, total de despesas e o saldo líquido.