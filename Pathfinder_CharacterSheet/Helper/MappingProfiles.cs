using AutoMapper;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
            CreateMap<CharacterDto, CharacterDto>();
            CreateMap<SkillDto, SkillDto>();
            CreateMap<SpellDto, SpellDto>();
    }
}