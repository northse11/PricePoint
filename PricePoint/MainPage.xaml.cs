namespace PricePoint
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly LocalDbService _dbService;

        public MainPage(LocalDbService localDbService)
        {
            InitializeComponent();
            _dbService = localDbService;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
