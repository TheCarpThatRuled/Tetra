namespace Tetra.Testing;

public sealed class FileSystemActions<T>
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

   private FileSystemActions
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

   public static FileSystemActions<T> Create
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

   public FileSystemActions<T> SettingTheCurrentDirectoryShallFail
   (
      Message errorMessage
   )
   {
      _fileSystem.SettingTheCurrentDirectoryShallFail(errorMessage);

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemActions<T> SettingTheCurrentDirectoryShallSucceed()
   {
      _fileSystem.SettingTheCurrentDirectoryShallSucceed();

      return this;
   }

   /* ------------------------------------------------------------ */
}