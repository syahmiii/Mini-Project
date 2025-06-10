namespace Hospital_Management_System.Application.Product.Command
{
    public record SellProductCommandRequest
    {
        public int ProductId { get; init; }
        public int Quantity { get; init; }
    }

    public class SellProduct
    {
        private readonly HospitalDbContext _hospitalDbContext;

        public SellProduct(HospitalDbContext hospitalDbContext)
        {
            _hospitalDbContext = hospitalDbContext;
        }

        public async Task SellProductAsync(SellProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _hospitalDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken) ??
                throw new Exception("Product not found");

            if (product.StockQuantity < request.Quantity)
            {
                throw new Exception("Insufficient stock");
            }

            product.StockQuantity -= request.Quantity;

            _hospitalDbContext.Products.Update(product);
            await _hospitalDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
