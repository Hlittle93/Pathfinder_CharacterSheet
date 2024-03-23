using Microsoft.EntityFrameworkCore;

public class SkillRepository : ISkillRepository
{
    private DataContext _context;
    public SkillRepository(DataContext context)
    {
        _context = context;
    }
    public Skill GetSkill(int id)
    {
        return _context.Skills.Where(e => e.Id == id).FirstOrDefault();
    }

    public Skill GetSkill(string name)
    {
        return _context.Skills.Where(s => s.Name == name).FirstOrDefault();
    }

    public async Task<ICollection<Skill>> GetSkillsAsync()
    {
        return await _context.Skills.OrderBy(s => s.Id).ToListAsync();
    }

    public bool SkillExist(int id)
    {
        return _context.Skills.Any(s => s.Id == id);
    }
}
