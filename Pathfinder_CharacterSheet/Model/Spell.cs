public class Spell
{
    public string Name { get; set; }
    public string School { get; set; }
    public int Level { get; set; }
    public CastingTime CastingTime { get; set; }
    public string Components { get; set; }
    public SpellRange Range { get; set; }
    public string Effect { get; set; }
    public bool SavingThrow { get; set; }
    public bool SpellResistance { get; set; }
    public bool Known {  get; set; }
    public bool Prepared { get; set; }
    public enum CastingTime
    {
        StandardAction,
        FullRoundAction,
        OneRound,
        TenMinutes,
        Onehour,
        Varies
    }
    public enum SpellRange
    {
        Personal,
        Touch,
        Close,
        Medium,
        Long,
        Unlimited,
        Special
    }
    public enum SpellDuration
    {
        Instantaneous,
        Rounds,
        Minutes,
        Hours,
        Permanent,
    }

}
