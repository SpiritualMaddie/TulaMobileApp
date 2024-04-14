namespace Tula.Services
{
    public class MakeService
    {
        HttpClient httpClient;
        readonly string webhookUrl = "https://hook.eu2.make.com/tlv7umftm1h12f4njultj96zgpqnpuvk";

        public MakeService()
        {
            httpClient = new HttpClient();
        }

        public async Task SendUserMessage(string userTextInput)
        {
            var payload = new
            {
                Text = userTextInput
            };
            var jsonData = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            await httpClient.PostAsync(webhookUrl, content);
        }
    }
}
