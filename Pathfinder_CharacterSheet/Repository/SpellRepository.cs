using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class SpellRepository : ISpellRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public SpellRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public bool CreateSpell(Spell spell)
    {
        _context.Add(spell);
        return Save();
    }

    public bool DeleteSpell(Spell spell)
    {
        _context.Remove(spell);
        return Save();
    }

    public Spell GetSpell(int spellId)
    {
        return _context.Spells.Where(e => e.Id == spellId).FirstOrDefault();
    }

    public Spell GetSpellByCharacter(int characterId)
    {
        return (Spell)_context.Characters.Where(o => o.Id == characterId).Select(s => s.CharacterSpells).FirstOrDefault();
    }

    public ICollection<Spell> GetSpells()
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Spell>> GetSpellsAsync()
    {
        return await _context.Spells.OrderBy(s => s.Id).ToListAsync();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool SpellExists(int spellId)
    {
        return _context.Spells.Any(spell => spell.Id == spellId);
    }

    public bool UpdateSpell(Spell spell)
    {
        _context.Update(spell);
        return Save();
    }
}
