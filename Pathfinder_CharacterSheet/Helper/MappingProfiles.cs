using AutoMapper;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
            CreateMap<CharacterDto, CharacterDto>();
    }
}