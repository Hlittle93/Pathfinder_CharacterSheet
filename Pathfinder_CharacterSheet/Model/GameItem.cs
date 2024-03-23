public interface IGameItem
{
    string Name { get; set; }
    string Description { get; set; }
    int Cost { get; set; }
    double Weight { get; set; }
    //public ICollection<CharacterGameItem> CharacterGameItems { get; set; }

}
public class Potion : IGameItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Effect { get; set; }
    
}

public class Weapon : IGameItem
{
    int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public int Damage { get; set; }
    
}

public interface Armor: IGameItem
{
    string Name { get; set; }
    string Description { get; set; }
    int Cost { get; set; }
    double Weight { get; set; }
    int ArmorBonus { get; set; }   
    int MaxDex { get; set; }
    int ArmorCheckPenality { get; set; }
    double ArcaneSpellFail { get; set; }

}
public class Wand : IGameItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Spell { get; set; } 
    public int Charges { get; set; }   
}
public class Ring : IGameItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Effect { get; set; }
    public string Material { get; set; } 
}
public class Staff : IGameItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Spell { get; set; } 
    public int Charges { get; set; }   
    public int Length { get; set; }    
}

public class Scroll : IGameItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Spell { get; set; } 
    public int ScrollLevel { get; set; }   
}
public class Poison : IGameItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Effects { get; set; } 
    public string Duration { get; set; } 
}

