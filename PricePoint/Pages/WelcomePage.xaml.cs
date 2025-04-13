using System.Collections;

namespace PricePoint.Pages;

public partial class WelcomePage : ContentPage
{
	private readonly LocalDbService _dbService;
	public WelcomePage(LocalDbService dbService)
	{
		InitializeComponent();
		_dbService = dbService;
	}

    private async void btnLoginClicked(object sender, EventArgs e) 
	{
		Navigation.PushAsync(new LoginPage(_dbService));
	}

	private async void btnSignupClicked(object sender, EventArgs e) 
	{
		Navigation.PushAsync(new SignUpPage(_dbService));
	}

}