## 🚀 .NET Aspire

O projeto suporta modernização e observabilidade via **[.NET Aspire](https://learn.microsoft.com/aspire)** — um **conjunto de ferramentas para desenvolvimento e monitoramento de aplicações distribuídas** baseado em .NET, criado pela Microsoft.

> Aspire é ideal para organizar serviços como APIs, banco de dados, mensageria, cache e mais, com foco em ambientes modernos (Kubernetes, containers, nuvem).

### 📦 O que o Aspire oferece?

* **Orquestração de Serviços**: Configurações centralizadas para Web APIs, bancos, cache, filas etc.
* **Observabilidade Integrada**: Tracing, logs estruturados, dashboards.
* **Aspire Dashboard**: UI web integrada com visualização de dependências.
* **Integração com OpenTelemetry** e Prometheus/Grafana.

### ✅ Vantagens para este projeto

* Substitui a configuração manual do `docker-compose` (opcional)
* Monitora Redis, PostgreSQL, MongoDB e a WebAPI com rastreamento de chamadas
* Melhora a **produtividade no desenvolvimento** e **confiabilidade em produção**
* Aumenta a **visibilidade dos serviços** e ajuda na **identificação de gargalos**

### 📁 Estrutura Recomendada com Aspire

```plaintext
src/
├── dopAmbevEvaluation.WebApi/       # Projeto principal
├── dopAmbevEvaluation.Infrastructure/
├── dopAmbevEvaluation.Domain/
├── dopAmbevEvaluation.Application/
├── dopAmbevEvaluation.Aspire.AppHost/   # Projeto do Aspire que orquestra os serviços
└── dopAmbevEvaluation.Aspire.Dashboard/ # Interface web para observabilidade
```

### ▶️ Como usar o Aspire

> Requer: .NET 8 SDK (ou superior)

1. **Instale o Aspire workload** (caso ainda não tenha):

```bash
dotnet workload install aspire
```

2. **Adicione o projeto Aspire.AppHost**:

```bash
dotnet new aspire-app -n dopAmbevEvaluation.Aspire.AppHost
```

3. **Adicione referências para os seus serviços** no `AppHost.csproj`:

```xml
<ItemGroup>
  <ProjectReference Include="..\dopAmbevEvaluation.WebApi\dopAmbevEvaluation.WebApi.csproj" />
</ItemGroup>
```

4. **Execute o host**:

```bash
dotnet run --project dopAmbevEvaluation.Aspire.AppHost
```

### 🌐 Dashboard Aspire

Ao iniciar o projeto, acesse o dashboard via:

```
http://localhost:18888
```

Você verá:

* Health checks
* Conexões entre serviços
* Logs e tracing de cada requisição
* Métricas em tempo real

