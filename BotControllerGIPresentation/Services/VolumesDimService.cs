using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices;
using SharedLibrary.Models;

namespace BotControllerGIPresentation.Services
{
    public class VolumesDimService : GenericService<VolumesDim>, IVolumesDimService
    {
        public VolumesDimService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
