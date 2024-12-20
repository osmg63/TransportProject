using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using TransportProject.Service.Abstract;

namespace TransportProject.Service.Concrete
{
    public class S3Service:IS3Service
    {
        private readonly IAmazonS3 _s3;
        private readonly string _bucketName;

        public S3Service(IConfiguration configuration, IAmazonS3 s3)
        {
            _bucketName = configuration["AWS:BucketName"];
            _s3 = s3;
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file uploaded.");
            }

            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            try
            {
                using (var fileStream = file.OpenReadStream())
                {
                    if (fileStream == null)
                        throw new Exception("File stream is null.");

                    var fileTransferUtility = new TransferUtility(_s3);

                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = fileStream,
                        Key = fileName,
                        BucketName = _bucketName,
                        ContentType = file.ContentType
                    };

                    await fileTransferUtility.UploadAsync(uploadRequest);

                    return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error uploading file to S3", ex);
            }
        }

        public string GetFileUrl(string fileName)
        {
            return $"https://{_bucketName}.s3.{_s3.Config.RegionEndpoint.SystemName}.amazonaws.com/{fileName}";
        }

        // Dosyayı indirilebilir hale getirme
        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName
            };

            var response = await _s3.GetObjectAsync(request);
            return response.ResponseStream; // İndirilecek dosya içeriği
        }
    }
}
