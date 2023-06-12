using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureBlobStorage.Models;
using AzureBlobStorage.Services;

namespace AzureBlobStorage.Repository
{
	public class AzureStorage : IAzureStorage
	{
		private readonly string _connectionString;
		private readonly string _containerName;
		private readonly ILogger<AzureStorage> _logger;

		public AzureStorage(IConfiguration configuration, ILogger<AzureStorage> logger)
		{
			_connectionString = configuration.GetValue<string>("BlobConnectionString");
			_containerName = configuration.GetValue<string>("BlobContainerName");
			_logger = logger;
		}

		public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
		{
			BlobResponseDto response = new();
			BlobContainerClient container = new BlobContainerClient(_connectionString, _containerName);

			try
			{
				BlobClient client = container.GetBlobClient(blob.FileName);

				await using (Stream? data = blob.OpenReadStream())
				{
					await client.UploadAsync(data, overwrite: true);
					
				}

				response.Status = $"File {blob.FileName} Uploaded Successfully";
				response.Error = false;
				response.Blob.Uri = client.Uri.AbsoluteUri;
				response.Blob.Name = client.Name;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Unexpected Error. ID: {ex.StackTrace} - Message: {ex.Message}");
				response.Status = $"Unexpected Error: {ex.StackTrace}.";
				response.Error = true;
				return response;
			}
			return response;
		}

		public async Task<List<string>> GetAllDocuments()
		{
			var container = GetContainer();

			if (!await container.ExistsAsync())
			{
				return new List<string>();
			}

			List<string> blobs = new();

			await foreach (BlobItem blobItem in container.GetBlobsAsync())
			{
				blobs.Add(blobItem.Name);
			}
			return blobs;
		}


		public async Task<Stream> GetDocument(string fileName)
		{
			var container = GetContainer();
			if (await container.ExistsAsync())
			{
				var blobClient = container.GetBlobClient(fileName);
				if (blobClient.Exists())
				{
					var content = await blobClient.DownloadStreamingAsync();
					return content.Value.Content;
				}
				else
				{
					throw new FileNotFoundException();
				}
			}
			else
			{
				throw new FileNotFoundException();
			}

		}

		public async Task<bool> DeleteDocument(string fileName)
		{
			var container = GetContainer();
			if (!await container.ExistsAsync())
			{
				return false;
			}

			var blobClient = container.GetBlobClient(fileName);

			if (await blobClient.ExistsAsync())
			{
				await blobClient.DeleteIfExistsAsync();
				return true;
			}
			else
			{
				return false;
			}
		}
		private BlobContainerClient GetContainer()
		{
			BlobServiceClient blobServiceClient = new(_connectionString);
			return blobServiceClient.GetBlobContainerClient(_containerName);
		}
	}
}