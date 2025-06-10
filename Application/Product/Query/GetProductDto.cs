namespace Hospital_Management_System.Application.Product.Query
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; } = 0.0m;
        public int StockQuantity { get; set; } = 0;

    }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.DatabaseEntities.Product, GetProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.StockQuantity));
        }
    }
}
