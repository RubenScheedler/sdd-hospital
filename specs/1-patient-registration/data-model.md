# Data Model: Patient

## Entity: Patient
- **Id** (Guid, required, unique)
- **FirstName** (string, required)
- **LastName** (string, required)
- **DateOfBirth** (DateTime, required)
- **Email** (string, optional)
- **PhoneNumber** (string, optional)
- **CreatedAt** (DateTime, required, set by system)

## Relationships
- None for initial implementation

## Validation Rules
- FirstName, LastName, DateOfBirth are required
- Email, if provided, must be valid format
- PhoneNumber, if provided, must be valid format

## State Transitions
- On registration: Patient is created and persisted
- Domain event: PatientRegisteredEvent is published
