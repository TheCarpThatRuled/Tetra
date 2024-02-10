namespace Tetra.Testing;

public sealed class FileSystemAsserts<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string     _characterisation;
   private readonly FileSystem _fileSystem;
   private readonly Func<T>    _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileSystemAsserts
   (
      string     characterisation,
      FileSystem fileSystem,
      Func<T>    next
   )
   {
      _characterisation = characterisation;
      _fileSystem       = fileSystem;
      _next             = next;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FileSystemAsserts<T> Create
   (
      string     characterisation,
      FileSystem fileSystem,
      Func<T>    next
   )
      => new(characterisation,
             fileSystem,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public T Next()
      => _next();

   /* ------------------------------------------------------------ */
}