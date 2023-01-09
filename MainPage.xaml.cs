namespace Georgita_Frunza_Proiect;

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
			CounterBtn.Text = $"Burned {count} calorie";
		else
			CounterBtn.Text = $"Burned {count} calories";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

