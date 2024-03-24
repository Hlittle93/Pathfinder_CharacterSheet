using System;

public interface IIGameItemRepository
{
    ICollection<IGameItem> GetGameItem();
    IGameItem GetGameItem(int gameitemid);
    ICollection<Character> GetCharactersbyGameItem(int gameitemid);
    bool IGameItemExists(int gameitemid);
}
