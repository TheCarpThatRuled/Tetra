using Tetra;

namespace Check;

public sealed class FileSystemApiActions<T> : Chainable<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string          _characterisation;
   private readonly IFileSystem     _fileSystem;
   private readonly Action<object?> _pushReturnValue;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FileSystemApiActions
   (
      string          characterisation,
      IFileSystem     fileSystem,
      Func<T>         next,
      Action<object?> pushReturnValue
   ) : base(next)
   {
      _characterisation = characterisation;
      _fileSystem       = fileSystem;
      _pushReturnValue  = pushReturnValue;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FileSystemApiActions<T> Create
   (
      string          characterisation,
      Action<object?> pushReturnValue,
      IFileSystem     fileSystem,
      Func<T>         parent
   )
      => new(characterisation,
             fileSystem,
             parent,
             pushReturnValue);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> Create
   (
      AbsoluteDirectoryPath path
   )
   {
      _pushReturnValue(_fileSystem.Create(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> CurrentDirectory()
   {
      _pushReturnValue(_fileSystem.CurrentDirectory());

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> DoesNotExist
   (
      AbsoluteDirectoryPath path
   )
   {
      _pushReturnValue(_fileSystem.DoesNotExist(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> DoesNotExist
   (
      AbsoluteFilePath path
   )
   {
      _pushReturnValue(_fileSystem.DoesNotExist(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> Exists
   (
      AbsoluteDirectoryPath path
   )
   {
      _pushReturnValue(_fileSystem.Exists(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> Exists
   (
      AbsoluteFilePath path
   )
   {
      _pushReturnValue(_fileSystem.Exists(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> Open
   (
      AbsoluteFilePath path
   )
   {
      _pushReturnValue(_fileSystem.Open(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> Read
   (
      AbsoluteFilePath path
   )
   {
      _pushReturnValue(_fileSystem.Read(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> SetCurrentDirectory
   (
      AbsoluteDirectoryPath path
   )
   {
      _pushReturnValue(_fileSystem.SetCurrentDirectory(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> SubDirectoriesOf
   (
      AbsoluteDirectoryPath path
   )
   {
      _pushReturnValue(_fileSystem.SubDirectoriesOf(path));

      return this;
   }

   /* ------------------------------------------------------------ */

   public FileSystemApiActions<T> SubFilesOf
   (
      AbsoluteDirectoryPath path
   )
   {
      _pushReturnValue(_fileSystem.SubFilesOf(path));

      return this;
   }

   /* ------------------------------------------------------------ */
}