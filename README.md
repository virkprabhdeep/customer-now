The API functionalities are as follows: 

GET /api/tickets → Fetches all tickets.
POST /api/tickets → Submits a new ticket.
GET /api/tickets/{id} → Retrieves a single ticket by ID.
PUT /api/tickets/{id} → Updates an existing ticket.
PUT /api/tickets/{id}/status → Updates only the ticket status.
DELETE /api/tickets/{id} → Deletes a ticket.

It uses EF Core code first approach so just running update-database will update the localhost DB with the tables.
