<h2>Introduction</h2> 
Dofe is a Virtual Coffee for dog lovers. People can upload their dogs information and access event information that hosted by other customers.
This MVC website is built by bootstrap, Asp.net Core, SQL.

<h2>Get started</h2>

1. Clone the project
```$ git clone https://github.com/kucmoving/DofeMVC```

2. Use your tool to open the folder (Visual Studio Code or Visual Studio)

3. Create a local database(Personally i am using MicrosoftSQL 2019)
* Add a connection string to appsetting.json (Please change your own location code after DefaultConnection)<br>
```{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=LAPTOP-NCT36AOV\\SQLEXPRESS;Initial Catalog=ParentStudentWebAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  },
```
* Add migration, update database, data seeding(See Program.cs. You should seed normal data and account data separately )<br>
```dotnet ef migrations add InitialCreate```
```dotnet ef database update```
```$ dotnet run seeddata```<br>

4. You Should now can turn on the Project but some functions were restricted.

5. API Key
* Input Secret key and code in Program.cs and AppSetting.json(will be explained more in next part)


<h2>Lesson Learned</h2>

Here are some elements i have learnt after this project:<br>

Authuentication
1. Role management
By using Identity core, we can set the user as a particular role as a simple user, manager or even admin. Although users are in the same page, anonymous 
are restricted to access information but admin are authorized to edit and delete any events.

2. Third Party Login
External login is an user friendly desgin. User can simply use third party to authorize the process but they do not need to enter any password.
User will persist loggin because cookies will be stored in the browser until logout or clearing cookies. Here are some main process:

* Install third party packages in Nuget 
* Sign into the third party platform and put the Oauth ID and secret into program.cs
* input your redirect url in third party platform 
* Tutorials: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/?view=aspnetcore-6.0&tabs=visual-studio

3. Email Confirmation and password reset
Email Confirmation is another way for user to login easily but be care that such emails are generally regarded as junk mails or blocked by some providers.
Sendgird and mailjet are the platform allow developers to add mailing function in their application. Simply register an account and put the id and secret into appsetting.json 

sendgird: https://sendgrid.com/
mailjet: https://www.mailjet.com/

Others
1. Unit testing
* Understand THE basic 3A principle and using Fluent Assertions And FakeItEasy

2. External Api Fetching
* Connect to an external Api and interact with database 

3. Basic CRUD operation
* to build CRUD operation in web application





