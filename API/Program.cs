
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the Controllers to the dependency injection container.
builder.Services.AddControllers();
builder.Services.AddAplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

// Register services for Swagger API documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

// Enable CORS to allow requests from "https://localhost:4200".
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

// When in development environment, enable Swagger for API documentation.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

app.UseAuthentication();

// Authorize user actions based on provided tokens.
app.UseAuthorization();

// Map and route incoming HTTP requests to appropriate controllers.
app.MapControllers();

// Start processing requests.
app.Run();
