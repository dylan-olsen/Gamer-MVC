namespace GamerInfoApp.Models
{
    public class Gameplay
    {
        public int Id { get; set; }  // Primary Key

        // Foreign Keys
        public int GameId { get; set; }
        public Game Game { get; set; }  // Navigation Property

        public int GamerId { get; set; }
        public Gamer Gamer { get; set; }  // Navigation Property

    }
}
