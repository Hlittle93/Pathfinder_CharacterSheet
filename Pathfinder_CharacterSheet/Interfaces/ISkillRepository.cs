public interface ISkillRepository
{
    ICollection<Skill> GetSkills();
    Skill GetSkill(int id);

    Skill GetSkill(string name);
    bool SkillExists(int skillid);
}