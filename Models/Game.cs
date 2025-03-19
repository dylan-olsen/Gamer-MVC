namespace GamerInfoApp.Models
{
    public class Game
    {
        public int Id { get; set; }  // Primary Key
        public string Title { get; set; }  // Name of the game
        public DateTime ReleaseDate { get; set; }  // Release date of the game
        public decimal Price { get; set; }  // Price of the game

        // Navigation property (1 Game can have many Gameplays)
        public ICollection<Gameplay> Gameplays { get; set; }

    }
}
