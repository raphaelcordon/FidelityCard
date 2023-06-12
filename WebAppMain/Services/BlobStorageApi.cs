using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebAppMain.Models;

namespace WebAppMain.Services
{
    public class BlobStorageApi : IBlobStorageApi
    {
        string baseUrl = "https://localhost:7187/api/Storage";
        private readonly IHttpClientFactory _clientFactory;

        public BlobStorageApi(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }



        public async Task PostFile(IFormFile file)
        {
            
            
            var client = _clientFactory.CreateClient();

            if (file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    //Build an multipart/form-data request to upload the file
                    using var form = new MultipartFormDataContent();
                    using var fileContent = new ByteArrayContent(memoryStream.ToArray());
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    form.Add(fileContent, "file", Guid.NewGuid().ToString() + ".jpeg");

                    var response = await client.PostAsync(baseUrl, form);

                    response.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<FileUpload>(await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
