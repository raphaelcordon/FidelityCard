using Microsoft.AspNetCore.Mvc;
using WebAppMain.Models;
using WebAppMain.Services;

namespace WebAppMain.Controllers
{
	public class CampaignController : Controller
	{
		private readonly IBlobStorageApi _blobStorage;
      
        public CampaignController(IBlobStorageApi blobStorage)
        {
			_blobStorage = blobStorage;
		}
		public IActionResult MainCampaign()
		{
            return View();
		}

        [HttpPost("FileUpload")]
        public async Task<IActionResult> FileUpload([FromForm(Name = "file")] IFormFile file)
        {
           await _blobStorage.PostFile(file);
           return RedirectToAction("Index", "Home");
        }
    }
}