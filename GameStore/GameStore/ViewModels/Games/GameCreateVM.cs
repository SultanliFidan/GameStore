using GameStore.Models;
using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModels.Games
{
    public class GameCreateVM
    {
        [MaxLength(32)]
        public string Title { get; set; }
        [MaxLength(64)]
        public string Description { get; set; }
        
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public double SellPrice { get; set; }
        public double CostPrice { get; set; }
        public string GameId { get; set; }

        public IFormFile File { get; set; }
        public static implicit operator Game(GameCreateVM vm)
        {
            return new Game
            {
                GameId = vm.GameId,
                CostPrice = vm.CostPrice,
                Description = vm.Description,
                Title = vm.Title,
                Quantity = vm.Quantity,
                SellPrice = vm.SellPrice
            };
        }
    }
}
