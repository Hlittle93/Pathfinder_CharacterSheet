public interface ISkillRepository
{
    ICollection<Skill> GetSkills();
    Skill GetSkill(int id);

    Skill GetSkill(string name);
    bool SkillExists(int skillid);
    bool CreateSkill(Skill skill);
    bool UpdateSpell(Skill skill);
    bool DeleteSkill(Skill skill);
    bool Save();
}