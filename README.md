BehavioralPatterns
==================
* In software engineering, behavioral design patterns are design patterns that identify common communication patterns between objects and realize these patterns. By doing so, these patterns increase flexibility in carrying out this communication.
* Behavioral patterns are concerned with algorithms and the assignment of responsibilities between objects.

There are 2 types of behavioral patterns. 
* Behavioral class patterns - Use inheritance to distribute behavior between classes - Template Method Pattern and Interpreter pattern
* Behavioral object patterns - Use composition rather than inheritance. All other patterns and behavioral object patterns

How this project is structured:

1. Behavioral Patterns is a .NET core solution that shows some ways to implement the behavioral patterns described by the Gang of Four.
2. The entry point for all patterns is the project BehavioralPatterns, which is a console application that lets you choose what pattern you want to execute
3. For each pattern there is a class library project with the name of the pattern. And each project has a class Run[PatternName]Examples or something similary that has a public static method called Run, that will run all the examples implemented for that pattern.

I left out interpreter pattern intentionally, as it seems that the application of it is not so common, if you think otherwise, just contribute with it.

Patterns described:

[1. Chain of responssibility pattern](https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/README.md#1-chain-of-responssibility)

[2. Command pattern](https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/README.md#2-command-pattern)

[3. Iterator pattern](https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/README.md#3-iterator-pattern)

[4. Mediator pattern](https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/README.md#4-mediator-pattern)

[5. Memento pattern](https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/README.md#5-memento-pattern)

[6. Observer pattern](https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/README.md#6-observer-pattern)

[7. State pattern](https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/README.md#7-state-pattern)

[8. Strategy pattern](https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/README.md#8-strategy-pattern)

[9. Template pattern](https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/README.md#9-template-pattern)

[10 Visitor pattern](https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/README.md#10-visitor-pattern)

1. Chain of responssibility
---------------------------
Implemented in project: ChainOfResponsibility
### a. Pattern description:
[ChainOfResponsibilityClassDiagram]: https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/BehavioralPatternsDiagrams/ChainOfResponsibility/ChainOfResponsibilityClassDiagram.PNG "Chain of responsibility class diagram"
[ChainOfResponsibilitySequenceDiagram]: https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/BehavioralPatternsDiagrams/ChainOfResponsibility/ChainOfResponsibilitySequenceDiagram.PNG "Chain of responsibility sequence diagram"

Decouples sender and receiver (as a sender you don't know who will handle the request/ as a receiver you don't know who the sender is necessary)

Class diagram: 

![alt text][ChainOfResponsibilityClassDiagram]

Sequence diagram: 

![alt text][ChainOfResponsibilitySequenceDiagram]
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
[CommandPatternClassDiagram]: https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/BehavioralPatternsDiagrams/CommandPattern/CommandPatternClassDiagram.PNG "Command pattern class diagram"
[CommandPatternSequenceDiagram]: https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/BehavioralPatternsDiagrams/CommandPattern/CommandPatternSequenceDiagram.PNG "Command pattern sequence diagram"

Command pattern is a behavioral design pattern in which an object is used to encapsulate 
all information needed to perform an action or trigger an event at a later time

Class diagram:

![alt text][CommandPatternClassDiagram]

Sequence diagram:

![alt text][CommandPatternSequenceDiagram]
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
[MediatorClassDiagram]: https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/BehavioralPatternsDiagrams/Mediator/MediatorClassDiagram.PNG "Mediator class diagram"
With the mediator pattern, communication between objects is encapsulated with a mediator object. 
Objects no longer communicate directly with each other, but instead communicate through the mediator. 
This reduces the dependencies between communicating objects, thereby lowering the coupling.

Mediator class diagram, while it is hard to make a generic one, as it can vary, the following diagram ca be taken into consideration with a grain of salt: ![alt text][MediatorClassDiagram]
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
[AirTraficMediator]: https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/BehavioralPatternsDiagrams/Mediator/AirTraficControllerClassDiagram.PNG "stock exchange mediator class diagram"
* StockExchange example: Starting class: StockExchange.StockExchangeExample
	* Have multiple traders Buy/Sell actions from stock exchange (simplified)
* Ground-Air traffic control example: Starting class: GroupAirTrafficControl.GroundAirTrafficControlExample
	* Have 4 planes that want to land on an airport, the airport has 4 lines (one not working). 
	They all talk to air traffic control(mediator) to ask permission to land, instead of talking to each other
* Air traffic control example: Starting class: FlightAirTrafficControl.FlightAirTrafficControlExample
	* Have multiple planes flying in the same zone, at different attitudes, instead of having them communicating to each other, 
	they all comunicate to the tower, and the tower tells them if they need to change the altitude
	* Classs diagram: ![alt text][AirTraficMediator]
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
[ObserverClassDiagram]: https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/BehavioralPatternsDiagrams/Observer/ObserverClassDiagram.PNG "Observer class diagram"
[ObserverSequenceDiagram]: https://github.com/MihaiTheCoder/BehavioralPatterns/blob/master/BehavioralPatternsDiagrams/Observer/ObserverSequenceDiagram.PNG "Observer sequence diagram"

### a. Pattern description
The observer pattern is a software design pattern in which an object, called the subject,
maintains a list of its dependents, called observers, and notifies them automatically of any state changes, 
usually by calling one of their methods.

Class diagram for the observer pattern:
![alt text][ObserverClassDiagram]

Sequence diagram for the observer pattern:
![alt text][ObserverSequenceDiagram]

### b. When to use Observer pattern

### c. Actors
* Subject (Observable) -> Interface/Abstract Notifies interested observers when an event occurs. Allows Observer to subscribe/unsubscribe.
* Concrete Subject -> Implementation of Subject.
* Observer -> Interface/Abstract class -> Defines a method to be called when the Subject wants to notify observers
* Concrete Observer -> Implementation of the observer. Registers to a subject, to be notified when a specific event happens

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
* Context -> Class that is using the strategy
* Strategy -> Strategy to be used by the context

### d. Pitfalls
* Client needs to be aware of the strategy, and be able to choose the strategy
* You might move the complicated decision of what to execute to the client out of the context.

### e. Flavors
* Classic -> Using separate class for each strategy
* Using Lambda -> Instead of having a class for each strategy, we could use lambda expression

### f. Examples
* Shipping calculator: Starting class: ShippingCalculator.ShippingWithStrategyExample
	* Decide what cost do I have if I want to ship a product via multiple shipping services
	* Motivational Example starting class: ShippingCalculator.ShippingWithStrategyExample
* Arrange interview: Starting class: ArrangeInterview.Strategy.ArrangeInterviewExample
	* Decide what should we do if we want to hire an employee, taking into consideration that it might be (dev, designer, tester, manager, devop),
	 depending on his experience he might be (junior, medium, senior, rockstar) and we might decide to hire him as (contractor, part time, full time)
	* Motivational example: ArrangeInterview.ArrangeInterviewMotivationalExample
 

9. Template pattern
------------------

### a. Pattern description
In software engineering, the template method pattern is a behavioral design pattern that defines the program skeleton of an algorithm in an operation,
defering some steps to subclasses. It lets one redefine certain steps of an algorithm without changing the algorithm's structure.
Template pattern works using 'the Hollywood principle' from the base class point of view: 'Don't call us, we'll call you'
### b. When to use Template pattern
* Let subclasses implement (through method overriding) behavior that can vary.
* Avoid duplication in the code: the general workflow structure is implemented once in the abstract class's algorithm, and necessary variations are implemented in each of the subclasses.
* Control at what point(s) subclassing is allowed. As opposed to a simple polymorphic override, where the base method would be entirely rewritten allowing radical change to the workflow, only the specific details of the workflow are allowed to change.
* You want to be able to add customization hooks to your class

### c. Actors
* Workflow/Abstract/Framework class -> Where we define the workflow that is calling the methods that may be ovveriden by the concrete class
* Concrete class -> Class that implements the abstract methods of the Framework class

### d. Pitfalls
* Uses inheritance for defining the implementation instead of composition 

### e. Flavors
* Don't know any

### f. Examples
* Workers example: Starting class: WokersExample.WorkersExample
	* have the morning routine of a manager/construction worker/student until they start working
* Game example: Starting class: GameExample.GameExample
	* Implement basketball/Football where instead of playing we just print some strings


10. Visitor pattern
------------------

### a. Pattern description
* Visitor pattern allows for one or more operation to be applied to a set of objects at runtime, decoupling the operations from the object structure.
* Visitor is similar to Iterator, the difference is that visitor pattern allows to process more complex structure with different types

### b. When to use Visitor pattern
* Dynamic flavor: When you have a complex structure that doesn't change that much, but you need to add more types of processing

### c. Actors
* Visitor - The interface that defines methods to visit each of the visitable types
* Concrete Visitor - Implemementation of the Visitor pattern
* Visitable - interface that accepts the visitor, usually one method->Accept(Visitor v)
* Concrete Visitable - Objects that are part of the complex structure that needs to be visited
* Object Structure - Object that contains all the visitable objects, and defines a way to visit them

### d. Pitfalls
* Every time you add a new visitable object, you need to modify all the visitors.

### e. Flavors
* In languages like C#, instead of having all the Concrete Visitable implemement the Visitable, we could use

### f. Examples
* Calculate money of corruption subject: Starting class: CalculateMoney.WithVisitor.CalaculateMoneyWithVisitorExample
	* For a corruption suspect calculate Monthly income, and the net worth using 2 different varations
	* Motivational example: Starting class: CalculateMoney.WithoutVisitor.CalculateMoneyMotivationalExample
	* Same functionality, but using dynamic flavor: The Visitable interface is used only for marker. And the Object Structure uses dynamic to invoke the visitors.
