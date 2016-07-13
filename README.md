[![Build Status](https://travis-ci.org/MihaiTheCoder/BehavioralPatterns.svg?branch=master)](https://travis-ci.org/MihaiTheCoder/BehavioralPatterns)

BehavioralPatterns
==================
Behavioral Patterns is a .NET core solution that shows some ways to implement the behavioral patterns described by the Gang of Four.
Patterns described:
1. Chain of responssibility
---------------------------
Implemented in project: ChainOfResponsibility
### a. Pattern description:
Decouples sender and receiver (as a sender you don't know who will handle the request/ as a receiver you don't know who the sender is necessary)
### b.When using the Chain of Responsibility is more effective:
* More than one object can handle a command
* The handler is not known in advance
* The handler should be determined automatically
* It�s wished that the request is addressed to a group of objects without explicitly specifying its receiver
* The group of objects that may handle the command must be specified in a dynamic way.
* Examples in real life:
	* -java.util.logging.Logger.#log()
	* -javax.servlet.Filter#doFilter()
	* -Spring Security Filter Chain

### c. Actors
* Client - creates the chain, and invokes the first handler
* Handler - defines an interface for handling the requests, optional to set the succesor
* Concrete Handler - handles requests it is responsible for, may request the successor to process the request if needed

### d. Pitfalls:
Handling/Handler guarantee - you won't be sure that someone can process the request
Runtime configuration risk - the order matters/and it might be that the chain is not configured correctly
Chain length/performance issues - in theory you could see a chain that is too big, and it would be a bottleneck in performance
### e. Flavors:

1. Execute first that matches the condition and exit -> Get one to process the request, or get the type of object
2. Execute all elements of chain until the condition does not match -> Execute all validators until one invalidates the request
3. Always execute all handlers
4. Tree of responssibility -> Instead of each handler, having a successor, you could have each handler have a list of successors, and have it's policy what handlers to execute

### f. Examples described:
* Purchase example: 
Starting class: PurchaseExample.CheckAuthority

Problem that we are trying to solve:

CheckAuthority allows an employee to request money for approval:
 if(manager can approve it) manager will process the request. If (director can approve it) director will process the request. 
 If (vice president can approve it) vice president will process the request.  If (president can approve it) president will process the request.

* Transfer File example 
Starting class: TransferFileExample.TransferFilesManager

TransferFilesManager will try to transfer the file to the destination by trying FTP, SFTP, Http, and simple file copy and it will decide which to use depending on the prefix of the path

* Poker example: 
Starting class: PokerGame

Having 5 poker cards, decide what is the highest hand that you have

* Business logic validators
Starting class: Validators.UserEntities.UserProcessor

Allow the client through a console menu to introduce what operation wants to execute: Authenticate/CreateUser and foreach option have some validations.
For Create user: verify if the authenticated user is authorised to create a new user, and that the email is not already in the database
	* For authentication: we validate that the user exists in the database
	* Both the menu options and the validations for the operations are done using chain of responssibility


2. Command pattern
------------------
### Pattern description
Command pattern is a behavioral design pattern in which an object is used to encapsulate 
all information needed to perform an action or trigger an event at a later time

### b. When using Command pattern is more effective

1. Macro recording: all user actions are represented by command objects, a program can record a 
sequence of actions simply by keeping a list of the command objects as they are executed.
2. Undo - you want simple undo functionality
3. GUI buttons and menu items - You might set on each button/menu item an action that should be executed in case the button/menu item is pressed
4. Parallel processing - you want to allow commands to be processed in parallel
5. Transactional behavior - In case something fail, you want to be able to rollback the command

### c. Actors

* Client: class that is making use of the command pattern, the one that uses the invoker, makes instance of commands, and passes the commands to the invoker
* Invoker: Invokes the command (calls execute on the command)
* Receiver: the class that the command is using as an implementation
* Command interface: the interface for the commmands
* Concrete Command: Concrete implementations of the command interface

### d. Pitfalls:

* Dependence on other patterns
* Multiple commands having the same implementation
* You need a class for each operation that you are doing, it will increase a lot the number of classes

### e. Flavors:

* Where the command records the commands
* With undo functionality, command offers undo option, and the invoker by remembering the option might undo: 
While it is true that it would be easy using Command pattern to implement at the invoker 
level undo/redo functionality, in practice this only works for simple examples, 
where all entities are at the same level. More details about undo can be seen at: 
http://gernotklingler.com/blog/implementing-undoredo-with-the-command-pattern/

### f. Examples
Stock application example: Starting class: StocksExample.StockExampleRunner

Buy or sell a stock on the market.
If the market is closed save the orders for when the market opens again.
When the market opens place all the orders.
Also, we decided to keep the last ten placed bets, but we don't use them in the example

3. Iterator pattern
------------------
### a. Pattern description

In object-oriented programming, the iterator pattern is a design pattern in which an iterator 
is used to traverse a container(Aggregate) and access the container's(Aggregate's) elements.
C# interfaces helpers for Iterator pattern: IEnumerator<T>, IEnumerable<T>, yield for creating IEnumerable<T>
Java: Iterator<E>, Iterable<E>
Some use the term container, some use the term aggregate, is one and the same thing. From now, we will use only the aggregate term.

### b. When to use Iterator pattern

 When you want to just parse over some data without bothering how to parse it
* Read a csv record by record
* Process elements from a rest API using pagination, hide the pagination using the iterator pattern
* When you have a complex structure like a tree, and you want to process some of the nodes, you can hide the parsing using the iterator pattern

### c. Actors

* Iterator: interface with hasNext/next/current methods or variantions from this
* Concrete interator: concrete class that implements Iterator
* Aggregate: interface for returning the iterator
* Concrete aggregate: imlpementation of aggregate interface

### d. Pitfalls

 * Parsing the same collection multiple times -> because most programming languages hide the usage of iterators

### e. Flavors
 * External iterators -> Iteration is controlled by the client, not by the aggregate. (Only this flavor is exemplified)
 * Internal iterators -> Iteration is controlled by the aggregate, if requested I will add later an example.

### f. Examples

* TV example 1: Starting class: TVExample.TVIterator.TvIteratorExample
	* Functionality: Having a TV, go trhough it's channels
	* Implemented using the standard iterator pattern, without the use of IEnumerable
* TV example 2: Starting class: TVExample.TVEnumerable.TVEnumerableExample
	* Functionality: Having a TV, go trhough it's channels
	* implemented using the IEnumerator<T> and IEnumerable<T> interfaces that are provided by C#
* File example: Starting class FileExample.ReadBigFilesExample
	* Having a list of files, some bigger than other, get the files that have content
	* Created IEnmuerator using yield return


4. Mediator pattern
------------------

### a. Pattern description
With the mediator pattern, communication between objects is encapsulated with a mediator object. 
Objects no longer communicate directly with each other, but instead communicate through the mediator. 
This reduces the dependencies between communicating objects, thereby lowering the coupling.

### b. When to use Mediator pattern
* A collection of interacting objects whose interaction needs simplification
* When you need to monitor/audit the communication between objects
* When building UI components -> High level components mediate the communication between subcomponents
* When you want to do publish/subscribe -> publish subscribe is a pattern implemented using mediator

### c. Actors
* Mediator: interface of the mediator, that defines what messages does it mediate between colleagues.
* Concrete Mediator: implementation of the interface
* Colleague: objects that communicate through the mediator

### d. Pitfalls
* Mediator can become ver complicated as more colleagues are handled.

### e. Flavors
* Don't know

### f. Examples
* StockExchange example: Starting class: StockExchange.StockExchangeExample
	* Have multiple traders Buy/Sell actions from stock exchange (simplified)
* Ground-Air traffic control example: Starting class: GroupAirTrafficControl.GroundAirTrafficControlExample
	* Have 4 planes that want to land on an airport, the airport has 4 lines (one not working). 
	They all talk to air traffic control(mediator) to ask permission to land, instead of talking to each other
* Air traffic control example: Starting class: FlightAirTrafficControl.FlightAirTrafficControlExample
	* Have multiple planes flying in the same zone, at different attitudes, instead of having them communicating to each other, 
	they all comunicate to the tower, and the tower tells them if they need to change the altitude
* Many to many relationship in code: No running class, only the models: User-UserToGroup-Group
* Other possible examples that are not yet implemented -> Chat application, GUI Library, Taxi/Taxi Center


5. Memento pattern
------------------

### a. Pattern description
The memento pattern is a software design pattern that provides the ability to restore an object to its previous state (undo via rollback).

### b. When to use Memento pattern
* When you need to be able to track the state of an object,or/and restore previous states as needed
* When you cannot use simple operation undo/redo, by saving the commands (when there are side effects to the operations) - example translation
* Database transactions.

### c. Actors
* Originator: object that we want to save. It will create the actual memento.
* Caretaker: keeps the mementos
* Memento: (Magic cookie) internal state of the object

### d. Pitfalls
* if keeping the state/restoring the state is expensive, the memento pattern might not be fit
* Exposing information only to memento so that we don't brake encapsulation
* It may be difficult to ensure the Originator can access a Memento's state
* Caretaker has to manage Mementos, but doesn't know their size.
* Needs to consider deleting history, or how much history it should keep

### e. Flavors
* Classical memento: Save each time the entire state
* Iterative memento: Save the changes that occured from the previous state(delta), instead of saving the entire state again, (e.g. Git)

### f. Examples
* Employee example1: Starting class: Employee.EmployeeExample 
	* Save the state of an employee using a class EmployeeMememento. Keep all the the updates that were made to the Employee. 
* Employee example2: Starting class: EmployeeSerialized.EmployeeSerializedExample
	* Save the state of an employee by serializing Employee. Keep only 10 updates of the employee, the rest will be lost


6. Observer pattern
------------------

### a. Pattern description
The observer pattern is a software design pattern in which an object, called the subject,
maintains a list of its dependents, called observers, and notifies them automatically of any state changes, 
usually by calling one of their methods.
### b. When to use Observer pattern

### c. Actors
* Subject -> Interface/Abstract Notifies interested observers when an event occurs
* Concrete Subject -> Implementation of Subject
* Observer -> Interface/Abstract class -> Registers to a subject, to be notified when a specific event happens
* Concrete Observer -> Implementation of the observer

### d. Pitfalls
* Lapsed Listener problem
	* The leak happens when a listener fails to unsubscribe from the publisher when it no longer needs to listen. 
Consequently, the publisher still holds a reference to the observer which prevents it from being garbage collected 
— including all other objects it is referring to — for as long as the publisher is alive, which could be until the end of the application.
This causes not only a memory leak, but also a performance degradation with an 'uninterested' observer receiving and acting on unwanted events

### e. Flavors
* Push model -> Subject sends all the necessary data for processing the event
* Pull model -> Subject sends an event without the necessary information to process the event, in this case the Observer needs to pull the required data from the subject.

### f. Examples
* Stock update events: Starting class: StockUpdateEvents.StockUpdateEventsExample
	* Have multiple stocks that are updating the price, and some observers, printing the new prices, when the update occurs
	* RunSimple method -> Implementation of the Observer pattern using events/EventHandler, by having separate classes for both Subject/Observer
	* RunReactiveWithEvents method -> Have the Subject defined in the same way, but Observers are created using System.Reactive from events. So We still have a subject class, but for observers we use IObservable	
	* RunReactive method -> Use System.Reactive.Subject for subject, use IObservable to do observers. Neither Subject nor Observers classes are defined by us.
* Twiting example: Starting class Twits.ObservableTwitsExample
	* Have R2-D2 and t100 talk on twiter
	* Have Concrete Subject as an implementation of the Systen,IObseravable, and Concrete Observer as an implementation of System.IObserver


7. State pattern
------------------

### a. Pattern description
With the state pattern, a state machine is implemented by implementing each individual state as a derived class of the state pattern interface, and implementing state transitions by invoking methods defined by the pattern's superclass.
### b. When to use State pattern
* Every time you have a single property that represents the state of the object

### c. Actors
* Context - The class where you define all the states. The client will interact with the context to do operations.
* State - The interface that each concrete state must implement
* Concrete states - implementations of the state interface/base class

### d. Pitfalls
* More difficult to see all the relations between states, and how you can go from one state to the other
* Could end up with a lot of state classes.
* If you have more than one state property, for example, a character in a game may be standing or jumping or ducking, and in the same time firing or not, maybe in the same time getting shot. 
If we want to implement this using state pattern, we would need to make a new class for all the combinations of the all the states.

### e. Flavors
* hierarchical state pattern
* Classical state pattern

### f. Examples
* TVExample: Starting class TVExample.TVExample
	* Have the implementation of what should happen when you are pressing the power button
	* Motivational example class: TVExample.TVMotivationalExample - how you would implement it without state pattern
*  Fan example: Starting class: FanExample.FanWithStatePatternExample
	* Have a fan with a chain, that when pulled it would move from
		* Off to speed 1
		* speed 1 to speed 2
		* speed 2 to speed 3
		* speed 3 to speed 4
		* speed 4 to Off
	* Motivational example class: FanExample.FanMotivationalExample
* SCRUM example: Starting class: ScrumExample.ScrumStatePatternExample
	* Implement the transitions between user story states
		* Create - creates a new user story in state New
		* RemoveFromBacklog - moves a user story from state New to State removed
		* StartImplementation - moves user story from state New to state Active
		* MoveToBacklog - moves user story from state Active/Removed to state New
		* CodeFinishedAnUnitTestsPassed - move user story from state Active to state Resolved 
		* AcceptanceTestsFail - move user story from state Resolved to state Active
		* AcceptanceTestsPassed - moves user story from state Resolved to state Closed
	* Motivational example class: ScrumExample.ScrumMotivationalExample


8. Strategy pattern
------------------

### a. Pattern description
Strategy pattern (also known as the policy pattern) is a software design pattern that enables an algorithm's behavior to be selected at runtime. 
The strategy pattern defines a family of algorithms, encapsulates each algorithm, and makes the algorithms interchangeable within that family.
### b. When to use Strategy pattern
* Classical thing to say: Whenever you start to use a switch statement you should ask yourself whether you can use Strategy Pattern instead.
* When you want to externalize part of the algorithm

### c. Actors

### d. Pitfalls
### e. Flavors
### f. Examples

9. Template pattern
------------------

### a. Pattern description
### b. When to use Template pattern
### c. Actors
### d. Pitfalls
### e. Flavors
### f. Examples

10. Visitor pattern
------------------

### a. Pattern description
### b. When to use Visitor pattern
### c. Actors
### d. Pitfalls
### e. Flavors
### f. Examples

