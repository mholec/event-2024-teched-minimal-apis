# TechEd 2024 - Minimal APIs

Repository obsahuje ukázkové aplikace pro konferenci TechEd 2024 demonstrující různé aspekty a možnosti ASP.NET Core Minimal APIs v .NET 8.

## Přehled projektů

Repository obsahuje tři různé projekty, každý demonstrující jiné funkcionality a pokročilé techniky práce s Minimal APIs:

### 🚀 AotDemo
**Ahead-of-Time (AOT) kompilace s Minimal APIs**

Jednoduchá Todo API aplikace optimalizovaná pro AOT kompilaci, která demonstruje:
- Použití `WebApplication.CreateSlimBuilder()` pro optimalizovanou aplikaci
- Konfiguraci `JsonSerializerContext` pro AOT kompatibilitu
- Minimální závislosti a rychlé spuštění aplikace
- Native kompilaci pro lepší výkon

**Endpointy:**
- `GET /todos` - Seznam všech úkolů
- `GET /todos/{id}` - Detail konkrétního úkolu

### 📚 Basic (BigMinimal.Basic)
**Základní funkcionalita Minimal APIs**

Projekt demonstrující základní koncepty a vzory pro Minimal APIs:

**Klíčové funkcionality:**
- **Product API** - CRUD operace pro správu produktů
- **Polymorfní JSON serializace** - Podpora různých typů produktů (Product, Book, Phone) s type discriminators
- **Vlastní Exception Handlers** - Centralizované zpracování chyb (`ArgumentExHandler`, `GeneralExHandler`)
- **Vlastní Results** - Export dat do CSV formátu
- **Keyed Services** - Dependency injection s pojmenovanými službami
- **CORS konfigurace** - Cross-origin resource sharing
- **Problem Details** - Standardizované error responses

**Endpointy:**
- `GET /api/products/{id}` - Detail produktu podle ID
- `GET /api/products` - Seznam produktů s podporou filtrování a CSV exportu
- `POST /api/products` - Vytvoření nového produktu

### 🏗️ Advanced (BigMinimal.Advanced)
**Pokročilé techniky a architektury**

Nejpokročilejší projekt demonstrující enterprise-ready vzory a techniky:

**Architektonické vzory:**
- **Auto-registrace** - Automatické registrování API routes pomocí `IApiRoute` interface
- **MediatR integrace** - CQRS pattern pro oddělení commands a queries
- **FluentValidation** - Robustní validace vstupních dat
- **Pipeline Behaviors** - Middleware pro cross-cutting concerns
- **Endpoint Filters** - Logování a preprocessing requests

**API Controllers:**
- **Cars** - Základní ukázka registrace nad group
- **Motorbikes** - SubGroups a endpoint filtry s ukázkou error handling
- **Tractors** - Pokročilá pipeline s MediatR pro safe operace
- **Trucks** - Validace s FluentValidation a MediatR

**Ukázané technologie:**
- MediatR pro mediator pattern
- FluentValidation pro business rule validation
- Endpoint filtering pro logging a monitoring
- Exception handling pipeline
- Sub-grouping pro organizaci API

## Struktura řešení

```
📁 event-2024-teched-minimal-apis/
├── 📁 AotDemo/                    # AOT optimalizovaná aplikace
│   ├── Program.cs                 # Todo API s AOT podporou
│   └── AotDemo.csproj            # AOT konfigurace
├── 📁 Basic/                      # Základní Minimal APIs
│   ├── Program.cs                 # Hlavní aplikace
│   ├── 📁 Contracts/             # Data modely (Product, Book, Phone)
│   ├── 📁 Services/              # Business logika
│   ├── 📁 ExceptionHandlers/     # Zpracování chyb
│   └── 📁 Results/               # Vlastní response typy
├── 📁 Advanced/                   # Pokročilé vzory
│   ├── Program.cs                 # Aplikace s MediatR a validací
│   ├── 📁 Api/                   # Auto-registrované API controllers
│   ├── 📁 Autoregistration/      # Registrace pomocí reflection
│   ├── 📁 Handlers/              # MediatR handlers
│   ├── 📁 Validators/            # FluentValidation rules
│   └── 📁 ExceptionHandlers/     # Pokročilé error handling
└── Demo.sln                      # Visual Studio solution
```

## Spuštění aplikací

### Předpoklady
- .NET 8 SDK
- Visual Studio 2022 / VS Code / JetBrains Rider

### Spuštění

**Základní aplikace:**
```bash
cd Basic
dotnet run
```
Aplikace bude dostupná na `https://localhost:5001`

**Pokročilá aplikace:**
```bash
cd Advanced  
dotnet run
```
Aplikace bude dostupná na `https://localhost:5001`

**AOT Demo:**
```bash
cd AotDemo
dotnet run
```
Aplikace bude dostupná na `https://localhost:5001`

### Testování API

Můžete použít následující nástroje pro testování:
- **Swagger UI** - automaticky dostupná na `/swagger` (pouze pro Basic a Advanced)
- **Postman/Insomnia** - pro manuální testování
- **curl** - pro command line testování

**Příklad curl požadavků:**

```bash
# Získání seznamu produktů
curl -X GET "https://localhost:5001/api/products"

# Získání produktu podle ID  
curl -X GET "https://localhost:5001/api/products/1"

# Export produktů do CSV
curl -X GET "https://localhost:5001/api/products" -H "Accept: text/csv"

# Vytvoření nového produktu
curl -X POST "https://localhost:5001/api/products" \
  -H "Content-Type: application/json" \
  -d '{"title": "Nový produkt", "price": 99.99}'
```

## Klíčové koncepty demonstrované

### 1. **Minimal APIs Organizace**
- Route grouping pro logické seskupení
- Auto-registration pattern pro škálovatelnost
- Endpoint filtering pro cross-cutting concerns

### 2. **Validation a Error Handling**
- FluentValidation pro business rules
- Centralizované exception handling
- Problem Details pro standardizované errors

### 3. **Performance a Optimalizace**
- AOT compilation pro rychlejší start
- Slim builder pro menší memory footprint
- Keyed services pro efektivní DI

### 4. **Enterprise Patterns**
- MediatR pro CQRS
- Pipeline behaviors pro middleware logic
- Polymorfní serializace pro flexibilní API

Generováno automaticky pomocí GitHub Copilot.
