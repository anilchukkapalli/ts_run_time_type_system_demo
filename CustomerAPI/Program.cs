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
    return Enumerable.Range(1,10).Select(i => new Customer(
        FirstName: Faker.Name.First(),
        LastName: Faker.Name.Last(),
        Id: $"c{i}",
        Address: new Address
        (
            Street: Faker.Address.StreetAddress(),
            City: Faker.Address.City(),
            State: Faker.Address.UsStateAbbr(),
            Zip: Faker.Address.ZipCode()
        )
    ));
})
.WithName<RouteHandlerBuilder>("GetCustomers");

app.Run();
