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
More than one object can handle a command
The handler is not known in advance
The handler should be determined automatically
It�s wished that the request is addressed to a group of objects without explicitly specifying its receiver
The group of objects that may handle the command must be specified in a dynamic way.
Examples in real life:
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
* Flavor 1: Execute first that matches the condition and exit -> Get one to process the request, or get the type of object
* Flavor 2: Execute all elements of chain until the condition does not match -> Execute all validators until one invalidates the request
* Flavor 3: Always execute all handlers
* Flavor 4: Instead of each handler, having a successor, you could have each handler have a list of successors, and have it's policy what handlers to execute

### f. Examples described:
* Purchase example: 
Starting class: PurchaseExample.CheckAuthority
Problem that we are trying to solve:
CheckAuthority allows an employee to request money for approval
 if(manager can approve it) manager will process the request
 if (director can approve it) director will process the request
 if (vice president can approve it) vice president will process the request
 if (president can approve it) president will process the request
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
