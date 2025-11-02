# Implementation Plan: Patient Registration

**Branch**: `[feature-patient-registration]` | **Date**: 2025-11-02 | **Spec**: /specs/1-patient-registration/spec.md
**Input**: Feature specification from `/specs/1-patient-registration/spec.md`

## Summary

Implement patient registration: expose a REST endpoint to register a patient, call a use case (passing a command), persist the patient in the database, and publish a domain event. Project uses .NET 9, Aspire, Clean Architecture, and Swagger for API documentation.

## Technical Context

**Language/Version**: .NET 9 (latest preview)
**Primary Dependencies**: EF Core, MediatR (or custom CQRS), OpenTelemetry, Swashbuckle (Swagger), xUnit
**Storage**: PostgreSQL (via EF Core, migrations enabled)
**Testing**: xUnit, test-first approach, unit tests for domain/application, integration tests for infra/contracts
**Target Platform**: Linux containers (Aspire), local dev on Windows
**Project Type**: Backend, DDD, Clean Architecture
**Performance Goals**: p95 < 200ms for registration endpoint
**Constraints**: Constitution: domain-first, clean-architecture, domain events for cross-cutting changes
**Scale/Scope**: Single endpoint, extensible for future features

## Constitution Check

- Domain model: Patient entity in Domain layer
- Aggregates: Patient
- Domain events: PatientRegisteredEvent (Domain layer)
- Infrastructure: PatientRepository, DomainEventPublisher
- Testing: Unit tests for Patient, RegisterPatientUseCase; integration test for endpoint
- Observability: Structured logging, OpenTelemetry traces, metrics for registration
- No breaking contract changes (new endpoint)

## Project Structure

### Documentation (this feature)
specs/1-patient-registration/
├── plan.md              # This file (/speckit.plan command output)
├── research.md          # Phase 0 output (/speckit.plan command)
├── data-model.md        # Phase 1 output (/speckit.plan command)
├── quickstart.md        # Phase 1 output (/speckit.plan command)
├── contracts/           # Phase 1 output (/speckit.plan command)
└── tasks.md             # Phase 2 output (/speckit.tasks command - NOT created by /speckit.plan)

### Source Code (repository root)
src/
├── SDD.Hospital.Api/            # REST API, controllers, Swagger
├── SDD.Hospital.Application/    # Use cases, commands, ports
├── SDD.Hospital.Domain/         # Entities, events
├── SDD.Hospital.Infrastructure/ # Repositories, event publisher, EF Core

**Structure Decision**: Clean architecture, 4-project split (API, Application, Domain, Infrastructure) as implemented in repo

## Complexity Tracking

| Violation | Why Needed | Simpler Alternative Rejected Because |
|-----------|------------|-------------------------------------|
| None      |            |                                     |
