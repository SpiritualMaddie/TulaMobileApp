namespace Tula;

public partial class SupportNeedsChat : ContentPage
{
	public SupportNeedsChat(UserInputViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        viewModel.ScrollMsgToBottomRequested += (s, e) => ScrollMsgToBottom();
    }

    private async void ScrollMsgToBottom()
    {
        await Task.Delay(100); // Allow time for the UI to update
        await TextMsgScrollView.ScrollToAsync(0, TextMsgScrollView.ContentSize.Height, true);
    }
}