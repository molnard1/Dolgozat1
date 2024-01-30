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

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                await DisplayAlert("Figyelmeztetés", "A felhasználónév és jelszó mezők nem lehetnek üresek!", "OK");
                return;
            }

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

            await Shell.Current.GoToAsync("///NewPage1");
        }
    }

}
