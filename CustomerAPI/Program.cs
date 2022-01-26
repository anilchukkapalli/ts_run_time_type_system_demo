var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins
                          ("https://localhost:7280",
                           "http://localhost:8080",
                           "https://localhost:7280/customers");
                      });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.MapGet("/customers", () =>
{
    var testAddress = new Address
    (
        Street: "123 Main St",
        City: "Anytown",
        State:"WA",
        Zip: "12345"
    );
    var customers = new List<Customer>(){
        new Customer("c1","peter","parker", testAddress),
        new Customer("c2","bruce","wayne", testAddress),
        new Customer("c3","john","doe", testAddress),
    };
    return customers;
})
.WithName<RouteHandlerBuilder>("GetCustomers");

app.Run();

record struct Customer(string Id, string FirstName, string LastName, Address Address);
record struct Address(string Street, string City, string State, string Zip);
