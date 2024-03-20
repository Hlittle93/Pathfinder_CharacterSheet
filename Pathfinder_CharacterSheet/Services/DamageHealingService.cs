public class DamageHealingService
{
    public int TakeDamage(int currentHitPoints, int damage)
    {
        int newHitPoints = Math.Max(0, currentHitPoints - damage);
        return newHitPoints;
    }

    public int Heal(int currentHitPoints, int healing, string characterName)
    {
        int newHitPoints = Math.Min(currentHitPoints + healing, maxHitPoints);

        // EasterEgg with my Daughter's name
        if (characterName.Contains("Nora", StringComparison.OrdinalIgnoreCase) ||
            characterName.Contains("Eloise", StringComparison.OrdinalIgnoreCase))
        {
            newHitPoints += 1;
        }

        return newHitPoints;
    }
}
