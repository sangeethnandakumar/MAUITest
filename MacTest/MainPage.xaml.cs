namespace MacTest;

public partial class MainPage : ContentPage
{
    public string AppName { get; set; } = "Finance Manager";

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //await SelectAnExcelFile();
        //await DisplayAlerts();




    }

    private async Task DisplayAlerts()
    {
        bool result = await DisplayAlert("Confirmation", "Are you sure you want to delete this file?", "Yes", "No");
        await DisplayAlert("MAUI", $"Choosen {result}", "OK");
    }

    private async Task SelectAnExcelFile()
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { "xlsx" } },
                    { DevicePlatform.macOS, new[] { "xlsx" } },
                    { DevicePlatform.Unknown, new[] { "xlsx" } },
                })
            });
            if (result != null)
            {
                string filePath = result.FullPath;
                Heading.Text = filePath;
            }
        }
        catch (Exception ex)
        {
            // handle exceptions
        }
    }
}

