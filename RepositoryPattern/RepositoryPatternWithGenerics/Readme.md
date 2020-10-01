
## Adding a record to the database

I have not added a gui page to do this, because it wasn't the purpose of the exercise, but you can add a record to the SQLite database by using entering this URL into the browser window:

(Obviosly change the actual data first because the DB has a unique constraint on title)

https://localhost:44376/home/add?json={"Title": "The Simpsons Movie", "Year":2006, "Rating": 8, "Genre": "Comedy cartoon"}

Once the record has successfully been added, the controller uses the repository to do a "Find" based on the name from the database and displays the result.