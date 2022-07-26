var builder = WebApplication.CreateBuilder(args);

string path = Path.Combine(Environment.CurrentDirectory, "Config");
System.IO.DirectoryInfo directory = new DirectoryInfo(path);
foreach (var item in directory.EnumerateFiles())
{
    builder.Configuration.AddJsonFile(item.FullName);
}

builder.Configuration.AddUserSecrets(typeof(Program).Assembly);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHealthChecks("/health");

app.MapControllers();

app.Run();
