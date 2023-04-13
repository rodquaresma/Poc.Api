namespace PocApi.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; } = default!;
    }
}
