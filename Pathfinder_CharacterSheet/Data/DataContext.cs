using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

public class DataContext : DbContext
{
    public DbSet<Character> Characters { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Spell> Spells { get; set; }    
    public DbSet<IGameItem> GameItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                
    if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SSV33K7\\SQLEXPRESS;Initial Catalog=CharacterDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

}
