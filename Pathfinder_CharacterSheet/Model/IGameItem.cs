public interface IGameItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    //public ICollection<CharacterGameItem> CharacterGameItems { get; set; }

}
public class Potion : IGameItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Effect { get; set; }
    
}

public class Weapon : IGameItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public int Damage { get; set; }
    
}

public class Armor : IGameItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public int ArmorBonus { get; set; }   
    public int MaxDex { get; set; }
    public int ArmorCheckPenality { get; set; }
    public double ArcaneSpellFail { get; set; }

}
public class Wand : IGameItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Spell { get; set; } 
    public int Charges { get; set; }   
}
public class Ring : IGameItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Effect { get; set; }
    public string Material { get; set; } 
}
public class Staff : IGameItem
{
    public int Id { get; set; }
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
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Spell { get; set; } 
    public int ScrollLevel { get; set; }   
}
public class Poison : IGameItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public double Weight { get; set; }
    public string Effects { get; set; } 
    public string Duration { get; set; } 
}

