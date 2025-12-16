using Microsoft.AspNetCore.Authentication.JwtBearer;
using Redarbor.API.Extensions;
using Redarbor.Application._Install;
using Redarbor.InfrastructureEF._Install;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["OAuth:Authority"];
        options.Audience = builder.Configuration["OAuth:Audience"];
        options.RequireHttpsMetadata = false;//builder.Environment.IsProduction();
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(policyBuilder =>
{
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader());
});

builder.Services.AddApplicationDependency();
builder.Services.AddInfraestructureDependency(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });
}

app.UseErrorHandlingMiddleware();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
await app.RunAsync();
