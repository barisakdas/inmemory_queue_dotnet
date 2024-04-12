# IN MEMORY QUEUE .NET 8.0

This project is designed to perform data processing and reporting operations using an in-memory queue system within the .NET environment. 
Data is added to the Channel following relevant triggers and subsequently consumed to be processed.
The consumed data is first transformed into Excel files with the help of the ClosedXml library, and finally, the completion of this process is communicated to the client side via SignalR.

## Layers
The project consists of 6 layers in total.
* API Layer: The API layer is designed with the .NET 8.0 framework to expose services and methods inside the project through Swagger, allowing us to perform operations without a frontend.
* Web Layer: The Web layer is designed using visual components with the help of the MVC design pattern on the .NET 8.0 framework, enabling the end-user to see lists and buttons on the screen.
* Core Layer: This layer contains core operations such as entities, DTOs, and mappers.
* Application Layer: It includes services and tools that will perform CRUD operations for entities prepared in the Core layer.
* Background Layer: The Background layer is prepared to operate in the background according to requests from the edges or clients and manage processes such as creating Excel files, sending real-time messages to clients, and queue management.
* SignalR Layer: This layer manages communication structures (Hub, etc.) within the project.

## Technologies
The following technologies have been used in this project:
* .NET 8.0
* .NET In-Memory Queue Structure (System.Threading.Channels)
* Real-Time Communication (Microsoft.AspNetCore.SignalR.Core)
* File Management (Microsoft.Extensions.FileProviders)
* Excel Operations (ClosedXML.Excel)
* Web Project (Microsoft.AspNetCore.Mvc)
* Bootstrap

## Features
- **Channel API**: Asynchronously sending data to the queue system.
- **ClosedXML**: Creating Excel reports using data read from the queue.
- **SignalR**: Sending notifications to the client via a toast component upon completion of operations.

## How It Works?

1. **Data Submission**: The application sends data to the queue system via the Channel API.
2. **Data Processing**: Data is read from the queue and processed.
3. **Excel Report Creation**: Excel reports are created using ClosedXML with the data read.
4. **Notification Sending**: SignalR is used to send a toast notification to the client indicating that the operation has been completed.

## Installation

Follow these steps to run the project in your local environment:
The project can be started from both the API layer and the Web layer. 
It is important to select the startup project before the project starts. All configs and settings are designed separately for both projects, so there is no dependency.

```bash
git clone https://github.com/your-repository/inmemory_queue_dotnet.git
cd inmemory_queue_dotnet
dotnet restore
dotnet build
dotnet run
```

This README file explains the fundamental components of your project and how it operates. It also outlines how to set up and run the project, as well as guidelines for contributing. You will need to update specific details for your project, such as your GitHub repository URL and license information.