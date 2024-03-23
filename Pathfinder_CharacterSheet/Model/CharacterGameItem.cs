public class CharacterGameItem
{
    public int CharacterId { get; set; }
    public int GameItemId { get; set; }
    public Character Character { get; set; }
    public IGameItem GameItem {  get; set; } 
}