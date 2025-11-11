# Vehicle Pricing Calculator - Frontend

A modern Vue 3 + TypeScript frontend application for calculating vehicle pricing with detailed fee breakdowns. Built with Vite and PrimeVue components.

## Features

- Real-time vehicle price calculation with fee breakdown
- Support for multiple vehicle types (Common, Luxury)
- Form validation with error handling
- Responsive design using PrimeVue UI components
- Calculation history with localStorage persistence
- Toast notifications for user feedback

## Tech Stack

- **Vue 3** with Composition API
- **TypeScript** for type safety
- **Vite** for fast development and building
- **PrimeVue** for UI components
- **Axios** for HTTP requests
- **Vue Router** for navigation
- **Vitest** for unit testing

## Project Setup

### Prerequisites

- Node.js (version 18 or later)
- npm or yarn

### Install Dependencies

```sh
npm install
```

### Environment Configuration

Create a `.env.development` file or update the existing one:

```env
VITE_API_BASE_URL=https://localhost:7129/api
```

### Development Server

Start the development server with hot-reload:

```sh
npm run dev
```

The application will be available at `http://localhost:5173`

### Type-Check, Compile and Minify for Production

```sh
npm run build
```

### Preview Production Build

```sh
npm run preview
```

### Run Unit Tests

```sh
npm run test:unit
```

### Lint with ESLint

```sh
npm run lint
```

## Project Structure

```
src/
├── assets/           # Static assets (CSS, images)
├── components/       # Vue components
│   └── VehiclePricingForm.vue    # Main pricing calculator component
├── composables/      # Composition API logic
│   └── useVehiclePricingForm.ts  # Pricing form logic & state
├── router/           # Vue Router configuration
└── types/            # TypeScript type definitions
```

