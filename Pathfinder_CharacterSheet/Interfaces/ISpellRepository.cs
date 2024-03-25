public interface ISpellRepository
{
    ICollection<Spell> GetSpells();

    Spell GetSpell(int spellId);

    Spell GetSpellByCharacter(int characterId);

    bool SpellExists(int spellId);
    bool CreateSpell(Spell spell);
    bool Save();
}
