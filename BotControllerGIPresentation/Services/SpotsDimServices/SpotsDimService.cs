using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices.ISpotsDimServices;
using SharedLibrary.Models;

namespace BotControllerGIPresentation.Services.SpotsDimServices
{
    public class SpotsDimService : GenericService<SpotsDim>, ISpotsDimService
    {
        public SpotsDimService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
