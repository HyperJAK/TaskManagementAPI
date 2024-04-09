using TaskManagementAPI_proj.Data;
using TaskManagementAPI_proj.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<TaskManagerContext>("Data Source=taskManagement.db");


builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<SubTaskService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.UseCors(options => options
        .WithOrigins("http://localhost:3000", "http://localhost:3001") // Allow requests from this origin
        .AllowAnyMethod()
        .AllowAnyHeader());

app.MapGet("/", () => @"Tasks management API. Navigate to /swagger to open the Swagger test UI.");


app.Run();
