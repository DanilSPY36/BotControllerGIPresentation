using BotControllerGIPresentation.IServices;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BotControllerGIPresentation.Services
{
    public class UploadService : IUploadService
    {
        private readonly HttpClient _httpClient;

        public UploadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> PhotoForTTkUpload(Radzen.FileInfo UploadFile)
        {
            using (var fileForm = new MultipartFormDataContent())
            {
                var fileContent = new StreamContent(UploadFile.OpenReadStream());
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                fileForm.Add(fileContent, "file", UploadFile.Name);
                var response = await _httpClient.PostAsync($"/api/UploadFiles/PhotoForTTkUpload", fileForm);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"Ошибка при загрузке файла: {response.ReasonPhrase}");
                    return "Error Upload";
                }
            }
        }

        public async Task<byte[]> UploadPhotoFromServerToCLient(string photoPath)
        {
            string jsonContent = JsonConvert.SerializeObject(photoPath);
            var stringContent = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync($"/api/UploadFiles/GetPhotoPath", stringContent);
            if (result.IsSuccessStatusCode)
            {
                var fileBytes = await result.Content.ReadAsByteArrayAsync();

                // Определение пути для сохранения файла
                var fileName = Path.GetFileName(photoPath);
                var destinationPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);

                return fileBytes;
            }
            else
            {
                Console.WriteLine("Error Service ClientSide. Return empty enumerable");
                return null!;
            }
        }
        public async Task<bool> DeleteOldPhoto(string oldPhotoPath)
        {
            string jsonContent = JsonConvert.SerializeObject(oldPhotoPath);
            var stringContent = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync($"/api/UploadFiles/DeleteOldPhoto", stringContent);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error Service ClientSide. Return empty enumerable");
                return false;
            }
        }
    }
}
