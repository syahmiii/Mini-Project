namespace Hospital_Management_System.Domain.DatabaseEntities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; } = 0.0m;
        public int StockQuantity { get; set; } = 0;
    }
}
