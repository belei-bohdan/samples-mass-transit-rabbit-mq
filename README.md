# MassTransitRabitMQ
Sample of using MassTransit in conjunction with RabbitMQ in an ASP.NET Core.

## Prerequisites
Before you begin, make sure you have Docker installed on your machine. You can check if Docker is installed by running: `docker --version`. 
If Docker is not installed, you can download and install it from [Docker's official website](https://www.docker.com/get-started).

Ensure you have the .NET 7 SDK installed on your machine to build and run your .NET applications: `dotnet --version`.

## Quick Start with Docker Compose
To build and run your application using Docker Compose with environment variables, follow these steps:
1. Build the Docker containers: 
```
docker-compose -f docker-compose.yml --env-file .env.development build
```

2. Start the containers:
```
docker-compose -f docker-compose.yml --env-file .env.development up
```

3. To stop and remove the containers when you're done, use the following command:
```
docker-compose down --rmi all
```

## Accessing the App
Once your application is running, you can access it through Swagger or Postman:
- **Swagger:** Open your web browser and go to [http://localhost/swagger/index.html](http://localhost/swagger/index.html) to interact with the API using Swagger's user-friendly interface.
- **Postman:** If you prefer using Postman, you can make API requests to [http://localhost](http://localhost) with the appropriate endpoints.
