
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICarpoolManager>(provider =>
{
    var options = new DbContextOptionsBuilder<CarpoolContext>();
    options.UseSqlite("Data Source=CarpoolDataBase.db");
    var carpoolContext = new CarpoolContext(options.Options);
    carpoolContext.Database.EnsureCreated();
    ICarpoolRepository carpoolRepository = new CarpoolRepository(carpoolContext);
    ICarpoolManager carpoolManager = new CarpoolManager(carpoolRepository);

    return carpoolManager;
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
