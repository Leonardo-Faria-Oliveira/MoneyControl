# MoneyControl - Controle de Despesas

## Descrição

MoneyControl é uma aplicação para gerenciamento de despesas pessoais e empresariais. O projeto foi desenvolvido utilizando .NET 8 e segue os princípios da arquitetura Domain-Driven Design (DDD), garantindo modularidade, escalabilidade e manutenção facilitada.

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- ASP.NET Core Web API
- Swagger para documentação da API
- FluentValidation para validação
- xUnit para testes unitários
- MySQL

## Estrutura do Projeto

A solução está organizada em diferentes camadas seguindo os princípios do DDD:

```
MoneyControl
│── src
│   │── MoneyControl.Api               # Camada de API (aplicação Web)
│   │── MoneyControl.Application       # Regras de negócio e casos de uso
│   │── MoneyControl.Communication     # Objetos de Transferência (Requests, Responses)
│   │── MoneyControl.Domain            # Entidades, agregados e serviços de domínio
│   │── MoneyControl.Exception         # Tratamento de erros e exceções personalizadas
│   │── MoneyControl.Infrastructure    # Persistência de dados e integrações externas
│── tests
│   │── CommonTestUtilities            # Utilitários para testes
│   │── Validators.Test                # Testes de validação
```

## Como Executar o Projeto

### Requisitos:

- .NET 8 SDK
- MySQL
  
### Passos:

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/MoneyControl.git
   cd MoneyControl
   ```
2. Configure a string de conexão no arquivo `appsettings.json` da API.
3. Execute as migrações do banco de dados:
   ```bash
   dotnet ef database update --project src/MoneyControl.Infrastructure
   ```
4. Inicie a API:
   ```bash
   dotnet run --project src/MoneyControl.Api
   ```
5. Acesse o Swagger para testar os endpoints:
   ```
   http://localhost:5000/swagger
   ```

## Testes

Para executar os testes unitários:

```bash
dotnet test
```

