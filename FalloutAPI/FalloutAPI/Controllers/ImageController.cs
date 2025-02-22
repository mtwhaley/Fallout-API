using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace FalloutAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly string _imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");

        // Endpoint to get an image by filename
        [HttpGet("{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            // Construct the full path to the image
            var filePath = Path.Combine(_imageDirectory, imageName);

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Image not found.");
            }

            // Return the file with the appropriate MIME type
            return PhysicalFile(filePath, GetMimeType(filePath));
        }

        public string GetMimeType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            return extension switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream", // Default for unknown formats
            };
        }
    }
}