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

    public Character GetCharacter(int charid)
    {
        return _context.Characters.Where(c => c.Id == charid).FirstOrDefault();
    }

    public Character GetCharacter(string name)
    {
        return _context.Characters.Where(c =>c.Name == name).FirstOrDefault();
    }

    public async Task<ICollection<Character>> GetCharactersAsync()
    {
        return await _context.Characters.OrderBy(c => c.Id).ToListAsync();
    }
}
