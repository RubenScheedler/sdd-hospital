# Research for Patient Registration Feature and Project Setup

## Decision: .NET 9 Clean Architecture with Aspire
- **Rationale:** Clean architecture separates concerns, improves testability, and aligns with modern .NET best practices. Aspire enables cloud-native development and orchestration.
- **Alternatives considered:** Layered architecture, monolithic structure, hexagonal architecture.

## Decision: REST API with Swagger
- **Rationale:** REST is the standard for web APIs. Swagger (OpenAPI) provides interactive documentation and client generation.
- **Alternatives considered:** GraphQL, gRPC, manual documentation.

## Decision: Domain Event Publishing
- **Rationale:** Domain events decouple business logic and enable extensibility. Console publisher is used for demo; can be replaced with message bus.
- **Alternatives considered:** Direct service calls, message queues (RabbitMQ, Azure Service Bus).

## Decision: Validation Rules for Patient Registration
- **Rationale:** Common defaults used (required fields: name, date of birth, unique identifier). No custom rules specified.
- **Alternatives considered:** Custom validation, business-specific rules.

## Decision: Authentication/Authorization
- **Rationale:** Not specified; endpoint is open for now. Can be extended with ASP.NET Core Identity or JWT.
- **Alternatives considered:** API key, OAuth2, custom auth.

---

All "NEEDS CLARIFICATION" items are resolved for initial implementation. Further details can be added as requirements evolve.
