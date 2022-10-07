# Cached_Statistics_Data
Contains the Code for the Caching the data of web application

#Dev Work : Author : Avish Gupta

While Creating this Code we have followed all coding standards and Solid Principles.

1. Single Responsibility Principle - each of the class created have their own resposnsibility like AddCaching.cs to add the cahe, RetreiveCaching.cs to retreive the caching data.

2. Open - Closed Principle - following this principle we can extend the functionality in the Home Controller to Add, Delete and Fetch Cached data using their Interface seperately which can work without changing the classes only by extending them.

3. Liskov's Sustitution - Interfaces have been created to fetch their classes and its sub clss.

4. Interface Segregation - segregated interfaces being created for each functionality like CacheFactory implements ICacheFactory, AddCaching implements IAddCaching etc.

5. Dependency Injection - Made services loosely coupled to data cache factory by constructor injection(Dependency Injection). No instantiation in methods.

Pattern Used :-
1.Factory Pattern to determine Cache Data storing.
2.Startegy Pattern to determine Controller for different kinds of process of caching(Add/Remove/Get)
