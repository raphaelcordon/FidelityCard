namespace WebAppMain.Services
{
    public interface IBlobStorageApi
    {
        Task PostFile(IFormFile file);
    }
}