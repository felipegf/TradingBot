# Trading Bot

## Descrição

O **Trading Bot** é um projeto focado no mercado de criptomoedas, cujo objetivo inicial é desenvolver um MVP que analise os dados de mercado e gere alertas sobre os melhores momentos para compra e venda. A aplicação utiliza **.NET Core**, **TDD**, **DDD** e outras boas práticas de desenvolvimento.

Este repositório é privado e destina-se ao aprendizado e desenvolvimento contínuo de um sistema robusto e escalável.

---

## Estrutura Inicial

A solução segue o padrão de Camadas com base no **DDD (Domain-Driven Design)**:

- **TradingBot.Application**: Camada de aplicação para orquestração de casos de uso.
- **TradingBot.Domain**: Camada de domínio, contendo entidades, serviços e lógica de negócio.
- **TradingBot.Infrastructure**: Camada de infraestrutura, responsável por persistência e integração com APIs externas.
- **TradingBot.Tests**: Testes unitários e de integração para garantir a qualidade do código.

---

## Tecnologias

- **Linguagem**: C# (.NET Core 7/8)
- **Banco de Dados**: SQLite (MVP) ou alternativa escalável
- **APIs Externas**: Binance, Coinbase (outras podem ser adicionadas)
- **Testes**: xUnit, FluentAssertions, TDD
- **Logs**: Serilog (Logs Estruturados)

---

## Instalação e Execução

1. Clone o repositório:
   ```bash
   git clone https://github.com/felipegf/TradingBot.git
