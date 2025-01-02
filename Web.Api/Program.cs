using Application;
using Infrastructure;
using Web.Api;
using Web.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Apply the database migrations
    app.ApplyMigrations();
}

// Add the custom exception handler
app.UseExceptionHandler("/api/errors");

// Endpoint for health checks
app.UseHealthChecks("/api/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
