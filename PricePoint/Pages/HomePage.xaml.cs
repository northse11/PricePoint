using PricePoint.Objects;

namespace PricePoint.Pages;

public partial class HomePage : ContentPage
{
    private readonly LocalDbService _dbService;
    private List<Restaurant> _allRestaurants = new();
    private List<Restaurant> selectedRestaurants = new();
    public HomePage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        LoadData();
    }
    private async void LoadData()
    {
        // Load all restaurants from SQLite
        _allRestaurants = await _dbService.GetRestaurants();

        // Extract distinct categories from restaurants (group by Type)
        var categories = _allRestaurants
            .GroupBy(r => r.Type)
            .Select(g => new Restaurant
            {
                Type = g.Key // Use Type as the category
            })
            .ToList();

        // Bind the categories to the top CollectionView
        Cv.ItemsSource = categories;

        // Show all restaurants initially in the second CollectionView
        CvResturants.ItemsSource = _allRestaurants;
    }


    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        if (sender is VisualElement view && view.BindingContext is Restaurant tappedCategory)
        {
            // Filter the restaurants based on the tapped category
            var filtered = _allRestaurants
                .Where(r => r.Type == tappedCategory.Type)
                .ToList();

            // Update the second CollectionView with the filtered list
            CvResturants.ItemsSource = filtered;
        }
    }

    private void Cv_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Restaurant selectedCategory)
        {
            var filtered = _allRestaurants
                .Where(r => r.Type == selectedCategory.Type)
                .ToList();

            CvResturants.ItemsSource = filtered;
        }
    }

    private void CvResturants_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Get the newly selected and deselected items
        var newlySelected = e.CurrentSelection;
        var newlyDeselected = e.PreviousSelection;

        // Remove deselected items from the selected list
        foreach (var item in newlyDeselected)
        {
            if (item is Restaurant deselectedRestaurant)
            {
                selectedRestaurants.Remove(deselectedRestaurant);
            }
        }

        // Add newly selected items to the selected list
        foreach (var item in newlySelected)
        {
            if (item is Restaurant selectedRestaurant)
            {
                selectedRestaurants.Add(selectedRestaurant);
            }
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (selectedRestaurants.Count > 1)
        {
            Navigation.PushAsync(new ComparisonPage(_dbService, selectedRestaurants));
        }
    }
}