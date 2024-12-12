using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public  class Game : BaseEntity
    {
        [MaxLength(32)]
        public string Title { get; set; }
        [MaxLength(64)]
        public string Description { get; set; }
        public string CoverImg { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public double SellPrice { get; set; }
        public double CostPrice { get; set; }
        public string GameId { get; set; }
    }
}
