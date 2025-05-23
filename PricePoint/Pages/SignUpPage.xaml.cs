using PricePoint.Objects;
using System.Text.RegularExpressions;

namespace PricePoint.Pages;

public partial class SignUpPage : ContentPage
{
    private readonly LocalDbService _dbService;
	public SignUpPage(LocalDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
	}

    private async void btnSignup_Clicked(object sender, EventArgs e)
    {
        List<Objects.MenuItem> list = new List<Objects.MenuItem>();
        list = await _dbService.GetMenuItems();

        List<User> users = new List<User>();
        users = await _dbService.GetUsers();
        int i = 0;
        if (String.IsNullOrWhiteSpace(entryUsername.Text) || String.IsNullOrWhiteSpace(entryPassword.Text))
        {
            DisplayAlert("Error", "All fields are required", "Ok");
        }
        else
        {
            foreach (User user in users)
            {
                if (user.Username.Equals(entryUsername.Text))
                {
                    i = 1;
                }
            }
            if (i == 0)
            {
                User newUser = new User();
                newUser.Username = entryUsername.Text;
                newUser.Password = entryPassword.Text;
                await _dbService.CreateUser(newUser);
                entryPassword.Text = "";
                entryUsername.Text = "";
                Navigation.PushAsync(new HomePage(_dbService));
            }
            else
            {
                await DisplayAlert("Error", "Username already in use", "Ok");
            }
        }
        
    }
}