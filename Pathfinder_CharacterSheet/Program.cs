using Microsoft.EntityFrameworkCore;
using Pathfinder_CharacterSheet.Interfaces;
using Pathfinder_CharacterSheet.Repository;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
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

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                "v1"
                ));

        app.Run();
    }
}
