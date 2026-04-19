using LibraryAppInteractive.BusinessLogic;

namespace LibraryAppInteractive;

/// <summary>
/// Defines the Library class used to manage the library books and assets.
///
/// NOTE: A single object/instance of this class (called a "singleton") is created and shared automatically
/// with the two pages in the application through the process of Dependency Injection handled and configured
/// in MauiProgram class.  
/// </summary>
public class Library
{
    /// <summary>
    /// List of books the library has
    /// </summary>
    private List<Book> _bookList;
    /// <summary>
    /// A seed to generate a new ID of the liberary
    /// </summary>
    private int _libIDGeneratorSeed;
    /// <summary>
    /// Default ID a library is initialized with before receiving a generated one from the generator seed
    /// </summary>
    const int _DEFAULT_LIBID_START = 100;


    

    /// <summary>
    /// Constructor for library
    /// </summary>
    public Library()
    {
        _bookList = new List<Book>();
        _libIDGeneratorSeed = _DEFAULT_LIBID_START;
        CreateDefaultBooks();

    }

    /// <summary>
    /// Creates default books for the class
    /// </summary>
    private void CreateDefaultBooks()
    {
        RegisterBook(
       "The Hunger Games",
       "9780545425117",
       new string[] { "Suzanne Collins" },
       BookType.Paper,
       3
       );

        RegisterBook(
        "Certainly A Book",
        "345",
        new string[] { "Anna Uthor", "Ed Itor" },
        BookType.Digital,
        3
        );

        RegisterBook(
       "Code Complete, 2nd Edition",
       "0735619670",
       new string[] { "Steve McConnell" },
       BookType.Digital,
       3
        );

    }

    /// <summary>
    /// Creates a library ID
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int DetermineLibID()
    {
        _libIDGeneratorSeed++;
        return _libIDGeneratorSeed;
    }

    /// <summary>
    /// Allows user to register a new book for the system /// </summary>
    /// <param name="bookName"></param>
    /// <param name="bookISBN"></param>
    /// <param name="authors"></param>
    /// <param name="bookType"></param>
    /// <param name="nCopies"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Book RegisterBook(string bookName, string bookISBN, string[] authors, BookType bookType, int nCopies)
    {
        Book newBook;

        if (bookType == BookType.Paper)
        {
            newBook = new PaperBook(bookName, bookISBN);
        }
        else if (bookType == BookType.Digital)
        {
            newBook = new DigitalBook(bookName, bookISBN);
        }
        else
        {
            newBook = new Book(bookName, bookISBN);
        }

        foreach (string iAuthor in authors)
        {
            newBook.Authors.Add(iAuthor);
        }
        
        for (int iAsset = 0; iAsset<nCopies; iAsset++)
        {
            int assetId = DetermineLibID();
            LibraryAsset newAsset = new LibraryAsset(assetId, newBook);
            newBook.AddAsset(newAsset);
        }

        _bookList.Add(newBook);

        return newBook;
    }

       

    /// <summary>
    /// Allows user to find a certain book by name
    /// </summary>
    /// <param name="bookName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Book FindBookByName(string bookName)
    {
       foreach(Book iBook in _bookList)
        {
            if(bookName == iBook.Name)
            {
                return iBook;
                
            }
        }
        return null;
    }

    /// <summary>
    /// Allows user to find a certain book by ISBN 
    /// </summary>
    /// <param name="bookISBN"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>

    public Book FindBookByISBN(string bookISBN)
    {
        foreach (Book iBook in _bookList)
        {
            if (bookISBN == iBook.ISBN)
            {
                return iBook;

            }
        }
        return null;
    }
}