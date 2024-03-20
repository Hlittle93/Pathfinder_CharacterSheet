public class User 
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Character> Characters { get; set; }  
}
