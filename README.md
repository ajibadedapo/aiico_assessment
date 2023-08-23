# aiico_assessment

# Parking Lot Management System

This repository contains a parking lot management system implemented in C# and .NET Core 6. The system allows you to simulate parking vehicles in different locations, calculate fees, and manage available spots.


## Features

- Park and unpark vehicles in different locations (Mall, Stadium, Airport)
- Calculate fees based on various fee models
- Manage available parking spots by location and vehicle type

## Getting Started

### Prerequisites

- .NET Core 6 SDK
- Git (for cloning the repository)

Use API endpoints to park and unpark vehicles, calculate fees, and manage available spots.

## API Endpoints

- POST `/api/parking/park-vehicle`: Park a vehicle.
- POST `/api/parking/unpark-vehicle/{ticketNumber}`: Unpark a vehicle by ticket number.
- POST `/api/parking/add-spot`: Add a new parking spot.


## collection

https://www.postman.com/blue-shuttle-138271/workspace/public/collection/7445710-0ee46c33-9d5d-46d8-ae1a-51ac6e1b0b60?action=share&creator=7445710


##Deployment

The application is deployed to render.com utilizing Docker. It is containerized using Docker to ensure consistency across different environments. The deployment process involves creating a Docker image, pushing it to a container registry, and then deploying it to render.com.

