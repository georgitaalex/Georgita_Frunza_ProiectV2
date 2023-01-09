using Georgita_Frunza_Proiect.Models;

namespace Georgita_Frunza_Proiect;

public partial class SportPage : ContentPage
{
    SSList sl;
    public SportPage(SSList slist)
    {
        InitializeComponent();
        sl = slist;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Sport)BindingContext;
        await App.Database.SaveSportAsync(product);
        listView.ItemsSource = await App.Database.GetSportsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Sport)BindingContext;
        await App.Database.DeleteSportAsync(product);
        listView.ItemsSource = await App.Database.GetSportsAsync();
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetSportsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Sport p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Sport;
            var lp = new ListSport()
            {
                SSListID = sl.ID,
                SportID = p.ID
            };
            await App.Database.SaveListSportAsync(lp);
            p.ListSports = new List<ListSport> { lp };
            await Navigation.PopAsync();
        }

    }
}