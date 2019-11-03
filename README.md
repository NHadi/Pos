# POS - DDD, Reactive Microservices, CQRS Event Sourcing Powered by DERMAYON LIBRARY
Sample Application DDD Reactive Microservices with CQRS & Event Sourcing with [DERMAYON LIBRARY](https://github.com/NHadi/Dermayon). 

# Architectures
![Image of Architecture](https://github.com/NHadi/Pos/blob/master/images/architecture.png)

# Features
1. Microservices 
2. CQRS (Command Query Responsibility Segregation)
3. Event Sourcing
4. Generic Repository 
5. UnitOfWork
6. Domain Driven Design
7. Api Gateway [Ocelot](https://ocelot.readthedocs.io/en/latest/introduction/gettingstarted.html)
8. Multiple Databases type [MongoDb, SqlServer, etc]
9. Message Broker [Kafka]

# Information
![Image of DDD](https://github.com/NHadi/Pos/blob/master/images/ddd.png)

1. Domain Layer : Main of Application like Event, Repository, etc
2. Infrastructure Layer : Dataabases, Files, etc
3. Application Layer : WebApi, etc

# Main Architecture
![Image of mainarchitecture](https://github.com/NHadi/Pos/blob/master/images/mainarchitecture.png)

Microservices - also known as the microservice architecture - is an architectural style that structures an application as a collection of services that are

1. Highly maintainable and testable
2. Loosely coupled
3. Independently deployable
4. Organized around business capabilities
5. Owned by a small team

The microservice architecture enables the rapid, frequent and reliable delivery of large, complex applications. It also enables an organization to evolve its technology stack. [reference](https://microservices.io/)


# API Gateway
![Image of gateway](https://github.com/NHadi/Pos/blob/master/images/gateway.jpg)

The API Gateway encapsulates the internal system architecture and provides an API that is tailored to each client. It might have other responsibilities such as authentication, monitoring, load balancing, caching,

# CQRS Event Sourcing
![Image of cqrss](https://github.com/NHadi/Pos/blob/master/images/cqrss.png)

CQRS stands for Command Query Responsibility Segregation. It's a pattern that I first heard described by Greg Young. At its heart is the notion that you can use a different model to update information than the model you use to read information. For some situations, this separation can be valuable, but beware that for most systems CQRS adds risky complexity.

Benefits when to use CQRS Event Sourcing
![Image of cqrsmaterialized](https://github.com/NHadi/Pos/blob/master/images/cqrsmaterialized.png)

imagine if the system is too complex and more than 1K user hit in server, how many related tables? and how long does it take to get data? with cqrs & event sourcing we can implement materialized views, or in other words denormalized tables into one data or flat

# Reactive Services, Reactive Manifesto, and Microservices 
![Image of reactive](https://github.com/NHadi/Pos/blob/master/images/reactive.png)

The Reactive Manifesto outlines qualities of Reactive Systems based on four principles: Responsive, Resilient, Elastic and Message Driven. 

1. Responsiveness means the service should respond in a timely manner.
2. Resilience goes in line with responsiveness, the system should respond even in the face of failure.
3. Elasticity works with resilience. The ability to spin up new services and for downstream and upstream services and clients to find the new instances is vital to both the resilience of the system as well as the elasticity of the system.  
4. Message Driven: Reactive Systems rely on asynchronous message passing. This established boundaries between services (in-proc and out of proc) which allows for loose coupling (publish/subscribe or async streams or async calls), isolation (one failure does not ripple through to upstream services and clients), and improved responsive error handling.

## Get started

**Clone the repository**

**Run and Build the app**

```sh
cd Pos 
docker-compose up
```


