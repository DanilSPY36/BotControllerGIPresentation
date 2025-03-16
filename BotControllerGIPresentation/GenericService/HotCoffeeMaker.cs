using BCrypt.Net;
using Blazor.SubtleCrypto;
using BotControllerGIPresentation.IServices.IUserServices;
using BotControllerGIPresentation.Services.UserServices;
using Microsoft.JSInterop;
using SharedLibrary.DataTransferObjects;
using SharedLibrary.Models;
using System.Text.Json;

namespace BotControllerGIPresentation.GenericService
{
    public class HotCoffeeMaker<Temp> : IHotCoffeeMaker<Temp> where Temp : class
    {
        /// <summary>
        /// метод который добавляет авторизованому пользователю ключ в бд 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cryptoService"></param>
        /// <param name="LocalStorageServiceTest"></param>
        /// <param name="jsRuntime"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> SetHotCoffe(IHotcoffeeService service, ICryptoService cryptoService, ILocalStorageGenericService<string> LocalStorageServiceTest, IJSRuntime jsRuntime, UserLoginDto item) 
        {
            try
            {
                var encryptedUser = await cryptoService.EncryptAsync(item);
                var Coffe = new Hotcoffee()
                {
                    CoffeeName = encryptedUser.Secret.Key,
                    UserId = item.Id
                };
                var resultCoffe = await service.AddAsync(Coffe);
                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// метод который шифрует затем  добавляет item в localStorage
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cryptoService"></param>
        /// <param name="LocalStorageServiceTest"></param>
        /// <param name="jsRuntime"></param>
        /// <param name="item"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public async Task<bool> MakeHotCoffe(IHotcoffeeService service, ILocalStorageGenericService<string> LocalStorageServiceTest, IJSRuntime jsRuntime, Temp item, int userId, string keyName = "hotCoffee")
        {
            try
            {
               
                var keyFromDb = await service.GetHotCoffeeByUserId(userId);
                var options = new CryptoOptions() { Key = keyFromDb.CoffeeName };
                var crypto = new CryptoService(jsRuntime, options);
                var encryptedItem = await crypto.EncryptAsync(item); // кодирум объект 
                var newInput = new CryptoInput { Value = encryptedItem.Value += "=" + keyFromDb.Id, Key = keyFromDb.CoffeeName };

                await LocalStorageServiceTest.SetNewItemInLocalStorage(jsRuntime, keyName, newInput.Value);// добавлям значение в сторедж
                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// метод дешифрования объекта из localStrage
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cryptoService"></param>
        /// <param name="LocalStorageServiceTest"></param>
        /// <param name="jsRuntime"></param>
        /// <param name="item"></param>
        /// <param name="userId"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public async Task<Temp> MakeColdCoffe(IHotcoffeeService service, ILocalStorageGenericService<string> LocalStorageServiceTest, IJSRuntime jsRuntime, int userId, string keyName = "hotCoffee")
        {
            try
            {
                var infoFromStorage = await LocalStorageServiceTest.GetItemFromLocalStorage(jsRuntime, keyName);
                int index = infoFromStorage.LastIndexOf('=');

                if (index != -1 && index + 1 < infoFromStorage.Length)
                {
                    string idString = infoFromStorage.Substring(index + 1);
                    if (int.TryParse(idString, out int id))
                    {
                        var key = await service.GetByIDAsync(id);
                        string modifiedString = infoFromStorage.Substring(0, index);
                        var crypto = new CryptoService(jsRuntime, new CryptoOptions());
                        var decryptedUser = await crypto.DecryptAsync(new CryptoInput { Value = modifiedString, Key = key.CoffeeName });

                        // Проверяем результат дешифрования
                        if (string.IsNullOrEmpty(decryptedUser))
                        {
                            Console.WriteLine("Дешифрование вернуло пустую строку.");
                            return null!;
                        }

                        var objectUserClass = JsonSerializer.Deserialize<Temp>(decryptedUser);

                        // Проверяем результат десериализации
                        if (objectUserClass == null)
                        {
                            Console.WriteLine("Не удалось десериализовать объект Temp.");
                            return null!;
                        }

                        return objectUserClass;
                    }
                    else
                    {
                        Console.WriteLine("Не удалось преобразовать id в число.");
                    }
                }
                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return null!;
            }
        }
        public async Task Clear(IHotcoffeeService service, ILocalStorageGenericService<Temp> LocalStorageServiceTest, IJSRuntime jsRuntime, UserDTO authUserDto) 
        {
            await LocalStorageServiceTest.ClearLocalStorage(jsRuntime);
            await service.DelAllItemsByUserId(authUserDto.id);
        }
    }
}
