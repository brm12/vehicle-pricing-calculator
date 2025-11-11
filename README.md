# Vehicle Pricing Calculator

A full-stack application for calculating vehicle pricing with various fees. Built with .NET 8 backend and Vue 3 frontend.

## Features

- Calculate total vehicle pricing including various fees
- Support for different vehicle types (Common, Luxury)
- RESTful API with detailed fee breakdowns
- Modern Vue.js frontend with PrimeVue components
- Clean Architecture implementation

## Quick Start

### Prerequisites

- .NET 8 SDK
- Node.js 18+
- SQL Server LocalDB

### Running the Application

1. **Start the Backend:**
   ```sh
   cd backend/src/VehiclePricingCalculator.API
   dotnet run
   ```
   Backend will run at `https://localhost:7129`

2. **Start the Frontend:**
   ```sh
   cd frontend/VehicleBidCalculator.UI
   npm install
   npm run dev
   ```
   Frontend will run at `http://localhost:5173`

3. **Access the Application:**
   - Frontend: http://localhost:5173
   - Backend API: https://localhost:7129
   - Swagger UI: https://localhost:7129/swagger

The database will be automatically created and seeded on first run.

## Running Tests

**Backend:**
```sh
cd backend
dotnet test
```

**Frontend:**
```sh
cd frontend/VehicleBidCalculator.UI
npm run test:unit
```

## Project Structure

```
VehiclePricingCalculator/
├── backend/
│   ├── src/
│   │   ├── VehiclePricingCalculator.API/          # Web API layer
│   │   ├── VehiclePricingCalculator.Application/  # Application services, business logic & DTOs
│   │   │   ├── ApplicationServices/               # Service interfaces & implementations
│   │   │   ├── BusinessLogic/                     # Core business logic (fee calculations)
│   │   │   ├── Dtos/                              # Data Transfer Objects
│   │   │   └── Validators/                        # FluentValidation validators
│   │   ├── VehiclePricingCalculator.Domain/       # Domain entities & repositories
│   │   └── VehiclePricingCalculator.Infrastructure/ # Data access & external services
│   └── test/
│       └── VehiclePricingCalculator.ApplicationTests/ # Unit tests
└── frontend/
    └── VehicleBidCalculator.UI/              # Vue.js frontend application
```

## API Endpoints

- `GET /api/VehiclePricing/fees` - Get all available fees
- `GET /api/VehiclePricing/vehicleTypes` - Get supported vehicle types  
- `POST /api/VehiclePricing/calculate` - Calculate vehicle price with fees

## Technologies

**Backend:** .NET 8, ASP.NET Core Web API, Entity Framework Core, SQL Server LocalDB, FluentValidation

**Frontend:** Vue 3, TypeScript, Vite, PrimeVue, Axios
