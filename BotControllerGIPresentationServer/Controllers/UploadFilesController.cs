using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotControllerGIPresentationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFilesController : ControllerBase
    {

        [HttpPost("PhotoForTTkUpload")]
        public async Task<IActionResult> PhotoForTTkUpload()
        {
            if (!Request.HasFormContentType || Request.Form.Files.Count == 0)
            {
                return BadRequest("Нет файлов для загрузки.");
            }

            var file = Request.Form.Files[0]; // Получаем первый файл из запроса

            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadImages");
            var filePath = Path.Combine(uploadsFolderPath, file.FileName);

            try
            {
                // Создание папки, если она не существует
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                // Сохранение файла
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return Ok(filePath);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при загрузке файла: {ex.Message}");
            }
        }

        [HttpPost("GetPhotoPath")]
        public async Task<IActionResult> GetPhotoPath([FromBody] string photoPath)
        {
            // Извлечение имени файла из полного пути
            var fileName = Path.GetFileName(photoPath);
            try
            {
                if (System.IO.File.Exists(photoPath))
                {
                    // Чтение файла в массив байтов
                    var fileBytes = await System.IO.File.ReadAllBytesAsync(photoPath);

                    // Отправка файла на клиентскую часть
                    return File(fileBytes, "application/octet-stream", fileName);
                }
                else
                {
                    return NotFound("Файл не найден");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при копировании файла: {ex.Message}");
            }
        }


        [HttpPost("DeleteOldPhoto")]
        public async Task<IActionResult> DeleteOldPhoto([FromBody] string oldPhotoPath)
        {
            return await Task.Run(() => 
            {
                try
                {
                    if (System.IO.File.Exists(oldPhotoPath))
                    {
                        System.IO.File.Delete(oldPhotoPath);
                        return Ok("Файл успешно удален.");
                    }
                    else
                    {
                        return NotFound("Файл не найден.");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Ошибка при удалении файла: {ex.Message}");
                }
            });
        }
    }
}
