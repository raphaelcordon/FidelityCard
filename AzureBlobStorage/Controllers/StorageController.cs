using Microsoft.AspNetCore.Mvc;
using AzureBlobStorage.Services;
using AzureBlobStorage.Models;

namespace AzureBlobStorage.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class StorageController : ControllerBase
	{
        private readonly IAzureStorage _storage;
        public StorageController(IAzureStorage storage)
        {
            _storage = storage;
        }

		[HttpGet]
		public async Task<List<string>> ListFiles()
		{
			return await _storage.GetAllDocuments();
		}

		[HttpPost]
		public async Task<IActionResult> Upload(IFormFile file)
		{
			BlobResponseDto? response = await _storage.UploadAsync(file);

			if (response.Error == true)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, response.Status);
			}
			else
			{
				return StatusCode(StatusCodes.Status200OK, response);
			}
		}

		[HttpGet("/{fileName}")]
		public async Task<IActionResult> DownloadFile(string fileName)
		{
			var content = await _storage.GetDocument(fileName);
			return File(content, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
		}


		[HttpGet("Delete/{fileName}")]
        public async Task<bool> DeleteFile(string fileName)
		{
			return await _storage.DeleteDocument(fileName);
		}
	}
}