using PricePoint.Objects;

namespace PricePoint.Pages
{
    public partial class MenuSelectionPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private readonly Restaurant _restaurant;

        public MenuSelectionPage(LocalDbService dbService, Restaurant restaurant)
        {
            InitializeComponent();
            _dbService = dbService;
            _restaurant = restaurant;
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
        }
    }
}