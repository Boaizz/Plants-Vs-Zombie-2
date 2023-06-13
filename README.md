# Plants-Vs-Zombie-2
This is the custom program for COS20009-Object Oriented Programming, a tower defense game developed in C# using the SplashKit SDK. This project utilizes Object-Oriented Programming (OOP) concepts and integrates design patterns including Singleton, State, and Factory Method.
## Requirements 
.NET Core 5.0 SDK 

SplashKit SDK
## Design Patterns
### Singleton
In the `GameContext` class, we employ the Singleton design pattern to ensure that only one instance of the `GameContext` is created throughout the lifecycle of the game. This pattern is essential to control access to shared resources and states within the game, as well as to ensure consistency in behavior and state management.
### State
In this game, we utilize the State design pattern to manage different states of the game, such as the main menu, gameplay, and game-over screens. The State pattern allows an object to alter its behavior when its internal state changes, appearing as though the object changed its class.
The `GameState` interface is a central part of implementing this pattern. 
### Factory Method
In Plants vs Zombies 2, we utilize the Factory Method design pattern to create different types of zombie objects. This pattern provides a way to delegate the instantiation logic to child classes. It is used when a class cannot anticipate the class of objects it must create or when a class wants its subclasses to specify the objects it creates.
The `ZombieFactory` interface is fundamental in implementing this pattern.

## Screenshots
![Alt text](https://github.com/Boaizz/Plants-Vs-Zombie-2/blob/master/screenshots/image.png)
![Alt text](https://github.com/Boaizz/Plants-Vs-Zombie-2/blob/master/screenshots/image1.png)
![Alt text](https://github.com/Boaizz/Plants-Vs-Zombie-2/blob/master/screenshots/image2.png)

