```markdown
# Implementation Tasks: Patient Registration

**Feature**: Patient Registration
**Branch**: `[feature-patient-registration]`
**Spec**: spec.md

## Phase 1: Setup
 - [X] T001 Initialize solution projects and verify build (create solution and ensure src projects compile) - repo root
 - [X] T002 Add EF Core and PostgreSQL provider to Infrastructure project (`src/SDD.Hospital.Infrastructure/`) - csproj
 - [X] T003 Add xUnit test projects for Domain and Application (`tests/SDD.Hospital.Domain.Tests`, `tests/SDD.Hospital.Application.Tests`) - repo root
 - [X] T004 Add Swashbuckle (Swagger) to API project (`src/SDD.Hospital.Api/Program.cs`) - API project
 - [X] T005 Configure local dev PostgreSQL connection and migrations scaffolding (`src/SDD.Hospital.Infrastructure/`) - Infrastructure

- [ ] T006 [P] Create Patient entity in Domain (`src/SDD.Hospital.Domain/Models/Patient.cs`) - [P]
- [ ] T007 [P] Add PatientRegisteredEvent in Domain (`src/SDD.Hospital.Domain/Events/PatientRegisteredEvent.cs`) - [P]
- [ ] T008 Implement IPatientRepository port (`src/SDD.Hospital.Application/Ports/IPatientRepository.cs`) - Application
- [ ] T009 Implement ConsoleDomainEventPublisher for local testing (`src/SDD.Hospital.Infrastructure/Events/ConsoleDomainEventPublisher.cs`) - Infrastructure

## Phase 3: User Story 1 - Register patient (Priority: P1) 🎯 MVP

Independent test: POST `/api/patients` with valid payload returns 201 and patient persisted; follow-up GET `/api/patients/{id}` returns same record.

- [ ] T010 [US1] Add RegisterPatientCommand and handler in Application (`src/SDD.Hospital.Application/Commands/RegisterPatientCommand.cs`) - Application
- [ ] T011 [US1] Implement RegisterPatientUseCase wiring with MediatR or application layer (`src/SDD.Hospital.Application/UseCases/RegisterPatientUseCase.cs`) - Application
- [ ] T012 [US1] Add EF Core PatientRepository implementation (`src/SDD.Hospital.Infrastructure/Repositories/PatientRepository.cs`) - Infrastructure
- [ ] T013 [US1] Create API controller endpoint POST `/api/patients` (`src/SDD.Hospital.Api/Controllers/PatientsController.cs`) - API
- [ ] T014 [US1] Create mapping between request DTO and domain model (`src/SDD.Hospital.Api/Models/RegisterPatientRequest.cs`) - API
- [ ] T015 [US1] Add domain validation tests for Patient creation (`tests/SDD.Hospital.Domain.Tests/PatientTests.cs`) - tests
- [ ] T016 [US1] Add integration test for registration endpoint (`tests/SDD.Hospital.Api.IntegrationTests/RegisterPatientTests.cs`) - tests
- [ ] T017 [US1] Ensure PatientRegisteredEvent is published when registration succeeds (`src/SDD.Hospital.Application/`) - Application
- [ ] T018 [US1] Add logging and OpenTelemetry tracing around registration flow (`src/SDD.Hospital.Api/`, `src/SDD.Hospital.Application/`) - cross-cutting

## Final Phase: Polish & Cross-Cutting Concerns
- [ ] T019 Add input validation and error handling middleware (`src/SDD.Hospital.Api/`) - API
- [ ] T020 Update Swagger/OpenAPI with request/response schemas (`src/SDD.Hospital.Api/`) - API
- [ ] T021 Add CI job to run unit and integration tests and measure coverage (`.github/workflows/`) - CI
- [ ] T022 Add README snippet in `specs/1-patient-registration/quickstart.md` showing how to run integration tests locally - docs

## Dependencies & Execution Order
- Phase 1 -> Phase 2 -> Phase 3 -> Final Phase

## Summary
- Total tasks: 22
- Tasks for US1: 9 (T010 - T018)
- Parallel opportunities: T006, T007, T008, T009 flagged [P]
- Suggested MVP: Complete Phase 1 through T013 (endpoint + persistence + event) to deliver minimal usable registration

``` 
