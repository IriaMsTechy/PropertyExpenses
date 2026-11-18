using DBConnection.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

//document should be in openapi/v1.json
//builder.Services.AddOpenApi();
builder.Services.AddDbContext<PropertyContext> (opt => opt.UseSqlServer(
        builder.Configuration.GetConnectionString("PropertyConnection")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo { Title = "DB Connection API", Version = "v1" });
});

//if (builder.Environment.IsDevelopment())
//{
//    builder.Services.AddSwaggerConfiguration(builder.Configuration);
//}

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("../swagger/v1/swagger.json", "DBConnection v1");
    });

}

    app.UseHttpsRedirection();

    app.UseAuthorization();

app.UseCors("AllowBlazor");
app.MapControllers();

    app.Run();

