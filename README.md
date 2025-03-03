# Jungle - Travel Agency Website

Welcome to the Jungle project! This is a travel agency website built using **ASP.NET**. The platform offers tourist packages and services, allowing users to browse, book, and manage their travel arrangements. The website supports basic CRUD operations, API integration, and caching mechanisms for improved performance.

## Features

- **CRUD Operations:** Basic functionality to create, read, update, and delete tourist packages and customer data.
- **API Integration:** Fetches data from external sources for tourist package details, pricing, and availability.
- **Caching:** Implements caching to enhance website performance and reduce load times.
- **Database Migrations:** Uses **Entity Framework** for database migrations, enabling seamless schema updates.

## Prerequisites

Before running this project, ensure that you have the following installed:

- **.NET SDK** (version 6.0 or higher)
- **SQL Server** or any compatible database server

## Getting Started

Follow the steps below to set up and run the project locally.

### 1. Clone the repository

Start by cloning the project to your local machine:

```bash
git clone https://github.com/yourusername/jungletribe.git
```
### 2. Restore dependencies

Navigate to the project directory and restore the dependencies:

```bash
cd jungle
dotnet restore
```
### 3. Set up the database

Run the following command to apply database migrations and set up the necessary tables:

```bash
dotnet ef database update
```
### 4. Run the application
Once the setup is complete, run the project:

```bash
dotnet run
```
