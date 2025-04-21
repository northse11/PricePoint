using PricePoint.Objects;
using PricePoint.Pages;

namespace PricePoint.Pages
{
    public partial class RestaurantSelectionPage : ContentPage
    {
        private readonly LocalDbService _dbService;

        public RestaurantSelectionPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var restaurants = await _dbService.GetRestaurants();
            RestaurantListView.ItemsSource = restaurants;
        }

        private async void OnRestaurantSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem is Restaurant selectedRestaurant)
            {
                await Navigation.PushAsync(new MenuSelectionPage(_dbService, selectedRestaurant));
            }
        }
    }
}
