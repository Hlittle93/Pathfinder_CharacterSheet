using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Character> Characters { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Spell> Spells { get; set; }
    public DbSet<IGameItem> GameItems { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<CharacterSpell> CharacterSpells { get; set; }
    public DbSet<CharacterGameItem> CharacterIGameItems { get; set; }
    public DbSet<CharacterSkill> CharacterSkills { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CharacterSpell>()
            .HasKey(cs => new { cs.CharacterId, cs.SpellId });
        modelBuilder.Entity<CharacterSpell>()
            .HasOne(c => c.Character)
            .WithMany(cs => cs.CharacterSpells)
            .HasForeignKey(c => c.CharacterId);
        modelBuilder.Entity<CharacterSpell>()
            .HasOne(c => c.Spell)
            .WithMany(cs => cs.CharacterSpells)
            .HasForeignKey(c => c.SpellId);

        modelBuilder.Entity<CharacterGameItem>()
            .HasKey(cg => new { cg.CharacterId, cg.GameItemId});
        modelBuilder.Entity<CharacterGameItem>()
            .HasOne(c => c.Character)
            .WithMany(cg => cg.CharacterGameItems)
            .HasForeignKey(c => c.CharacterId);
        modelBuilder.Entity<CharacterGameItem>()
            .HasOne(c => c.GameItem)
            .WithMany(cg => cg.CharacterGameItems)
            .HasForeignKey(c => c.GameItemId);

        modelBuilder.Entity<CharacterSkill>()
            .HasKey(cs => new { cs.CharacterId, cs.SkillId });
        modelBuilder.Entity<CharacterSkill>()
            .HasOne(c => c.Character)
            .WithMany(cs => cs.CharacterSkills)
            .HasForeignKey(c => c.CharacterId);
        modelBuilder.Entity<CharacterSkill>()
            .HasOne(c => c.Skill)
            .WithMany(cg => cg.CharacterSkills)
            .HasForeignKey(c => c.SkillId);

    }

}
