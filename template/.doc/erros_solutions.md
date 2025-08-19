Este documento registra os principais erros encontrados durante o desenvolvimento e configuração do projeto `dopAmbevEvaluation`, juntamente com suas respectivas soluções para facilitar manutenção, onboarding e troubleshooting futuro.

---

## 📌 Índice

1. [Erro: Backing Field '\_items' conflito com propriedade 'Items'](#erro-backing-field-_items)
2. [Erro: Migrations assembly incompatível](#erro-migrations-assembly)
3. [Erro: PostgreSQL exige senha](#erro-postgresql-password)
4. [Erro: Autenticação falhou para usuário "sa"](#erro-auth-user-sa)
5. [Erro: Falha ao criar DbContext via EF CLI](#erro-dbcontext-factory)
6. [Outros ajustes importantes](#outros-ajustes)

---

## 1. ❌ Erro: Backing Field `_items` conflito com propriedade `Items`

**Mensagem:**

```
The member 'Sale._items' cannot use field '_items' because it is already used by 'Sale.Items'.
```

**Causa:**
Uso incorreto de `HasMany` com nome de campo (`"_items"`) e `Navigation` com `PropertyAccessMode`.

**Solução:**

```csharp
b.HasMany(x => x.Items)
 .WithOne()
 .HasForeignKey(x => x.SaleId)
 .OnDelete(DeleteBehavior.Cascade);

b.Navigation(x => x.Items)
 .UsePropertyAccessMode(PropertyAccessMode.Field);
```

---

## 2. ❌ Erro: Migrations assembly incompatível

**Mensagem:**

```
Your target project 'Ambev.DeveloperEvaluation.ORM' doesn't match your migrations assembly 'Ambev.DeveloperEvaluation.WebApi'
```

**Causa:**
O `DbContext` está localizado em um projeto diferente do onde as migrations estão sendo aplicadas.

**Solução 1 – alterar migrations assembly via options:**

```csharp
options.UseNpgsql(connection, b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM"));
```

**Solução 2 – executar o comando no diretório do projeto que contém as migrations:**

```bash
cd src/Ambev.DeveloperEvaluation.ORM
dotnet ef migrations add InitialCreate
```

---

## 3. ❌ Erro: PostgreSQL exige senha

**Mensagem:**

```
Database is uninitialized and superuser password is not specified.
```

**Causa:**
O container do PostgreSQL exige a variável `POSTGRES_PASSWORD`.

**Solução:**
Adicionar ao `docker-compose.yml`:

```yaml
environment:
  POSTGRES_DB: developer_evaluation
  POSTGRES_USER: developer
  POSTGRES_PASSWORD: ev@luAt10n
```

---

## 4. ❌ Erro: Autenticação falhou para usuário `"sa"`

**Mensagem:**

```
28P01: password authentication failed for user "sa"
```

**Causa:**
Usuário `"sa"` é padrão do SQL Server, não do PostgreSQL.

**Solução:**
Corrigir a `DefaultConnection` no `appsettings.json`:

```json
"DefaultConnection": "Host=localhost;Port=5432;Database=developer_evaluation;Username=developer;Password=ev@luAt10n"
```

---

## 5. ❌ Erro: Falha ao criar `DbContext` via EF CLI

**Mensagem:**

```
Unable to create a 'DbContext'...
```

**Causa:** `DbContextFactory` não está configurando o caminho correto para `appsettings.json`.

**Solução:**

* Certifique-se de estar no mesmo diretório do projeto com `appsettings.json`.
* Ou use path fixo no `DbContextFactory` para leitura.

---

## 6. ⚙️ Outros ajustes importantes

* Configurar corretamente `UsePropertyAccessMode` com `Navigation`, **não com HasMany**.
* O nome da propriedade privada `_items` não deve colidir com propriedade pública `Items`.

