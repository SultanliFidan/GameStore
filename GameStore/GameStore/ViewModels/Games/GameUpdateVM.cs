using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModels.Games
{
    public class GameUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double CostPrice { get; set; }
        public double SellPrice { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public string? FileUrl { get; set; }
        public string GameId { get; set; }

        public IFormFile File { get; set; }
        
    }
}
