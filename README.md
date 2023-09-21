# MassTransitRabitMQ
Sample of using MassTransit in conjunction with RabbitMQ in an ASP.NET Core.

**Please Note:** This application is intentionally designed as a simplified example for learning purposes. 
It does not adhere to best practices that you would typically use in a production application. 
Instead, it focuses on clarity and ease of understanding to help developers grasp the fundamentals of MassTransit and RabbitMQ.

## Prerequisites
Before you begin, make sure you have Docker installed on your machine. You can check if Docker is installed by running: `docker --version`. 
If Docker is not installed, you can download and install it from [Docker's official website](https://www.docker.com/get-started).

Ensure you have the .NET 7 SDK installed on your machine to build and run your .NET applications: `dotnet --version`.

## Quick Start with Docker Compose
To build and run your application using Docker Compose with environment variables, follow these steps:

1. Open a terminal in the solution folder `...\MassTransitRabitMQ`.

2. Build the Docker containers: 
```
docker-compose -f docker-compose.yml --env-file .env.development build
```

3. Start the containers:
```
docker-compose -f docker-compose.yml --env-file .env.development up
```

4. To stop and remove the containers when you're done, use the following command:
```
docker-compose down --rmi all
```

## Accessing the Apps
Once your applications are running, you can access them through Swagger or Postman:

### TipsAPI:
- **Swagger:** Open your web browser and go to [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html) to interact with the TipsAPI using Swagger's user-friendly interface.
- **Postman:** If you prefer using Postman, you can make API requests to [http://localhost:5000](http://localhost:5000) with the appropriate endpoints.

### ReportingAPI:
- **Swagger:** Open your web browser and go to [http://localhost:6000/swagger/index.html](http://localhost:6000/swagger/index.html) to interact with the ReportingAPI using Swagger's user-friendly interface.
- **Postman:** If you prefer using Postman, you can make API requests to [http://localhost:6000](http://localhost:6000) with the appropriate endpoints.
