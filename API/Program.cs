using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//custom extensions
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

//enforce HTTPS in ASP.NET core --commented as I do not want to use HTTPS for this tutorial
//app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200"));

app.UseAuthentication(); //do you have a valid token?
app.UseAuthorization(); //what are you allowed to do?

app.MapControllers();

app.Run();
