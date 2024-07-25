namespace TestRestautantProductOnly.Model
{
    public class UserCreateDto
    {
        public string? Name { get; set; }
        public IFormFile PhotoUrl { get; set; }
    }
}
