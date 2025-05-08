using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Repository;
using Quiz.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<BaseRepository, BaseRepository>();
builder.Services.AddScoped<SeedDataService, SeedDataService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate(); // Apply any pending migrations
        var seedDataService = scope.ServiceProvider.GetRequiredService<SeedDataService>();
        await seedDataService.SeedQuizData(); // Seed the database with initial data
    }
    catch (Exception ex)
    {
        // Handle exceptions during seeding
        Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
    }
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
