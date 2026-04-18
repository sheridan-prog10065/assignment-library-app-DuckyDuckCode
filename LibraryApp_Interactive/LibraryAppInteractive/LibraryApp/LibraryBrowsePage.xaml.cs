namespace LibraryAppInteractive;

public partial class LibraryBrowsePage : ContentPage
{
    public LibraryBrowsePage()
    {   
        InitializeComponent();
    }

    private void OnCheckStatus(object sender, EventArgs e)
    {

    }
    private void OnViewBookMenu(object sender, EventArgs e)
    {
        _viewMainMenu.IsVisible = false;
        _viewBookMenu.IsVisible = true;
    }

    private void OnReturnToMainMenu(object sender, EventArgs e)
    {
        _viewMainMenu.IsVisible = true;
        _viewBookMenu.IsVisible = false;
    }

    private void OnBorrowBook(object sender, EventArgs e)
    {
       
    }

    private void OnReturnBook(object sender, EventArgs e)
    {
       
    }

    private void OnDisplayBookAssets(object sender, EventArgs e)
    {
        _viewBookMenu.IsVisible = false;
        _viewLibraryAssets.IsVisible = true;
       // _lstBookAssets.ItemsSource = 
    }

    private void OnReturnToBookMenu(object sender, EventArgs e)
    {
        _viewBookMenu.IsVisible = true;
        _viewLibraryAssets.IsVisible = false;
        
    }
}