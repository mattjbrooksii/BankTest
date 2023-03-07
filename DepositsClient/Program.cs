using AccountsAccess.Contracts;
using AccountsAccess.Service.Implementation;
using AccountsAccess.Service.Repository;
using StorageImplementation.Accounts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IAccountsRepository, Accounts_Mock>();
builder.Services.AddSingleton<IAccountsAccess, AccountAccess>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute("Accounts", "[controller]");

app.MapGet("/", () => "Hello World!");

app.Run();
