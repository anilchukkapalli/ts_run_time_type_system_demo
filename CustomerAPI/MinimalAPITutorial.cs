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