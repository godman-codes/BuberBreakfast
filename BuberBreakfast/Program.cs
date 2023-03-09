using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
// this is the builder variable for dependencies injections and configurations

// Add services to the container.
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
    // the above line defines how the breakfast controller object is created and what is passed to it 
    // because without it the application wont know what to pass as parameter to the newly created 
    // breakfast controller object
    // always check out the difference between addScoped, addSingleton and AddTransient
}

var app = builder.Build();
// app variable for managing the request pipeline
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

