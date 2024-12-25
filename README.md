# Trading Bot

## Descrição

O **Trading Bot** é um projeto focado no mercado de criptomoedas, cujo objetivo é processar dados de mercado e gerar análises e alertas, identificando oportunidades para compra e venda de ativos. Este projeto utiliza **.NET Core** e segue as melhores práticas, incluindo **DDD** (Domain-Driven Design), **TDD** (Test-Driven Development) e **CQRS**.

---

## Estrutura do Projeto

A aplicação segue uma arquitetura modular com as seguintes camadas:

- **TradingBot.Application**: Contém os casos de uso e orquestração.
- **TradingBot.Domain**: Define as entidades, serviços de domínio e lógica de negócios.
- **TradingBot.Infrastructure**: Implementa persistência e integração com APIs externas.
- **TradingBot.Tests**: Testes unitários e de integração.

---

## Tecnologias Utilizadas

- **.NET Core 7/8**
- **xUnit** e **FluentAssertions** para testes.
- **MediatR** para implementação de CQRS.
- **Entity Framework Core** e **Dapper** para persistência.
- **Serilog** para logs estruturados.
- **APIs Externas**: Integração com Binance, Coinbase (ou outras fontes).

---

## Configuração Inicial

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/TradingBot.git
~~~~