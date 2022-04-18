# Saga Choreography Implementation with .NET 6 

<br/>

This is a simple Saga Choreography implementation with Order, Stock and Payment API. 

## Technologies

* [ASP.NET Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [MediatR](https://github.com/jbogard/MediatR)
* [Docker](https://www.docker.com/)


##Create a rabbitmq container on your local
docker container run -d --name some-rabbit -p 4369:4369 -p 5671:5671 -p 5672:5672 -p 25672:25672 -p 15671:15671 -p 8080:15672 rabbitmq:3-management
