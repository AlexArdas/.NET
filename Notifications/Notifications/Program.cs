using MediatR;
using Notifications;
using Notifications.BL.MediatR.Commands;
using Notifications.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSettings(builder.Configuration);
builder.Services.AddValidators();
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddDbContext(builder.Configuration.GetConnectionString("DbConnection"));
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(SendEmailsCommand).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandingMiddleware>();

app.MapControllers();

app.Run();
