using static Spell;

public class SpellDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string School { get; set; }
    public int Level { get; set; }
    public CastingTime CastTime { get; set; }
    public string Components { get; set; }
    public SpellRange Range { get; set; }
    public string Effect { get; set; }
    public bool SavingThrow { get; set; }
    public bool SpellResistance { get; set; }
    public bool Known { get; set; }
    public bool Prepared { get; set; }
}