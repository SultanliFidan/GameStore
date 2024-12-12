namespace GameStore.ViewModels.Games
{
    public class GameListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SellPrice { get; set; }
        public bool IsInStock { get; set; }
        public string CoverImage { get; set; }
        public string GameId { get; set; }
    }
}
