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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Restaurant res = new Restaurant();
        Restaurant res2 = new Restaurant();
        res = await _dbService.GetRestaurantById(1);
        res2 = await _dbService.GetRestaurantById(2);
        Navigation.PushAsync(new ComparisonPage(_dbService, res, res2));
    }
}