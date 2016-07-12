BehavioralPatterns
==================
Behavioral Patterns is a .NET core solution that shows some ways to implement the behavioral patterns described by the Gang of Four.
Patterns described:
1. Chain of responssibility
---------------------------
Implemented in project: ChainOfResponsibility
### a. Pattern description:
Decouples sender and receiver (as a sender you don't know who will handle the request/ as a receiver you don't know who the sender is necessary)
Hierarchical in nature 
### b.When using the Chain of Responsibility is more effective:
More than one object can handle a command
The handler is not known in advance
The handler should be determined automatically
It’s wished that the request is addressed to a group of objects without explicitly specifying its receiver
The group of objects that may handle the command must be specified in a dynamic way.
Examples in real life:
 -java.util.logging.Logger.#log()
 -javax.servlet.Filter#doFilter()
 -Spring Security Filter Chain
### c. Pitfalls:
Handling/Handler guarantee - you won't be sure that someone can process the request
Runtime configuration risk - the order matters/and it might be that the chain is not configured correctly
Chain length/performance issues - in theory you could see a chain that is too big, and it would be a bottleneck in performance
### d. Flavors:
Flavor 1: Execute first that matches the condition and exit -> Get one to process the request, or get the type of object
Flavor 2: Execute all elements of chain until the condition does not match -> Execute all validators until one invalidates the request
Flavor 3: Always execute all handlers
Flavor 4: Instead of each handler, having a successor, you could have each handler have a list of successors, and have it's policy what handlers to execute
### e. Examples described:
Purchase example: 
Starting class: PurchaseExample.CheckAuthority
Problem that we are trying to solve:
CheckAuthority allows an employee to request money for approval
 if(manager can approve it) manager will process the request
 if (director can approve it) director will process the request
 if (vice president can approve it) vice president will process the request
 if (president can approve it) president will process the request

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
