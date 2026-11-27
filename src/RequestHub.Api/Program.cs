using Microsoft.EntityFrameworkCore;
using RequestHub.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Phase 1: register services. The app is not listening yet.
// Dependency injection: a class asks for what it needs in its constructor.
// This list is the recipe for creating it. AppDbContext needs SQL Server
// and the DefaultConnection string. Build() locks this list.

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))  );


var app = builder.Build();


// Phase 2: the path of one HTTP request. Run() starts the app and waits for requests.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Phase 3: the app is listening. The request path is handled by the controller.
// Run() starts the app and waits for requests.
app.Run();



/*
    NOTE : Program.cs is the composition root, the one place that wires the app together.
           AddDbContext registers AppDbContext with dependency injection, so a class can
           ask for AppDbContext instead of writing new AppDbContext().
           UseSqlServer says the database is SQL Server.
           GetConnectionString("DefaultConnection") reads the connection string from
           appsettings.Development.json. The name must match the JSON key.
           This runs before Build(), because Build() locks the service list.
           AddDbContext is scoped: one AppDbContext per web request, then it is discarded.
*/