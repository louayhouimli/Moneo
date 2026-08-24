using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins, policy => policy.WithOrigins("http://localhost:5173")));

builder.Services.AddHealthChecks();

var app = builder.Build();


app.MapGet("/hello", () => "Hello World!");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");
app.UseCors(MyAllowSpecificOrigins);


app.Run();

