# AdventureWorks API

This is a .NET 9 API application using the AdventureWorks database. The API provides endpoints to interact with the `Products` table, allowing basic CRUD operations (Create, Read, Update, Delete). It is containerized with Docker and includes a local SQL Server database for development purposes.

## Features

- **Products API**:
  - Get all products
  - Get a single product by ID
  - Create a new product
  - Update an existing product
  - Delete a product

- **Swagger Documentation**:
  - Automatically generated API documentation, accessible at the root URL when running in development.

## Prerequisites

- Docker and Docker Compose installed on your machine.
- .NET SDK 9.0 installed if running outside Docker.

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/JPEGenzyme/enzo.git
cd enzo
```

### 2. Set Up the Environment

Ensure that docker-compose.yml is correctly configured. The SQL Server password and database connection string are defined in environment variables.

### 3. Build and Run the Application
Use Docker Compose to build and run the containers:

```bash
docker-compose up --build
```
This will:

- Start a SQL Server container with the AdventureWorks database.
- Build and run the API container.
### 4. Access the API
Once the containers are running:

- Swagger documentation is available at http://localhost:8080.
- You can test the API endpoints directly using the Swagger UI or tools like Postman.

API Endpoints
- GET /api/products: Retrieve all products.
- GET /api/products/{id}: Retrieve a product by ID.
- POST /api/products: Create a new product.
- PUT /api/products/{id}: Update an existing product.
- DELETE /api/products/{id}: Delete a product.


