using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pathfinder_CharacterSheet.Interfaces;
using Pathfinder_CharacterSheet.Repository;
using System.Text.Json.Serialization;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
        builder.Services.AddScoped<ISkillRepository, SkillRepository>();
        builder.Services.AddScoped<ISpellRepository, SpellRepository>();
        builder.Services.AddScoped<IIGameItemRepository, IGameItemRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new() { Title = "Pathfinder Character Sheet", Version = "v1" });
        });

        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(logging =>
            {
                logging.ClearProviders(); 
                logging.AddFile("Logs/myapp-{Date}.txt"); 
            });

        }

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                "v1"
                ));

        await app.RunAsync();
    }
}

