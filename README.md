<h2>Introduction</h2> 
Dofe is a Virtual Coffee for dog lovers. People can upload their dogs information and access event information that hosted by other customers.
This MVC website is built by bootstrap, Asp.net Core, SQL.

![image](https://user-images.githubusercontent.com/92262463/179393161-d3ca1d1c-9a5a-403c-aa40-fc8aea4cf34f.png)

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
1. Role management<br>
By using Identity core, we can set the user as a particular role as a simple user, manager or even admin. Although users are in the same page, anonymous 
are restricted to access information but admin are authorized to edit and delete any events.

2. Third Party Login<br>
External login is an user friendly desgin. User can simply use third party to authorize the process but they do not need to enter any password.
User will persist loggin because cookies will be stored in the browser until logout or clearing cookies. Here are some main process:

* Install third party packages in Nuget 
* Sign into the third party platform and put the Oauth ID and secret into program.cs
```builder.Services.AddAuthentication()
.AddFacebook(options =>
{
    options.AppId = "";
    options.AppSecret = "";
})
.AddGoogle(options =>
{
    options.ClientId = "";
    options.ClientSecret = "";
});
```
* input your redirect url in third party platform 
* Tutorials: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/?view=aspnetcore-6.0&tabs=visual-studio

3. Email Confirmation and password reset<br>
Email Confirmation is another way for user to login easily but you should be care that such emails are generally regarded as junk mails or blocked by some providers.
Sendgird and mailjet are the platforms that allow developers to add mailing function in thier web application. To do this:

* Register an account
sendgird: https://sendgrid.com/
mailjet: https://www.mailjet.com/

* Put the id and secret into appsetting.json 
```
  "MailJet": {
    "ApiKey": "",
    "SecretKey": ""
  }
```

Others
1. Unit testing
* Understand THE basic 3A principle and using Fluent Assertions And FakeItEasy

2. External Api Fetching
* Connect to an external Api and interact with database 
[Ipinfo](https://ipinfo.io/)

3. Basic CRUD operation
* The app allows users to create events, post photo, edit information and delete their items.

Future Development 
1. git controlling 
* I have very basic concept with git control at first and face merge conflict when i am making the project. I should not use ```git push --force``` in some previous folders that results my loss of record so i decide to upload a new folder.
the previous project record
https://github.com/kucmoving/PetCafe-Remake-


2. Adding identity functionality
* The project can be upgraded by adding the usage of QR Code or Multi-Factor Authentication.




