using Microsoft.EntityFrameworkCore;

public class SkillRepository : ISkillRepository
{
    private DataContext _context;
    public SkillRepository(DataContext context)
    {
        _context = context;
    }

    public bool CreateSkill(Skill skill)
    {
        _context.Add(skill);

        return Save();
    }

    public bool DeleteSkill(Skill skill)
    {
        _context.Remove(skill);
        return Save();
    }

    public Skill GetSkill(int id)
    {
        return _context.Skills.Where(e => e.Id == id).FirstOrDefault();
    }

    public Skill GetSkill(string name)
    {
        return _context.Skills.Where(s => s.Name == name).FirstOrDefault();
    }

    public ICollection<Skill> GetSkills()
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Skill>> GetSkillsAsync()
    {
        return await _context.Skills.OrderBy(s => s.Id).ToListAsync();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true: false;
    }

    public bool SkillExist(int id)
    {
        return _context.Skills.Any(s => s.Id == id);
    }

    public bool SkillExists(int skillid)
    {
        return _context.Skills.Any(s => s.Id == skillid);
    }

    public bool UpdateSpell(Skill skill)
    {
        _context.Update(skill);
        return Save();
    }
}
