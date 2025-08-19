Este projeto segue princípios de **Domain-Driven Design (DDD)**, e embora utilize convenções técnicas como `Common`, `IoC` e `ORM` para organização prática, recomendamos como alternativa uma estrutura **mais alinhada com os autores Eric Evans e Vaughn Vernon**, com foco na **separação de responsabilidades por camadas e contextos delimitados**.

### 📐 Estrutura de Diretórios Recomendada

```plaintext
src/
├── Domain/
│   ├── Models/             # Entidades, Value Objects, Agregados
│   ├── Services/           # Domain Services (Regras de Negócio)
│   ├── Repositories/       # Interfaces de acesso a dados
│   ├── Events/             # Eventos de domínio
│   └── Specifications/     # Regras de negócio reutilizáveis
│
├── Application/
│   ├── UseCases/           # Casos de uso (commands, queries, handlers)
│   ├── DTOs/               # Data Transfer Objects
│   ├── Interfaces/         # Interfaces de entrada (application services)
│   └── Services/           # Application Services
│
├── Infrastructure/
│   ├── Persistence/        # Implementações de repositórios e mappings
│   ├── IoC/                # Injeção de dependências
│   ├── Messaging/          # Integração com mensageria (ex: Kafka, RabbitMQ)
│   └── External/           # Serviços externos (API, Auth, etc)
│
├── Presentation/
│   ├── WebApi/             # Controllers e configuração da API
│   └── ViewModels/         # Modelos de resposta (opcional)
│
└── SharedKernel/           # Objetos e contratos compartilhados entre contextos
```

### ✅ Benefícios dessa estrutura:

* **Isolamento claro de camadas** (Domain, Application, Infrastructure, Presentation)
* **Foco no negócio**: a pasta `Domain` contém somente regras e modelos do negócio, sem dependências técnicas
* **Alinhamento com os Bounded Contexts** e com o conceito de Ubiquitous Language
* Facilita testes, manutenção e escalabilidade

---

### 📖 Referências

* *Eric Evans* – Domain-Driven Design: Tackling Complexity in the Heart of Software
* *Vaughn Vernon* – Implementing Domain-Driven Design