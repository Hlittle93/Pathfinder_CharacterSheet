using System;

public interface IIGameItemRepository
{
    ICollection<IGameItem> GetGameItem();
    IGameItem GetGameItem(int gameitemid);
    ICollection<Character> GetCharactersbyGameItem(int gameitemid);
    bool IGameItemExists(int gameitemid);
    bool CreateGameItem(IGameItem igameitem);
    bool UpdateGameItem(IGameItem igameitem);
    bool DeleteGameItem(IGameItem igameitem);
    bool Save();
}


