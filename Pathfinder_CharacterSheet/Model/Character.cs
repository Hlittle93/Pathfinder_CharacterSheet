public class Character
    {
        public int CharacterId { get; set; }
        public User user { get; set; } 
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string HitPoints { get; set; }
        public int MaxHitpoints { get; set; }
        public IEnumerable<IGameItem> Inventory { get; set; }
        public Spell Spell { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        
    public int Skill { get; set; }
    }

}

