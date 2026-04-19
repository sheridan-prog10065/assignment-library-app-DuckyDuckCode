using LibraryAppInteractive.BusinessLogic;

namespace LibraryAppInteractive;

public partial class LibraryBrowsePage : ContentPage
{
    private Book _currentBook;
    private LibraryAsset _currentAsset;
    private Library _library;
    
    public LibraryBrowsePage(Library library)
    {
        _library = library;
        InitializeComponent();
    }

    private async void OnCheckStatus(object sender, EventArgs e)
    {
        (bool isAvailable, LibraryAsset asset) = _currentBook.CheckAvailability();

        if (isAvailable)
        {
           
            _currentAsset = asset;
            await DisplayAlertAsync("Book is available", "This book is available to be borrowed", "OK");
        }
        else
        {
            await DisplayAlertAsync("Book is not available", "This book is not available to be borrowed", "OK");
        }

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

    private async void OnBorrowBook(object sender, EventArgs e)
    {
        _currentAsset = _currentBook.BorrowBook();
        
        await DisplayAlertAsync("Book Borrowed", $"Book was borrowed, use {_currentAsset.LibID} to return it", "OK");
    }

    private async void OnReturnBook(object sender, EventArgs e)
    {
        try
        {
            foreach (LibraryAsset iAsset in _currentBook.Assets)
            {
                if (iAsset.LibID == int.Parse(_txtBookReturn.Text))
                {
                    _currentAsset = iAsset;
                }
            }
            (TimeSpan duration, int lateDays, decimal fine) = _currentBook.ReturnBook(_currentAsset.LibID);
            _lstBookAssets.ItemsSource = null;
            _lstBookAssets.ItemsSource = _currentBook.Assets;
            await DisplayAlertAsync("Book returned", $"Book has been returned. It was loaned for {duration} with the book being returned {lateDays} days late, fine of ${fine}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error occured", $"{ex}", "OK");
        }
    }

    private void OnDisplayBookAssets(object sender, EventArgs e)
    {
        _viewBookMenu.IsVisible = false;
        _viewLibraryAssets.IsVisible = true;
        _lstBookAssets.ItemsSource = _currentBook.Assets;
    }

    private void OnReturnToBookMenu(object sender, EventArgs e)
    {
        _viewBookMenu.IsVisible = true;
        _viewLibraryAssets.IsVisible = false;
        
    }
}