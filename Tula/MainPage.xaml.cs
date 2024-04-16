namespace Tula
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnOpenLinkGPT(object sender, EventArgs e)
        {
            await OpenLinkAsync();
        }
        public async Task OpenLinkAsync()
        {
            string url = "https://chat.openai.com/g/g-I8IVwAWLH-tyddliggor-stodbehov-hos-autism-adhd";
            try
            {
                await Launcher.OpenAsync(url);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
            }
        }
    }

}
