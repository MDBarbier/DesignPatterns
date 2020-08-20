
# Demo of the repository pattern

This demo app uses the repository pattern to seperate the application from the database completely. 

The application's controller only knows about the repository, all implementation detail of the database (EF Core and SQLite in this case) is hidden to the application.

This allows the database/storage solution to be completely changed and the application itself does not need to be updated, just the repository needs to be udpated.

This application uses generics so that IRepository and IGenericRepository can be used for any entity type. This means you get all the basic functionality "for free", 
without having to manually specify it in the Implementation of the Repository (in this case MovieRepository). In fact in this application you will see there is nothing in MovieRepository
because it doesn't need to override any of the default behaviour  provided in the generic repository base.

The Movie Repository is required though because it is what we register with the IOC container to allow Dependency injection of the interface i.e. in Startup.cs:

```
  services.AddTransient<IRepository<Movie>, MovieRepository>();     
```

And in the controller:

```  
   private readonly IRepository<Movie> movieRepository;

   public HomeController(ILogger<HomeController> logger, IRepository<Movie> movieAccessMethods)
   {
    _logger = logger;
    movieRepository = movieAccessMethods;
   }
```

## Adding a record to the database

I have not added a gui page to do this, because it wasn't the purpose of the exercise, but you can add a record to the SQLite database by using entering this URL into the browser window:

(Obviosly change the actual data first because the DB has a unique constraint on title)

https://localhost:44376/home/add?json={"Title": "The Simpsons Movie", "Year":2006, "Rating": 8, "Genre": "Comedy cartoon"}

Once the record has successfully been added, the controller uses the repository to do a "Find" based on the name from the database and displays the result.