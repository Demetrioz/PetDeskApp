using Microsoft.EntityFrameworkCore;
using PetDeskApp.Api;
using PetDeskApp.Data.Context;
using PetDeskApp.Services.ApiService.AppointmentApiService;

var builder = WebApplication.CreateBuilder(args);

// Database Setup
builder.Services.AddDbContext<PetDeskContext>(options =>
    options.UseInMemoryDatabase(databaseName: "PetDesk"));

// CORS
// TODO: Add credentials and move origins to settings
builder.Services.AddCors(options =>
{
    options.AddPolicy(PolicyNames.Cors, builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// PetDesk Services
builder.Services.AddHttpClient<IAppointmentApiService, AppointmentApiService>();

// MVC Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed the database;
SeedDatabase(app.Services).Wait();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(PolicyNames.Cors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Helpers
async Task SeedDatabase(IServiceProvider provider)
{
    using var scope = provider.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<PetDeskContext>();
    var apiService = scope.ServiceProvider.GetRequiredService<IAppointmentApiService>();

    var appointments = await apiService.RetrieveAppointments();
    await dbContext.AddRangeAsync(appointments);
    await dbContext.SaveChangesAsync();
}