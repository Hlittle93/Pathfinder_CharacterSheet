public class Character
    {
        public int Id { get; set; }
        public User user { get; set; } 
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public string HitPoints { get; set; }
        public int MaxHitpoints { get; set; }
        public ICollection<CharacterGameItem> CharacterGameItems { get; set; }
        public ICollection<CharacterSpell> CharacterSpells { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public ICollection<CharacterSkill> CharacterSkills { get; set; }

}

