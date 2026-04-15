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

    public Library()
    {
        _bookList = new List<Book>();
        _libIDGeneratorSeed = 0;

    }
}