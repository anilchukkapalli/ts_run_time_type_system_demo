using Microsoft.EntityFrameworkCore;

class Todo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}

class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}

class TodoItems
{
    public async Task<List<Todo>> GetTodoItemsAsync(TodoDb db)
        => await db.Todos.ToListAsync();
    
    public async Task<List<Todo>> GetTodoItemsCompleteAsync(TodoDb db)
        => await db.Todos.Where(t => t.IsComplete).ToListAsync();
    
    public async Task<IResult> GetTodoItemAsync(int id, TodoDb db)
        => await db.Todos.FindAsync(id)
            is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound();
    
    public async Task<IResult> SaveTodoItemAsync(Todo todo, TodoDb db)
    {
        db.Todos.Add(todo);
        await db.SaveChangesAsync();
        return Results.Created($"/todoitems/{todo.Id}", todo);
    }

    public async Task<IResult> UpdateTodoItemAsync(int id, Todo todo, TodoDb db)
    {
        var existingTodo = await db.Todos.FindAsync(id);
        if (existingTodo is null) return Results.NotFound();

        existingTodo.Name = todo.Name;
        existingTodo.IsComplete = todo.IsComplete;

        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    public async Task<IResult> DeleteTodoItemAsync(int id, TodoDb db)
    {
        if (await db.Todos.FindAsync(id) is Todo todo)
        {
            db.Todos.Remove(todo);
            await db.SaveChangesAsync();
            return Results.Ok(todo);
        }

        return Results.NotFound();
    }

    public static IEnumerable<Todo> GetFakeTodoItems()
        => Enumerable.Range(1, 10).Select(i => new Todo
        {
            Id = i,
            Name = $"Todo {i}",
            IsComplete = i % 2 == 0
        });
}