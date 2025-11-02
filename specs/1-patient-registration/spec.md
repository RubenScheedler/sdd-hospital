# Feature Specification: Patient Registration

**Feature Branch**: `1-patient-registration`  
**Created**: 2025-11-02  
**Status**: Draft  
**Input**: User description: "The system should allow registration of patients. A patient should be assigned a unique patient ID and the following information of patient should be known and saved in the system: name, age, email address, phone number."

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Register patient (Priority: P1)

As an administrative user, I want to register a new patient so that the patient has a unique identifier and their contact and demographic information is stored.

**Why this priority**: Core system capability; other features (appointments, records) depend on a registered patient record.

**Independent Test**: An automated end-to-end test that posts the registration payload and verifies a 201 response with a patient id, and that a follow-up query returns the saved patient record with all provided fields.

**Acceptance Scenarios**:

1. **Given** an authenticated admin user, **When** they submit a valid registration payload, **Then** the system returns 201 Created with a unique patientId and the patient record is persisted.
2. **Given** a registration payload missing required fields (name or age), **When** submission occurs, **Then** the system returns 400 Bad Request with a validation error detailing missing fields.
3. **Given** a registration payload with an invalid email format, **When** submission occurs, **Then** the system returns 422 Unprocessable Entity with validation details.
4. **Given** the same email or phone exists for another record, **When** submission occurs, **Then** the system allows creation (201) and the new record is flagged for later deduplication/reconciliation; an audit entry or domain event is recorded to support reconciliation.

---

### Edge Cases

- Name containing non-ASCII characters; system MUST accept UTF-8 names.
- Age as boundary values (0, 120); validation rules MUST be explicit in requirements.
- Phone numbers with country codes; normalization policy MUST be defined in assumptions.

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: System MUST allow creation of patient records with the following fields: patientId (system-generated, unique), name, age, email, phone.
- **FR-002**: patientId MUST be a stable unique identifier (UUID or similar) assigned by the system at creation.
- **FR-003**: System MUST validate input: name non-empty, age integer between 0 and 120, email syntactically valid, phone matches configured normalization rule.
- **FR-004**: System MUST persist patient records in the canonical domain repository and expose a read endpoint to fetch patient by patientId.
- **FR-005**: System MUST emit a PatientRegistered domain event when a patient is successfully created. The event MUST include patientId, timestamp, and minimal contact fields (email, phone) to allow other bounded contexts to react.
- **FR-006**: System MUST prevent leaking secrets; no PII logs in plain text for production environments. Logging of contact fields MUST be redacted unless explicitly allowed for debugging with guardrails.

**Testing Requirement (mandatory)**: Each functional requirement must map to automated tests. Unit tests MUST cover domain validations and event raising. Integration tests MUST cover persistence and API contract behavior. Tests are written first and expected to fail before implementation.

## Key Entities *(include if feature involves data)*

- **Patient (Aggregate Root)**: Represents the patient entity and encapsulates validation rules and invariants.
  - Attributes: patientId (UUID), name (string), age (int), email (string), phone (string)
  - Behaviors: create/register (factory method) which enforces invariants and raises PatientRegistered event.

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: Registering a valid patient succeeds 100% of the time in CI tests (unit + integration) for the feature branch.
- **SC-002**: 90%+ of domain and application code paths covered by unit tests (coverage measured in CI).
- **SC-003**: Validation failures produce appropriate HTTP error codes and machine-readable error payloads.
- **SC-004**: PatientRegistered domain event is published (or enqueued) for every successfully created patient in integration tests.

## Assumptions

- Authentication/authorization is already available at the API boundary; tests will use a test token or bypass mechanism for simplicity.
- patientId format: UUID v4 unless otherwise specified.
- Phone normalization will use E.164 where possible; tests will validate normalization behavior for at least one example country code.

---

**Ready for planning**: YES

## Clarifications

### Session 2025-11-02

- Q: Who may register patients? → A: No authentication for now
- Q: Uniqueness enforcement? → A: Do not enforce uniqueness at creation
