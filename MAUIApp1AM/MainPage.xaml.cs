
namespace MAUIApp1AM
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterUpClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterLbl.Text = $"Counter: {count}";
            else
                CounterLbl.Text = $"Counter: {count}";

            SemanticScreenReader.Announce(CounterLbl.Text);
        }

        private void OnCounterDownClicked(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count--;
                CounterLbl.Text = $"Counter: {count}";
            }
            else
            {
                CounterLbl.Text = $"Counter: 0";
            }
        }
    }
}