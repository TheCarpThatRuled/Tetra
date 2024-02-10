namespace Tetra.Testing;

public sealed class FileSystemActions<T> : Chainable<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string     _characterisation;
   private readonly FileSystem _fileSystem;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileSystemActions
   (
      string     characterisation,
      FileSystem fileSystem,
      Func<T>    next
   ) : base(next)
   {
      _characterisation = characterisation;
      _fileSystem       = fileSystem;
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