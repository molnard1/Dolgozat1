namespace Dolgozat1
{
    public partial class MainPage : ContentPage
    {
        public static bool IsValidLogin { get; set; }
        public static string User { get; set; } = null!;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            if (Username.Text == "a" && Password.Text == "a")
            {
                IsValidLogin = true;
                User = Username.Text;
            }
            else
            {
                IsValidLogin = false;
                User = "Vendég";
            }

            Shell.Current.GoToAsync("///NewPage1");
        }
    }

}
