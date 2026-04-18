using LibraryAppInteractive.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppInteractive;


public partial class LibraryAdminPage : ContentPage
{
    private Library _library;
    private string bookName;
    private string ISBN;
    private string[] bookAuthorArray;
    private List<LibraryAsset> libAssetList;
    public LibraryAdminPage(Library library)
    {        
        InitializeComponent();
        _library = library;
        
        libAssetList = new List<LibraryAsset>();

    }

    private void OnRegisterBook(object sender, EventArgs e)
    {
       
        bookName = _txtBookName.Text;
        ISBN = _txtBookISBN.Text;

        bookAuthorArray = _txtBookAuthorList.Text.Split(',');

        //ChatGPT prompt used: How can I convert a selecter picker item in .NET to an enum
        _pckBookType.ItemsSource = Enum.GetValues(typeof(BookType));
        BookType type = (BookType)_pckBookType.SelectedItem;
        int nCopies = int.Parse(_txtBookCopyCount.Text);

        _library.RegisterBook(bookName, ISBN, bookAuthorArray, type, nCopies);
    }
}