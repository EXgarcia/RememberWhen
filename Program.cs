using Microsoft.EntityFrameworkCore;
using RememberWhen.Properties.Services;
using RememberWhen.Properties.Services.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<MemoryService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<FolderService>();

var connectionString = builder.Configuration.GetConnectionString("MyMemoryString");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString) );

builder.Services.AddCors(options => {
    options.AddPolicy("RememberWhenPolicy", 
    builder => {
        builder.WithOrigins("http://localhost:3000","https://remember-when.azurewebsites.net","http://localhost:5173", "https://rememberwhen.azurewebsites.net", "https://rememberwhen.vercel.app/")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("RememberWhenPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
