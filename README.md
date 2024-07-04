dto
dto is an object that carries data between processes 
Example: let's go back to our client and the catalog service when the client needs to retrieve the 
details for a specific item it will send a get request to the service with the item id 
and the service will in turn return the item details this payload returned by the service is 
what we call the dto the dto represents the contract between the microservice and the client 
we'll define this contract has significant implications imagine what would happen if we decide 
to rename the price to item price our clients would break and they would 
need to get updated right away to ensure no disruption to our customers 
as a general rule you need to think carefully about each of your details to ensure you minimize the need to update 
them later as much as possible it's time to define the res api for 

Record types:
we will use record types for dtos as opposed to classes basically because they are simpler to declare 
they provide value based equality which means that when comparing two of the items then we will consider equal if all 
their properties have the same value which is not the case with classes they are immutable by default meaning 
that modifications after creation are not allowed and they have a built in to a string 
overwrite that shows the names and values of all the record properties

Controller:
in order to add our api operations we will need to introduce a controller specifically a web api controller 
the controller groups the set of actions that can handle the api requests including the routes authorization and a 
series of other rules usually needed in rest apis

Adding database storage:
Repository:
a repository is an abstraction between the data layer and the business layer of an application 
to understand why you may want to use a repository let's say that today we have the application logic of our service 
talking directly to our mongodb database however a few months or years from now 
requirements change and we need to switch to a different database provider 
given the way that things have been set up we would likely need to rewrite a good chunk of our application logic in 
order to talk to the new database which is pretty bad 
instead what we can do is introduce a repository this repository is the only one that 
knows how to talk initially to our mongodb database and is the only one that our application logic will 
interface with then if we ever get the requirement to move to another database the only thing 
that we would need to change is our repository but the application logic stays the same 
so the repository pattern is important because it decouples the application logic from the data layer 
and minimizes duplicate data access logic across our service 
![image](https://github.com/pnucmcs/C-Sharp-Microservices/assets/111470850/3a9c3d8a-65fd-4e65-bade-6b395b31568e)

Mongodb:
we will be using mongodb as our database of choice for all the microservices in this course 
mongodb is a document-oriented non-sql database which stores data in a json-like documents with dynamic schema 
we will prefer a non-sql solution as opposed to a relational database for microservices because 
we won't need relationships across the data because each microservice manages its own database 
we don't need acid guarantees where acid stands for atomicity consistency 
isolation and durability which are properties of database transactions that we don't need in our services 
we won't need to write complex queries since most of our service queries will be able to find everything they need in 
a single document type and we need low latency high availability and high scalability which 
are classic features of nosql databases let's go ahead and implement our items 
repository before implementing a repository we will need to decide which is going to be the 
class that represents the objects that will be managed by the repository and that will make their way into our 
database the classes we use for this should not be confused with our details because we want to have the freedom of updating how 
we store the items in the database at any given point regardless of the contract that we'll need to honor with 
our service clients we will then give the name of entities to the classes that are repository use 
![image](https://github.com/pnucmcs/C-Sharp-Microservices/assets/111470850/47a0fe99-a3ae-4da4-9735-695b107b3c96)


Dependency injection:

