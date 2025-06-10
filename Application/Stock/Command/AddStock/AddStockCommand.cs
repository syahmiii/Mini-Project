namespace Hospital_Management_System.Application.Stock.Command.AddStock
{
    public record AddStockCommandRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class AddStockCommand
    {
        private readonly HospitalDbContext _HospitalDbContext;

        public AddStockCommand(HospitalDbContext hospitalDbContext)
        {
            _HospitalDbContext = hospitalDbContext;
        }

        public async Task AddStock(AddStockCommandRequest request, CancellationToken cancellationToken)
        {

            var product = await _HospitalDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken) ??
                throw new Exception("Product not found");

            product.StockQuantity += request.Quantity;

            _HospitalDbContext.Products.Update(product);
            await _HospitalDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
