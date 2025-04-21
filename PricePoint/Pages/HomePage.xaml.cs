
using PricePoint.Objects;

namespace PricePoint.Pages;

public partial class HomePage : ContentPage
{
	LocalDbService _dbService;
	public HomePage(LocalDbService dbService)
	{
		InitializeComponent();
		_dbService = dbService;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		var list = await _dbService.GetMenuItems();
		Lv.ItemsSource = list;
        var list2 = await _dbService.GetRestaurants();
        Cv.ItemsSource = list2;
    }

    private async void OnSelectRestaurant(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RestaurantSelectionPage(_dbService));
    }
}