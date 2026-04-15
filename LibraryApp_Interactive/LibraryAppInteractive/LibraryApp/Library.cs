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
        _libIDGeneratorSeed = 0;

    }

    /// <summary>
    /// Creates default books for the class
    /// </summary>
    private void CreateDefaultBooks()
    {

    }

    /// <summary>
    /// Creates a library ID
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private int DetermineLibID()
    {
        throw new Exception("Unimplemented");
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
        throw new Exception("Unimplemented");
    }

    /// <summary>
    /// Allows user to find a certain book by name
    /// </summary>
    /// <param name="bookName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Book FindBookByName(string bookName)
    {
        throw new Exception("Unimplemented");
    }

    /// <summary>
    /// Allows user to find a certain book by ISBN 
    /// </summary>
    /// <param name="bookISBN"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>

    public Book FindBookByISBN(string bookISBN)
    {
        throw new Exception("Unimplemented");
    }
}