using AzureBlobStorage.Models;

namespace AzureBlobStorage.Services
{
	public interface IAzureStorage
	{
		/// <summary>
		/// This method uploads a file submitted with the request
		/// </summary>
		/// <param name="file">File for upload</param>
		/// <returns>Blob with status</returns>
		/// 

		Task<BlobResponseDto> UploadAsync(IFormFile file);
		//Task UploadDocument(string fileName, Stream fileContent);
		Task<List<string>> GetAllDocuments();
		Task<Stream> GetDocument(string fileName);

		Task<bool> DeleteDocument(string fileName);
	}
}
