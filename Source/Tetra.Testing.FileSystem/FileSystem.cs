namespace Tetra.Testing;

public sealed class FileSystem : IFileSystem
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FileSystem Create(AbsoluteDirectoryPath currentDirectory)
      => new(currentDirectory);

   /* ------------------------------------------------------------ */
   // IFileSystem Properties
   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath CurrentDirectory()
      => _currentDirectory;

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteDirectoryPath path)
      => _currentDirectory
        .Equals(path);

   /* ------------------------------------------------------------ */
   // IFileSystem Methods
   /* ------------------------------------------------------------ */

   public Error SetCurrentDirectory(AbsoluteDirectoryPath path)
      => _setCurrentDirectory(path);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void SettingTheCurrentDirectoryShallFail(Message error)
      => _setCurrentDirectory = _ => Error.Some(error);

   /* ------------------------------------------------------------ */

   public void SettingTheCurrentDirectoryShallSucceed()
      => _setCurrentDirectory = SuccessfullySetCurrentDirectory;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   //Mutable
   private Func<AbsoluteDirectoryPath, Error> _setCurrentDirectory;
   private AbsoluteDirectoryPath              _currentDirectory;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileSystem(AbsoluteDirectoryPath currentDirectory)
   {
      _setCurrentDirectory = SuccessfullySetCurrentDirectory;

      _currentDirectory = currentDirectory;
   }

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   private Error SuccessfullySetCurrentDirectory(AbsoluteDirectoryPath path)
   {
      _currentDirectory = path;

      return Error.None();
   }

   /* ------------------------------------------------------------ */
}