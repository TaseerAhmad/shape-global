# shape-global
Coding assessment

🔧 Tools used:
- ASP.NET Core WebApi for the server
- Built on top of .NET 7
- PostgreSQL for the data store
- Bcrypt for hashing passwords
- EF Core 7 for the ORM
- FluentValidation for a clean 🧼 model validation
- Bootstrap for the responsive front-end
- JavaScript to give front-end a life 💪

✔ API adheres to RFC-7807 specification for consistent API error responses. Specification can be further extended to return consistent success responses too.

⚠ After cloning the project, make sure to replace the database connection string with your own from `appsettings.json`:
<br>
```
"ConnectionStrings": {
  "Database": "Host=localhost;Database=shapeglobal;Username=postgres;Password=bygTGfw4a53KHu"
}
```
⚠ Not only this, you may also need to change the HTTP request URL from the front-end depending on your server's port
To update the request URL, go to script.js in /client folder and update the following line:
```
const response = await fetch('https://localhost:<YOUR_SERVER_PORT>/api/Auth/Signup', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
      });
```
