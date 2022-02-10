# WordLadderSolver developed by Ricardo Raposo

This repository consists of two projects, the **library** itself and a **UnitTest project**, to test the library.

The Projects are each in a different folder, inside the Projects folder.
Inside the Solutions folder, is a .sln that will open both projects, to facilitate testing and seeing the source code at the same time.

This library solves word ladders.

The current implementation for solving a word ladder, is using a **Breadth First Search and Depth First Search** (***BADS***) to get the shortest sequence of words, that are only one character different from each other.

Resources used:

[Graph theory](https://en.wikipedia.org/wiki/Graph_theory)

[Breadth-first search](https://en.wikipedia.org/wiki/Breadth-first_search)


[Depth-first search](https://en.wikipedia.org/wiki/Depth-first_search)

Although the current implementation class used by default is using ***BADS***, the library is prepared for **expansion**, and ready for different classes that can solve the Word ladder problem. 

At the moment, there is another class in development available to test, but the necessary methods defined by a solver **interface** are **not implemented**, so an exception will occur when overriding the default ***BADS*** SolverType. 


There is a console application that uses this library, referenced as a **NuGet package**, available in the following repository: https://github.com/R-Raposo/BluePrism_TechTest

This library, as previously written, is available as a NuGet package: https://www.nuget.org/packages/WordLadderSolver/
