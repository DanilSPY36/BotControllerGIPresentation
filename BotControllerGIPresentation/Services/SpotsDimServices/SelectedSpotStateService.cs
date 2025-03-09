using SharedLibrary.DataTransferObjects;
using SharedLibrary.Models;
using System.ComponentModel;

namespace BotControllerGIPresentation.Services.SpotsDimServices
{
    public class SelectedSpotStateService : INotifyPropertyChanged
    {
        private UserDTO? UserDTO { get; set; }
        private List<UsersSpot>? usersSpots { get; set; } = new();
        private string selectedSpotName { get; set; } = string.Empty;

        public List<UsersSpot>? UsersSpots 
        {
            get => usersSpots;
            set 
            {
                if(usersSpots != value)
                {
                    usersSpots = value;
                    OnPropertyChanged(nameof(UsersSpots));
                }
            } 
        }

        public string SelectedSpotName
        {
            get => selectedSpotName;
            set
            {
                if (selectedSpotName != value)
                {
                    selectedSpotName = value;
                    OnPropertyChanged(nameof(SelectedSpotName));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
