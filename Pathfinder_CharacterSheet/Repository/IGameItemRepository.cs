
namespace Pathfinder_CharacterSheet.Repository
{
    public class IGameItemRepository : IIGameItemRepository
    {
        private readonly DataContext _context;

        public IGameItemRepository(DataContext context)
        {
            _context = context;
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
    }
}
