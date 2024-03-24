namespace Pathfinder_CharacterSheet.Interfaces
{
    public interface IUserRepository
    {
       ICollection<User> GetUsers();
        User GetUser(int userid);
        ICollection<User> GetCharactersOfAUser(int charid);
        public bool UserExists (int userid);
    }
}
