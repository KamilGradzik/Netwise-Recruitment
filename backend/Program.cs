using backend.services;
using backend.services.interfaces;
using Microsoft.OpenApi.Models;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();
        builder.Services.AddControllers();
        builder.Services.AddHttpClient<ICatFactService, CatFactService>();
        builder.Services.AddScoped<ICatFactService, CatFactService>();
        builder.Services.AddScoped<IFileService, FileService>();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Random Cat Fact",
                Description = "Simple API, developed for Netwise recruitment task's purposes."
            });
        });

        var app = builder.Build();

        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }   

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}
