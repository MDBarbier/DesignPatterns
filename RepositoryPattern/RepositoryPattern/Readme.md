
# Demo of the repository pattern

This demo app uses the repository pattern to seperate the application from the database completely. 

The application's controller only knows about the repository, all implementation detail of the database (EF Core and SQLite in this case) is hidden to the application.

This allows the database/storage solution to be completely changed and the application itself does not need to be updated, just the repository needs to be udpated.

The flaw with this demo app is the repository is tied to the entity type (i.e. Movie in this case). In a large application with many entities you would not want to map 
them all in the repository so you would use generics.

See the "RepositoryWithGenerics" demo app in this solution for an example of that.