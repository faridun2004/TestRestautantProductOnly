using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestRestautantProductOnly.Model;
using TestRestautantProductOnly.Service;

namespace TestRestautantProductOnly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _dishService;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService dishService, IWebHostEnvironment environment, ILogger<ProductsController> logger)
        {
            _dishService = dishService;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var dishes = await _dishService.GetAllAsync();
            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var dish = await _dishService.GetByIdAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            return Ok(dish);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromForm] ProductCreateDto productDto)
        {
            if (productDto.ImageFile != null)
            {
                var imageUrl = await SaveImage(productDto.ImageFile);
                var product = new Product
                {
                    Name = productDto.Name,
                    Description = productDto.Description,
                    ImageUrl = imageUrl,
                    Price = productDto.Price
                };

                await _dishService.AddAsync(product);
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            return BadRequest("Image file is required.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromForm] ProductCreateDto productDto)
        {
            var existingDish = await _dishService.GetByIdAsync(id);
            if (existingDish == null)
            {
                return NotFound();
            }

            if (productDto.ImageFile != null)
            {
                var imageUrl = await SaveImage(productDto.ImageFile);
                existingDish.ImageUrl = imageUrl;
            }

            existingDish.Name = productDto.Name;
            existingDish.Description = productDto.Description;
            existingDish.Price = productDto.Price;

            await _dishService.UpdateAsync(existingDish);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _dishService.DeleteAsync(id);
            return NoContent();
        }

        private async Task<string> SaveImage(IFormFile imageFile)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return $"/uploads/{fileName}";
        }

        //private async Task<string> SaveImage(IFormFile imageFile)
        //{
        //    try
        //    {
        //        if (_environment.WebRootPath == null)
        //        {
        //            throw new InvalidOperationException("WebRootPath is not set.");
        //        }

        //        var uploads = Path.Combine(_environment.WebRootPath, "uploads");
        //        _logger.LogInformation("Uploads path: {UploadsPath}", uploads);

        //        if (!Directory.Exists(uploads))
        //        {
        //            Directory.CreateDirectory(uploads);
        //            _logger.LogInformation("Created directory: {UploadsPath}", uploads);
        //        }

        //        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
        //        var filePath = Path.Combine(uploads, fileName);
        //        _logger.LogInformation("File path: {FilePath}", filePath);

        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await imageFile.CopyToAsync(fileStream);
        //        }

        //        _logger.LogInformation("File saved successfully: {FilePath}", filePath);

        //        return $"/uploads/{fileName}";
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "An error occurred while saving the image");
        //        throw;
        //    }
        //}
    }
}
