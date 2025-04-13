using PricePoint.Pages;

namespace PricePoint
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage(new LocalDbService()));
        }
    }
}
