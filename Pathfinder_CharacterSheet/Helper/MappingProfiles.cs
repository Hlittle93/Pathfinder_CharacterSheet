using AutoMapper;
using Pathfinder_CharacterSheet.Dto;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterDto, Character>();
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>();
            CreateMap<Spell, SpellDto>();
            CreateMap<SpellDto, Spell>();
            CreateMap<IGameItem, GameItemDto>();
            CreateMap<GameItemDto, IGameItem>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
    }
}