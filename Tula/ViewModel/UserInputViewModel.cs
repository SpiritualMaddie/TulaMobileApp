using System.Collections.ObjectModel;
using Tula.Model;

namespace Tula.ViewModel
{
    public partial class UserInputViewModel : BaseViewModel
    {
        readonly MakeService makeService;
        readonly IConnectivity connectivity;
        public UserInputViewModel(MakeService makeService, IConnectivity connectivity)
        {
            this.makeService = makeService;
            this.connectivity = connectivity;
            Title = "Hantera användar-input";
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        bool isActive;

        [ObservableProperty]
        string? userTextInput;

        public ObservableCollection<ChatMessage> TextMessages { get; } = new();
        public event EventHandler? ScrollMsgToBottomRequested;

        [RelayCommand]
        public async Task SendUserMessageAsync()
        {
            if (IsBusy)
                return;
           
            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Oops!",
                        "Appen känner inte av någon internetanslutning, kolla så att ditt internet är påslaget.", "ok");
                    return;
                }

                IsBusy = true;

                if (string.IsNullOrEmpty(UserTextInput))
                {
                    await Shell.Current.DisplayAlert("Oops!", "Du måste fylla i något för att kunna skicka det 😉", "ok");
                    return;
                }

                await makeService.SendUserMessage(UserTextInput);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to send message. Exception: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "ok");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
            await Shell.Current.DisplayAlert("Yeey!", "Ditt meddelande är skickat!", "ok");

            if (!string.IsNullOrWhiteSpace(UserTextInput)) { }
                TextMessages.Add(new ChatMessage { Text = UserTextInput });

            UserTextInput = string.Empty;
            IsActive = true;
            OnScrollMsgToBottomRequested();
        }

        protected virtual void OnScrollMsgToBottomRequested()
        {
            ScrollMsgToBottomRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
