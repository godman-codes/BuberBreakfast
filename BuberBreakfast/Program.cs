using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
// this is the builder variable for dependencies injections and configurations

// Add services to the container.
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
}

var app = builder.Build();
// app variable for managing the request pipeline
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

