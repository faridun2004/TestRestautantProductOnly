namespace TestRestautantProductOnly.Model
{
    public class ProductCreateDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
