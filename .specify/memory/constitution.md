# SDD Hospital Back-end Constitution
<!-- Sync Impact Report

- Version change: TEMPLATE -> 1.0.0
- Modified principles: (placeholders replaced with concrete DDD/Clean Architecture principles)
- Added sections: Development Workflow, Quality Gates
- Removed sections: none (template placeholders replaced)
- Templates requiring updates: 
	- .specify/templates/plan-template.md ✅ updated
	- .specify/templates/spec-template.md ✅ updated
	- .specify/templates/tasks-template.md ✅ updated
	- .specify/templates/commands/*.md ⚠ pending (manual skim advised)
- Follow-up TODOs:
	- TODO(RATIFICATION_DATE): confirm original adoption date if older than file creation
	- TODO(COMMANDS_REVIEW): review .specify/templates/commands for agent-specific references

-->

## Core Principles

### I. Domain-First Design (DDD)
All behaviour and data models MUST originate from a clearly defined domain model. The domain layer is the primary source of truth: entities, value objects, aggregates, and domain services
MUST be authored to reflect business intent, not persistence concerns. Domain logic MUST be isolated from infrastructure and presentation layers.

Rationale: Ensures the codebase models business rules explicitly and avoids leaky abstractions that make reasoning and evolution costly.

### II. Clean Architecture (Separation of Concerns)
Code MUST follow Clean Architecture boundaries: Domain (core) → Application (use cases) → Infrastructure (repos, external services) → API/Presentation. Dependencies MUST point inward.
Implementation details (EF Core, messaging, HTTP) are replaceable adapters behind well-defined ports/interfaces.

Rationale: Limits coupling, enables independent evolution, simplifies testing by allowing core logic to be tested without infrastructure.

### III. Test-First & Full Coverage Requirement (NON-NEGOTIABLE)
Unit tests MUST be written for every public behavior and all significant code paths. Tests for edge cases, validation, and error flows are mandatory. For every feature, tests MUST be added first and observed failing (red) before implementation (green).
Code coverage is expected at a high level: aim for 90%+ on domain and application layers; infrastructure may be lower but must still be covered by integration tests.

Rationale: Guarantees designability, prevents regressions, and enforces that business rules are expressed as verifiable behavior.

### IV. Domain Events & Event-Driven Consistency
State changes inside aggregates MUST raise domain events. Events are the canonical notifications for cross-cutting side-effects and eventual consistency across bounded contexts. Domain events MUST be defined in the domain layer; event dispatching MAY be implemented by in-process dispatchers in tests and durable/message-based dispatchers in production.

Rationale: Encourages explicit modeling of side effects, decouples modules, and supports scalable integration patterns (e.g., async processing, sagas).

### V. Explicit Contracts & Observable Telemetry
All external-facing boundaries (HTTP APIs, message schemas, DB formats) MUST have explicit contracts and automated contract tests where applicable. Structured logging, correlation ids, and essential metrics (request latencies, error rates, event publish/consume counts) MUST be recorded.

Rationale: Ensures operability, traceability, and safe releases across services and teams.

## Additional Constraints & Standards

- Technology: .NET (latest LTS recommended, e.g., .NET 8 LTS or current LTS at adoption). C# for implementation. EF Core allowed for repositories but usage MUST be behind repository/port interfaces in the infrastructure layer.
- Datastore: PostgreSQL is the reference relational store. Use migration tooling (EF Core Migrations or Flyway) with versioned schema migrations.
- Messaging: Durable message broker (e.g., RabbitMQ, Kafka, Azure Service Bus) recommended for cross-process domain events; local/in-memory buses allowed for tests.
- Security: Secrets MUST be stored in a secrets manager (Azure Key Vault or equivalent); no secrets in repo. Authentication/authorization MUST be enforced at the API boundary.
- Performance: Target reasonable p95 latencies depending on endpoint SLAs; benchmark goals to be defined per-feature in plan.md.
- Observability: Structured logs (JSON), OpenTelemetry traces and metrics integration are REQUIRED for services in production.

## Development Workflow & Quality Gates

- Branching: Feature branches per task; PR titles MUST reference the spec id and tasks. Commits SHOULD be small and focused.
- Reviews: Every PR that changes domain or application logic MUST have at least one senior reviewer with domain context.
- CI Gates: All PRs MUST pass unit tests, static analysis (e.g., Roslyn analyzers, StyleCop), and a security scan before merge. Integration tests for impacted contracts MUST run in CI for PRs touching infra or contract boundaries.
- Release: Breaking changes to public contracts MUST follow versioning policy (MAJOR bump), include migration notes, and a migration plan.
- Dependency upgrades: Major dependency changes that may affect behavior MUST include a compatibility report and regression test matrix.

## Governance

This constitution is authoritative for engineering decisions in the SDD Hospital back-end project. Deviations require explicit documented justification and a formal amendment.

- Amendment procedure: Proposals for changes are drafted in a PR against `.specify/memory/constitution.md`. A non-trivial amendment (MAJOR or MINOR) requires approval by at least two maintainers and an associated migration plan. Patch edits (typos/clarifications) require one maintainer approval.
- Versioning policy: Use semantic versioning for the constitution itself. Bump rules:
	- MAJOR: Remove or redefine principles or governance in a backward-incompatible way.
	- MINOR: Add new principles or materially expand guidance.
	- PATCH: Clarifications, typo fixes, or non-semantic wording changes.
- Compliance review: Quarterly audits MUST validate that core principles are enforced by code review checklists, CI gates, and a sampling of merged PRs.

**Version**: 1.0.0 | **Ratified**: TODO(RATIFICATION_DATE): confirm | **Last Amended**: 2025-11-02
