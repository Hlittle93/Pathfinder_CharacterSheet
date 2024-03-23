using Microsoft.EntityFrameworkCore;

public class CharacterRepository: ICharacterRepository
{
    private readonly DataContext _context;

    public CharacterRepository(DataContext context)
    {
        _context = context;
    }

    public bool CharacterExists(int charid)
    {
        return _context.Characters.Any (c => c.Id == charid);
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
}
