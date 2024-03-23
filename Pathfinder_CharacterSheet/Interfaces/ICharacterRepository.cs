using System.Runtime.CompilerServices;

public interface ICharacterRepository
{
    ICollection<Character> GetCharacters();
    Character GetCharacter(int id);
    Character GetCharacter(string name);
    bool CharacterExists (int id);
}