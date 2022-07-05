namespace Tetra.Testing;

public sealed class FileSystem : IFileSystem
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FileSystem From(AbsoluteDirectoryPath currentDirectory)
      => new(currentDirectory);

   /* ------------------------------------------------------------ */
   // IFileSystem Properties
   /* ------------------------------------------------------------ */

   public AbsoluteDirectoryPath CurrentDirectory()
      => _currentDirectory;

   /* ------------------------------------------------------------ */
   // IFileSystem Methods
   /* ------------------------------------------------------------ */

   public Error Create(AbsoluteDirectoryPath path)
   {
      var dir = (VolumeRootedDirectoryPath) path;

      _directories.AddRange(dir.Ancestry());

      return Error.None();
   }

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteDirectoryPath path)
      => _directories
        .Contains(path);

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

   private readonly List<AbsoluteDirectoryPath> _directories = new List<AbsoluteDirectoryPath>();

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

      _directories.Add(currentDirectory);
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