using LibraryAppInteractive.BusinessLogic;

namespace LibraryAppInteractive;

public partial class LibraryBrowsePage : ContentPage
{
    private Book _currentBook;
    private Library _library;
    public LibraryBrowsePage(Library library)
    {
        _library = library;
        InitializeComponent();
    }

    private void OnCheckStatus(object sender, EventArgs e)
    {

    }
    private async void OnViewBookMenu(object sender, EventArgs e)
    {
        _currentBook = _library.FindBookByName(_txtSearchBook.Text.ToString());
        if (_currentBook == null)
        {
            _currentBook = _library.FindBookByISBN(_txtSearchBook.Text.ToString());
        }
        if(_currentBook == null)
        {
            await DisplayAlertAsync("Book not found", "Could not find this book", "OK");
        }
        else
        {
            _viewMainMenu.IsVisible = false;
            _viewBookMenu.IsVisible = true;
        }
       
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