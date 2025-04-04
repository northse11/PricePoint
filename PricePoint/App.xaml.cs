namespace PricePoint
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage(new LocalDbService());
        }
    }
}
