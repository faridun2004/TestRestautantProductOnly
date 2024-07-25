using Microsoft.AspNetCore.Mvc;
using TestRestautantProductOnly.Model;
using TestRestautantProductOnly.Service;

namespace TestRestautantProductOnly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IWebHostEnvironment environment, ILogger<UserController> logger)
        {
            _userService = userService;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Users>> PostUser([FromForm] UserCreateDto userCreateDto)
        {
            if (userCreateDto.PhotoUrl != null)
            {
                var photoUrl = await SaveImage(userCreateDto.PhotoUrl);
                var user = new Users
                {
                    Name = userCreateDto.Name,
                    Photo = photoUrl,
                };

                await _userService.AddAsync(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            return BadRequest("Image file is required.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromForm] UserCreateDto userCreateDto)
        {
            var existingDish = await _userService.GetByIdAsync(id);
            if (existingDish == null)
            {
                return NotFound();
            }

            if (userCreateDto.PhotoUrl != null)
            {
                var imageUrl = await SaveImage(userCreateDto.PhotoUrl);
                existingDish.Photo = imageUrl;
            }

            existingDish.Name = userCreateDto.Name;

            await _userService.UpdateAsync(existingDish);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        private async Task<string> SaveImage(IFormFile photoFile)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photoFile.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await photoFile.CopyToAsync(fileStream);
            }

            return $"/uploads/users/{fileName}";
        }
    }
}
