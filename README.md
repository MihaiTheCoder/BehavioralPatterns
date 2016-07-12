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
4. Instead of each handler, having a successor, you could have each handler have a list of successors, and have it's policy what handlers to execute

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

### Actors

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
4. Mediator pattern
------------------
5. Memento pattern
------------------
6. Observer pattern
------------------
7. State pattern
------------------
8. Strategy pattern
------------------
9. Template pattern
------------------
10. Visitor pattern
------------------
