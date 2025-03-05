namespace Maui_iOS_RefreshView;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        RefreshView.Command = new Command(Reload);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshView.IsRefreshing = true;
    }

    async void Reload()
    {
        await Task.Delay(2000);
        Content.Clear();

        Content.Children.Add(new Label { Text = DateTime.Now.ToLongTimeString() });
        Content.Children.Add(new Button {
            Text = "Open Subpage",
            Command = new Command(async () => await Navigation.PushAsync(new ContentPage() {
                Content = new Label {
                    Text = "Empty page"
                }
            }))
        });

        RefreshView.IsRefreshing = false;
    }

    void MenuItem_OnClicked(object sender, EventArgs e)
    {
        RefreshView.IsRefreshing = true;
    }
}
