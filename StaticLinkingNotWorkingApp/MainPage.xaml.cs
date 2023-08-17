namespace StaticLinkingNotWorkingApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
    void MovesenseBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            MovesenseLabel.Text = "Movesense service UUID: " + (Movesense.Constants.MovesenseServiceUUID?.ToString() ?? "(null)");
        }
        catch (Exception ex)
        {
            MovesenseLabel.Text = ex.GetType().Name + ": " + ex.Message;
        }
    }
}


