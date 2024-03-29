using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class CharacterRepository: ICharacterRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CharacterRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public bool CharacterExists(int charid)
    {
        return _context.Characters.Any (c => c.Id == charid);
    }

    public bool CreateCharacter(int skillid, int spellid, int gameitemid, Character character)
    {
        var characterSkillEntity = _context.Skills.Where(c => c.Id == skillid).FirstOrDefault();
        var characterSpellEntity = _context.Spells.Where(c => c.Id == spellid).FirstOrDefault();
        var characterGameItemEntity = _context.IGameItems.Where(c => c.Id == gameitemid).FirstOrDefault();

        var characterSkill = new CharacterSkill()
        {
            Skill = characterSkillEntity,
            Character = character,
        };

        _context.Add(characterSkill);

        var characterSpell = new CharacterSpell()
        {
            Spell = characterSpellEntity,
            Character = character,
        };

        _context.Add(characterSpell);

        var characterGameItem = new CharacterGameItem()
        {
            GameItem = characterGameItemEntity,
            Character = character,
        };

        _context.Add(characterGameItem);
        _context.Add(character);

        return Save();
    }

    public bool DeleteCharacter(Character character)
    {
        _context.Remove(character);
        return Save();
    }

    public Character GetCharacter(int charid)
    {
        return _context.Characters.Where(c => c.Id == charid).FirstOrDefault();
    }

    public Character GetCharacter(string name)
    {
        return _context.Characters.Where(c =>c.Name == name).FirstOrDefault();
    }

    public ICollection<Character> GetCharacters()
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Character>> GetCharactersAsync()
    {
        return await _context.Characters.OrderBy(c => c.Id).ToListAsync();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool UpdateCharacter(int skillid, int spellid, int gameitemid, Character character)
    {
        throw new NotImplementedException();
    }

    public bool UpdateCharcter(int skillid, int spellid, int gameitemid, Character character)
    {
        _context.Update(character);
        return Save();
    }
}
