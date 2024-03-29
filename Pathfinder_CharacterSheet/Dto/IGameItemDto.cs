namespace Pathfinder_CharacterSheet.Dto
{

        public class GameItemDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Cost { get; set; }
            public double Weight { get; set; }

        }
        public class PotionDto : GameItemDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Cost { get; set; }
            public double Weight { get; set; }
            public string Effect { get; set; }

        }

        public class WeaponDto : GameItemDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Cost { get; set; }
            public double Weight { get; set; }
            public int Damage { get; set; }

        }

        public class ArmorDto : GameItemDto
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
        public class WandDto : GameItemDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Cost { get; set; }
            public double Weight { get; set; }
            public string Spell { get; set; }
            public int Charges { get; set; }
        }
        public class RingDto : GameItemDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Cost { get; set; }
            public double Weight { get; set; }
            public string Effect { get; set; }
            public string Material { get; set; }
        }
        public class StaffDto : GameItemDto
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

        public class ScrollDto : GameItemDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Cost { get; set; }
            public double Weight { get; set; }
            public string Spell { get; set; }
            public int ScrollLevel { get; set; }
        }
        public class PoisonDto : GameItemDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Cost { get; set; }
            public double Weight { get; set; }
            public string Effects { get; set; }
            public string Duration { get; set; }
        }

    }

