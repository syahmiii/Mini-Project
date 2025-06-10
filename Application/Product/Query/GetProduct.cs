namespace Hospital_Management_System.Application.Product.Query
{
    public record GetProductQuery : IRequest<GetProductDto>
    {
        public int ProductId { get; init; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
        private readonly HospitalDbContext _hospitalDbContext;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(HospitalDbContext hospitalDbContext, IMapper mapper)
        {
            _hospitalDbContext = hospitalDbContext;
            _mapper = mapper;
        }

        public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            Domain.DatabaseEntities.Product product = await _hospitalDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken) ??
                throw new Exception("Product not found");

            return _mapper.Map<GetProductDto>(product);
        }
    }
}
