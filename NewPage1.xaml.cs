using System.Collections.ObjectModel;

namespace Dolgozat1;

public partial class NewPage1
{
    public ObservableCollection<UniqueString> Items = [];
	public NewPage1()
    {
		InitializeComponent();
        Data.ItemsSource = Items;
    }

    protected override void OnAppearing()
    {
        Welcome.Text = $"Üdvözöljük {MainPage.User}!";
        if (!MainPage.IsValidLogin) return;
        Save.IsEnabled = true;
        Load.IsEnabled = true;
    }

    private void Load_OnClicked(object? sender, EventArgs e)
    {
        var dataDirectory = FileSystem.Current.AppDataDirectory;
        Items.Clear();
        var f = File.ReadAllLines($"{dataDirectory}/data.txt");
        foreach (var s in f)
        {
            Items.Add(new UniqueString(s));
        }
    }

    private void Save_OnClicked(object? sender, EventArgs e)
    {
        var dataDirectory = FileSystem.Current.AppDataDirectory;
        File.WriteAllLines($"{dataDirectory}/data.txt", Items.Select(x => x.Content));
    }

    private void Add_OnClicked(object? sender, EventArgs e)
    {
        Items.Add(new UniqueString(Input.Text));
    }

    private void Insert_OnClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Input.Text)) return;
        Items.Insert(Items.IndexOf((UniqueString)Data.SelectedItem) + 1, new UniqueString(Input.Text));
    }

    private void Clear_OnClicked(object? sender, EventArgs e)
    {
        Items.Clear();
    }

    private void Delete_OnClicked(object? sender, EventArgs e)
    {
        if (Data.SelectedItem != null)
        {
            Items.Remove((UniqueString)Data.SelectedItem);
        }
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        Items.Clear();
        Input.Text = "";
        Save.IsEnabled = false;
        Load.IsEnabled = false;
        Shell.Current.GoToAsync("///MainPage");
    }
}

public class UniqueString(string content)
{
    public string Content = content;
    public Guid Id = Guid.NewGuid();

    public override string ToString()
    {
        return Content;
    }
}