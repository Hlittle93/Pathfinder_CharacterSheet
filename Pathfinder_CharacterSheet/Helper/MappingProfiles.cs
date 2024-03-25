using AutoMapper;
using Pathfinder_CharacterSheet.Dto;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
            CreateMap<Character, CharacterDto>();
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>();
            CreateMap<Spell, SpellDto>();
            CreateMap<SpellDto, Spell>();
            CreateMap<IGameItem, IGameItemDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
    }
}