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
    public Spell GetSpell(int spellId)
    {
        return _context.Spells.Where(e => e.Id == spellId).FirstOrDefault();
    }

    public Spell GetSpellByCharacter(int characterId)
    {
        return (Spell)_context.Characters.Where(o => o.Id == characterId).Select(s => s.CharacterSpells).FirstOrDefault();
    }

    public async Task<ICollection<Spell>> GetSpellsAsync()
    {
        return await _context.Spells.OrderBy(s => s.Id).ToListAsync();
    }

    public bool SpellExists(int spellId)
    {
        return _context.Spells.Any(spell => spell.Id == spellId);
    }
}
