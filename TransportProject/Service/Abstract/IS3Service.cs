namespace TransportProject.Service.Abstract
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile file);
        string GetFileUrl(string fileName);
        Task<Stream> DownloadFileAsync(string fileName);

    }
}
