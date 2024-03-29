
namespace Pathfinder_CharacterSheet.Repository
{
    public class IGameItemRepository : IIGameItemRepository
    {
        private readonly DataContext _context;

        public IGameItemRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateGameItem(IGameItem igameitem)
        {
            _context.Add(igameitem);
            return Save();
        }

        public bool DeleteGameItem(IGameItem igameitem)
        {
            _context.Remove(igameitem);
            return Save();
        }

        public ICollection<Character> GetCharactersbyGameItem(int gameitemid)
        {
            return _context.CharacterIGameItems.Where(g => g.GameItem.Id == gameitemid).Select(g => g.Character).ToList();
        }

        public ICollection<IGameItem> GetGameItem()
        {
            throw new NotImplementedException();
        }

        public IGameItem GetGameItem(int gameitemid)
        {
            return _context.IGameItems.Where(g => g.Id == gameitemid).FirstOrDefault();
        }

        public bool IGameItemExists(int gameitemid)
        {
            return _context.IGameItems.Any(g => g.Id == gameitemid);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateGameItem(IGameItem igameitem)
        {
            _context.Update(igameitem);
            return Save();
        }
    }
}
