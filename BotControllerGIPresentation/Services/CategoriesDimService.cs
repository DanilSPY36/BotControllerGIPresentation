using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices;
using SharedLibrary.Models;

namespace BotControllerGIPresentation.Services
{
    public class CategoriesDimService : GenericService<CategoriesDim>, ICategoriesDimService
    {
        public CategoriesDimService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
