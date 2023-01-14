# ASP.NET Core MVC URL Shortener
ASP.NET Core MVC URL Shortener with different access rights for different roles.

# Frameworks & APIs
- EntityFramework
- ASP.NET Core Identity

# Sign in/sign up, admin panel

Among the main features are user registration and login, a small administrative panel with the ability to assign any user the role of administrator or something. Also, there is an opportunity to create a role.

It is possible to manage access to the functionality.

![Login](/ImageGT/Reg.png)

Admin panel view: 

![Admin](/ImageGT/admn.png)

![Role](/ImageGT/rol.png)

# URL Shortener

Basicaly, we store the URL in database, so it has a numeric ID, an we convert it to a another base in order to have a "stringified" version of the ID.

When we have the short URL the process is:

 - convert the "stringified" ID to the numeric ID.
 - load the data from DB.
 - redirect to the original URL using an HTTP redirection.

In writing the algorithm, helped this topic in StackOverflow [link](https://stackoverflow.com/questions/742013/how-do-i-create-a-url-shortener) 

![Short](/ImageGT/Short.png)