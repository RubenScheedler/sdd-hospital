# Prompt History
Create a constitution for .NET back-end application that uses DDD, clean architecture and domain events. Unit tests should be written for alle features and code paths.

The system should allow registration of patients. A patient should be assigned a unique patient ID and the following information of patient should be known and saved in the system: name, age, email address, phone number.

Follow instructions in speckit.plan.prompt.md. After that, fill the plan to furfill these requirements: General project setup that needs to happen first: Create a solution with .NET 9 and make sure it can be run with Aspire. Make sure to add scaffolding for clean architecture in the solution. Set up a REST API in the appropriate place in clean architecture. Add Swagger so that the API can be viewed from the browser.
For this feature (register patients): Create a REST endpoint, let it call a use case (passing a command). The use case should create the patient (and save it in the database) and publish a domain event. 
**Note**: It did not follow instructions the first time and started generating code.

Execute phase 0, 1, 2.

**Note**: Really problematic if you are switched to the correct branch automatically.