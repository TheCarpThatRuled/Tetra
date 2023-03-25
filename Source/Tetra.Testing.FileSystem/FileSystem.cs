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

   public IError Create(AbsoluteDirectoryPath path)
   {
      _directories.AddRange(path.Ancestry());

      return Error.None();
   }

   /* ------------------------------------------------------------ */

   public bool DoesNotExist(AbsoluteDirectoryPath path)
      => !Exists(path);

   /* ------------------------------------------------------------ */

   public bool DoesNotExist(AbsoluteFilePath path)
      => !Exists(path);

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteDirectoryPath path)
      => _directories
        .Contains(path);

   /* ------------------------------------------------------------ */

   public bool Exists(AbsoluteFilePath path)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IOpenFileResult<Stream> Open(AbsoluteFilePath path)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IOpenFileResult<string> Read(AbsoluteFilePath path)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IError SetCurrentDirectory(AbsoluteDirectoryPath path)
      => _setCurrentDirectory(path);

   /* ------------------------------------------------------------ */

   public IResult<ISequence<AbsoluteFilePath>> SubDirectoriesOf(AbsoluteDirectoryPath path)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IResult<ISequence<AbsoluteFilePath>> SubFileOf(AbsoluteDirectoryPath path)
      => throw new NotImplementedException();

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

   private readonly List<AbsoluteDirectoryPath> _directories = new();

   //Mutable
   private Func<AbsoluteDirectoryPath, IError> _setCurrentDirectory;
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

   private IError SuccessfullySetCurrentDirectory(AbsoluteDirectoryPath path)
   {
      _currentDirectory = path;

      return Error.None();
   }

   /* ------------------------------------------------------------ */
}