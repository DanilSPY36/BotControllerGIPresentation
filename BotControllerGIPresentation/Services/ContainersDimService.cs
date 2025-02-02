using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices;
using SharedLibrary.Models;

namespace BotControllerGIPresentation.Services
{
    public class ContainersDimService : GenericService<ContainersDim>, IContainersDimService
    {
        public ContainersDimService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
