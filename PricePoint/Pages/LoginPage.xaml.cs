using PricePoint.Objects;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace PricePoint.Pages;

public partial class LoginPage : ContentPage
{
	private readonly LocalDbService _dbService;
    public LoginPage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        List<User> users = new List<User>();
        users = await _dbService.GetUsers();
        User checkUser = null;
        foreach (User user in users)
        {
            if (user.Username == entryUsername.Text)
            {
                checkUser = user;
            }
        }
        if (checkUser == null) 
        {
            await DisplayAlert("Error", "Username not found", "Ok");
        }
        else if (!Regex.IsMatch(entryPassword.Text, checkUser.Password) || !Regex.IsMatch(checkUser.Password, entryPassword.Text))
        {
            await DisplayAlert("Error", "Incorrect Password", "Ok");
        }
        else
        {
            await DisplayAlert("Hi", "Good Login!", "Ok");
            //Navigation.PushAsync(new HomePage());
        }
    }
}