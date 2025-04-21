using PricePoint.Objects;

namespace PricePoint.Pages;

public partial class ComparisonPage : ContentPage
{
    private readonly LocalDbService _dbService;
    private readonly Restaurant _restaurant;
    private readonly Restaurant _restaurant2;

    public ComparisonPage(LocalDbService dbService, Restaurant restaurant, Restaurant restaurant1)
    {
        InitializeComponent();
        _dbService = dbService;
        _restaurant = restaurant;
        _restaurant2 = restaurant1;
        
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        RestaurantTitle.Text = $"{_restaurant.Name} Menu";

        var allItems = await _dbService.GetMenuItems();
        var filteredItems = allItems
            .Where(item => item.RestaurantId == _restaurant.RestaurantId)
            .ToList();

        MenuListView.ItemsSource = filteredItems;

        RestaurantTitle2.Text = $"{_restaurant2.Name} Menu";

        var allItems2 = await _dbService.GetMenuItems();
        var filteredItems2 = allItems2
            .Where(item => item.RestaurantId == _restaurant2.RestaurantId)
            .ToList();

        MenuListView2.ItemsSource = filteredItems2;
    }
}