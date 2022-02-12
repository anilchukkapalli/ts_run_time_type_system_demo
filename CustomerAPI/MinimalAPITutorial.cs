// 1. Simple API with 3 Lines
// var app = WebApplication.Create(args);
// app.MapGet("/", () => "Hello World");
// app.Run();

// 2. Changing the port
// app.Run("http://localhost:3000");

// 3. Multiple ports
// var app = WebApplication.Create(args);

// app.Urls.Add("http://localhost:3000");
// app.Urls.Add("http://localhost:4000");

// app.MapGet("/", () => "Hello World");

// app.Run();

// 4. Reading the port from the environment
// var app = WebApplication.Create(args);

// var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";

// app.MapGet("/", () => "Hello World");

// app.Run($"http://localhost:{port}");

// 5. Https with self-signed certificate
// var app = WebApplication.Create(args);

// app.Urls.Add("https://localhost:3000");

// app.MapGet("/", () => "Hello World");

// app.Run();

// 6. Https with custom certificate
// ar builder = WebApplication.CreateBuilder(args);

// Configure the cert and the key
// builder.Configuration["Kestrel:Certificates:Default:Path"] = "site.crt";
// builder.Configuration["Kestrel:Certificates:Default:KeyPath"] = "site.key";

// var app = builder.Build();

// app.Urls.Add("https://localhost:3000");

// app.MapGet("/", () => "Hello World");

// app.Run();

// 7. Reading from the environment
// var app = WebApplication.Create(args);

// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/oops");
// }

// app.MapGet("/", () => "Hello World");
// app.MapGet("/oops", () => "Oops! An error happened.");

// app.Run();

// 8. Reading the configuration
// var app = WebApplication.Create(args);

// Console.WriteLine($"The configuration value is {app.Configuration["key"]}");

// app.Run();

// 9. Reading the configuration from the app settings
// var app = WebApplication.Create(args);

// Console.WriteLine($"The configuration value is {app.Configuration["key"]}");

// app.Run();

// 10. Logging

// var app = WebApplication.Create(args);

// app.Logger.LogInformation("The application started");

// app.Run();

// 11. Changing the content root, application name and environment name
// var builder = WebApplication.CreateBuilder(new WebApplicationOptions
// {
//     ApplicationName = typeof(Program).Assembly.FullName,
//     ContentRootPath = Directory.GetCurrentDirectory(),
//     EnvironmentName = Environments.Staging
// });

// Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
// Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
// Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");

// var app = builder.Build();

// 12. Adding configuration providers
// var builder = WebApplication.CreateBuilder(args);

// builder.Configuration.AddIniFile("appsettings.ini");

// var app = builder.Build();

// // 13. Reading configuration from the environment
// var builder = WebApplication.CreateBuilder(args);

// // Reads the ConnectionStrings section of configuration and looks for a sub key called Todos
// var connectionString = builder.Configuration.GetConnectionString("Todos");

// Console.WriteLine($"My connection string is {connectionString}");

// var app = builder.Build();



// Routing
// R1. Simple routing
// app.MapGet("/", () => "This is a GET");
// app.MapPost("/", () => "This is a POST");
// app.MapPut("/", () => "This is a PUT");
// app.MapDelete("/", () => "This is a DELETE");

// R2. Options or head
// app.MapMethods("/options-or-head", new [] { "OPTIONS", "HEAD" }, () => "This is an options or head request ");

// R3. Route handles

// Local function
// app.MapGet("/", () => "This is an inline lambda");

// var handler = () => "This is a lambda variable";

// app.MapGet("/", handler);

// R3.2Instance method

// var handler = new HelloHandler();

// app.MapGet("/", handler.Hello);

// class HelloHandler
// {
//     public string Hello() 
//     {
//         return "Hello World";
//     }
// }

// R3.3 Static method
// var handler = new HelloHandler();

// app.MapGet("/", handler.Hello);

// class HelloHandler
// {
//     public string Hello() 
//     {
//         return "Hello World";
//     }
// }

// R4. Naming routes and link generation
// app.MapGet("/hello", () => "Hello there")
//    .WithName("hi");

// app.MapGet("/", (LinkGenerator linker) => $"The link to the hello route is {linker.GetPathByName("hi", values: null)}");


