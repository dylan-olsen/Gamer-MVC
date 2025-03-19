namespace GamerInfoApp.Models
{
    public class Gamer
    {
        public int Id { get; set; }  // Primary Key
        public string Username { get; set; }  // Unique username
        public string Email { get; set; }  // Email address
        public int Score { get; set; }  // Overall score/rank of the gamer
       
        // Navigation property (1 Gamer can have many Gameplays)
        public ICollection<Gameplay> Gameplay { get; set; }

    }
}
