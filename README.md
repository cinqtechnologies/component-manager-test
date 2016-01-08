# Proposed Exercise: #

A company wants to provide a common interface to its customers that would abstract the communication to its physical components installed on a machine.
It was decided to create a WCF service that receives requests from its endpoints, process them, communicate to the components via sockets and return the result of the request.
You are asked to develop the communication to the socket components, the WCF service and a desktop test application to show data received.

## Communication to components ##

Two components are provided with the code, both following a different format for the data stream. Develop a class to request and handle the data for both using sockets.

## WCF service ##

Develop a WCF service to receive a read data request, communicate to the correct component and return the response.

* Add a key to app.config to define which component to use.
* Use Factory pattern to instantiate the component handler.
* Create a self hosted WCF service.
* Use net tcp binding for the service.
* Service interface should be called IComponentManager and declare a method IEnumerable\<PersonalData\> ReadData().
* PersonalData should have four properties: string FirstName, string LastName, string Country, int Age.

## WPF client ##

A WPF client will be provided for testing the service. User clicks on Read Data to call the service and show the result on a ListView.

* A predefined WPF app with a Button and a ListView is provided.
* The proxy class to the WCF service is provided. Don't forget to match Data Contract namespaces.
* Dot not block GUI while communicating to the service, it should be responsive all the time.
* Show LastName and FirstName on ListView, ordered by LastName and only persons older than 16 years old.

### Additional information ###

* Visual Studio 2015
* Use async/await if possible
* Use LINQ when possible.
