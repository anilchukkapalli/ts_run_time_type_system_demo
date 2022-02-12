using Microsoft.EntityFrameworkCore;

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

// Adding entity framework core
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.MapGet("/customers", Customers.GetFakeCustomers)
    .WithName<RouteHandlerBuilder>("GetCustomers");

var todoItems = new TodoItems();
app.MapGet("/todoitems", todoItems.GetTodoItemsAsync)
    .WithName<RouteHandlerBuilder>("GetTodoItems");

app.MapGet("/todoitems/complete", todoItems.GetTodoItemsCompleteAsync)
    .WithName<RouteHandlerBuilder>("GetTodoItemsComplete");

app.MapGet("/todoitems/{id}", todoItems.GetTodoItemAsync)
    .WithName<RouteHandlerBuilder>("GetTodoItem");

app.MapPost("/todoitems", todoItems.SaveTodoItemAsync);

app.MapPut("/todoitems/{id}", todoItems.UpdateTodoItemAsync);

app.MapDelete("/todoitems/{id}", todoItems.DeleteTodoItemAsync);

app.MapGet("/fakeTodoitems", TodoItems.GetFakeTodoItems)
    .WithName<RouteHandlerBuilder>("GetFakeTodoItems");

app.Run();
