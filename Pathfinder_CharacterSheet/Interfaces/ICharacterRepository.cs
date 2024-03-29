using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

public interface ICharacterRepository
{
    ICollection<Character> GetCharacters();
    Character GetCharacter(int id);
    Character GetCharacter(string name);
    bool CharacterExists (int id);
    bool CreateCharacter(int skillid, int spellid, int gameitemid,Character character);
    bool UpdateCharacter(int skillid, int spellid, int gameitemid, Character character);
    bool DeleteCharacter(Character character);
    bool Save();
}