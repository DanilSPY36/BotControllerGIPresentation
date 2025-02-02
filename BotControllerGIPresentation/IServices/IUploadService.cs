namespace BotControllerGIPresentation.IServices
{
    public interface IUploadService
    {
        Task<string> PhotoForTTkUpload(Radzen.FileInfo UploadFile);
        Task<byte[]> UploadPhotoFromServerToCLient(string photoPath);
        Task<bool> DeleteOldPhoto(string oldPhotoPath);
    }
}
