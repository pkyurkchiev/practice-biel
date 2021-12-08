### Development
#### Step 1
- Copy the last day AssignmentManager solution.
- Setup the Solution Properties to use AM.WebServices & AM.WebSite projects as Startup.
- Run the solution. Check the server localhost:xxxxx/swagger & the website is loaded.
- Get your ports (example: https://localhost:44309) of both server & website and copied them into the entire solution.
#### Step 2
- Rename the DB in AM.WebServices/appsettings.json to LibraryDB.
- Rename the solution to LibraryManager.
- Rename project AM.Data to LM.Data and namespaces inside.
- Rename project AM.Repositories to LM.Repositories and namespaces inside.
- Rename project AM.ApplicationServices to LM.ApplicationServices and namespaces inside.

- Rename project AM.WebServices to LM.WebServices and namespaces inside.

- Rename project AM.WebSite to LM.WebSite and namespaces inside.
