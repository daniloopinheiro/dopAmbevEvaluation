# dopAmbevEvaluation

## Descrição

O **dopAmbevEvaluation** é um projeto de software desenvolvido para gerenciar registros de vendas. Ele permite cadastrar, consultar, atualizar e remover vendas, incluindo itens, produtos e informações detalhadas de cada transação.

O projeto foi desenvolvido utilizando **.NET 8**, seguindo **Domain-Driven Design (DDD)**, garantindo **manutenibilidade, escalabilidade e clareza de responsabilidades** entre camadas.

---

## Índice

* [Visão Geral](#visão-geral)
* [Tecnologias Utilizadas](#tecnologias-utilizadas)
* [Instalação](#instalação)
* [Como Usar](#como-usar)
* [Estrutura de Diretórios](#estrutura-de-diretórios)
* [Configuração](#configuração)
* [Serviços Docker](#serviços-docker)
* [Contribuições](#contribuições)
* [Licença](#licença)
* [Contato](#contato)

---

## Visão Geral

O projeto visa oferecer uma API robusta para gerenciamento de **vendas e itens de venda**, permitindo às empresas controlar suas transações com informações completas:

* Número da venda
* Data da venda
* Cliente
* Filial
* Produtos e quantidades
* Preços unitários e descontos
* Valor total de cada item e da venda
* Status da venda: Cancelada / Não Cancelada

O projeto segue **DDD** e utiliza o padrão de **Identidades Externas** para referência a entidades de outros domínios, com desnormalização das descrições para manter consistência e performance.

---

## Tecnologias Utilizadas

* **.NET 8**: Framework principal para desenvolvimento backend
* **Entity Framework Core**: ORM para acesso e manipulação do banco de dados
* **PostgreSQL**: Banco de dados relacional (via container)
* **MongoDB**: Banco de dados NoSQL (via container)
* **Redis**: Servidor de cache leve e de alta performance (via container)
* **Docker**: Containerização da aplicação e serviços auxiliares
* **Swagger / OpenAPI**: Documentação interativa da API

---

## Instalação

### Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Docker (para uso dos containers)
* Tecnologias usadas nos containers:

  * **PostgreSQL 13** (Banco de dados relacional)
  * **MongoDB 8.0** (Banco NoSQL)
  * **Redis 7.4.1-alpine** (Cache)

### Passos para Instalar

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/Ambev.DeveloperEvaluation.git
cd Ambev.DeveloperEvaluation
```

2. Restaure as dependências do projeto:

```bash
dotnet restore
```

3. Configure o banco de dados e variáveis de ambiente conforme [Configuração](#configuração).

4. Execute o projeto:

```bash
dotnet run --project Ambev.DeveloperEvaluation.WebApi
```

Ou via Docker:

```bash
docker-compose up
```

---

## Como Usar

A API oferece endpoints para gerenciar **vendas** e **itens de venda**.

### Endpoints Principais

#### Sales

* `GET /api/sales` → Listar vendas
* `GET /api/sales/{id}` → Obter venda por ID
* `POST /api/sales` → Criar nova venda
* `PUT /api/sales/{id}` → Atualizar venda
* `DELETE /api/sales/{id}` → Remover venda

#### SalesItem

* `POST /api/sales/{saleId}/items` → Adicionar item à venda
* `PUT /api/sales/{saleId}/items/{itemId}` → Atualizar item
* `DELETE /api/sales/{saleId}/items/{itemId}` → Remover item

### Exemplo com cURL

```bash
curl -X GET http://localhost:8080/api/sales -H "Content-Type: application/json"
```

---

## Estrutura de Diretórios

```plaintext
src/
├── Ambev.DeveloperEvaluation.Application/
├── Ambev.DeveloperEvaluation.Common/
├── Ambev.DeveloperEvaluation.Domain/
├── Ambev.DeveloperEvaluation.IoC/
├── Ambev.DeveloperEvaluation.ORM/
└── Ambev.DeveloperEvaluation.WebApi/
```

---

## 🧱 Sugestão Geral de Arquitetura

- [Sugestão Arquitetural](template/.doc/sugestao_arquitetural.md)

- [Sugestão Aspire .NET](template/.doc/aspire_net.md)

---

## 📄 Erros e Soluções

- [Erros e Soluções](template/.doc/erros_solutions.md)

---

## Configuração

### Banco de Dados

No `appsettings.json`:

```json
{
  "DatabaseSettings": {
    "ConnectionString": "Server=localhost;Database=dopAmbevDb;User Id=sa;Password=SuaSenha;",
    "DatabaseName": "dopAmbevDb"
  }
}
```

Variáveis de ambiente opcionais:

```bash
DATABASE_URL="Server=localhost;Database=dopAmbevDb;User Id=sa;Password=SuaSenha;"
SECRET_KEY="chave_secreta"
```

---

## Serviços Docker

O projeto inclui um ambiente completo usando **Docker** com os seguintes serviços:

### 1. 🟦 `ambev.developerevaluation.webapi`

* **Tecnologia**: ASP.NET Core (.NET 8)
* **Função**: API principal da aplicação
* **Portas**: `8080` (HTTP), `8081` (HTTPS)
* **Volume**: Secrets do usuário e certificado HTTPS

### 2. 🟨 `ambev.developerevaluation.database`

* **Tecnologia**: PostgreSQL 13
* **Função**: Banco de dados relacional da aplicação
* **Porta**: `5432`
* **Credenciais**:

  * Usuário: `developer`
  * Senha: `ev@luAt10n`

### 3. 🟩 `ambev.developerevaluation.nosql`

* **Tecnologia**: MongoDB 8.0
* **Função**: Armazenamento de dados NoSQL, logs ou auditoria
* **Porta**: `27017`
* **Credenciais**:

  * Usuário: `developer`
  * Senha: `ev@luAt10n`

### 4. 🟥 `ambev.developerevaluation.cache`

* **Tecnologia**: Redis 7.4.1 (Alpine)
* **Função**: Cache de dados, sessões, filas
* **Porta**: `6379`
* **Senha**: `ev@luAt10n`

> Execute todos os serviços com o comando:

```bash
docker-compose up
```

---

## Contribuições

Contribuições são bem-vindas!

1. Faça um **fork** do repositório
2. Crie uma branch (`git checkout -b feature/nova-feature`)
3. Faça commit das alterações (`git commit -m 'Adiciona nova feature'`)
4. Envie para o repositório (`git push origin feature/nova-feature`)
5. Crie um **pull request**

---

## Licença

Este projeto está licenciado sob a **MIT License**. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## Contato

* ✉️ **Email Pessoal**: [daniloopro@gmail.com](mailto:daniloopro@gmail.com)
* 🏢 **Email Empresarial (DevsFree)**: [devsfree@devsfree.com.br](mailto:devsfree@devsfree.com.br)
* 📊 **Consultoria (dopme.io)**: [contato@dopme.io](mailto:contato@dopme.io)
* 💼 **LinkedIn**: [Danilo O. Pinheiro](https://www.linkedin.com/in/daniloopinheiro)

---

<p align="center">
  Feito com ❤️ por <strong>Danilo O. Pinheiro</strong>
</p>

