using Tetra;
using Tetra.Testing;

namespace Check;

partial class Actions
{
   private sealed class HasBeenCreated : IActions
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FileSystem _fileSystem;

      //Mutable
      private object? _returnValue = null;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private HasBeenCreated
      (
         FileSystem fileSystem,
         Actions    parent
      )
      {
         _fileSystem = fileSystem;


         TestFileSystem = FileSystemActions<Actions>.Create("File system",
                                                            _fileSystem,
                                                            () => parent);
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static HasBeenCreated Create
      (
         FileSystem fileSystem,
         Actions    parent
      )
         => new(fileSystem,
                parent);

      /* ------------------------------------------------------------ */
      // IActions Properties
      /* ------------------------------------------------------------ */

      public FileSystemActions<Actions> TestFileSystem { get; }

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => Check
           .Asserts
           .Create(_fileSystem,
                   _returnValue);

      /* ------------------------------------------------------------ */

      public void Create
      (
         AbsoluteDirectoryPath path
      )
         => _returnValue = _fileSystem.Create(path);

      /* ------------------------------------------------------------ */

      public void CreateFileSystem
      (
         AbsoluteDirectoryPath currentDirectory
      )
         => throw Failed.Assert("Cannot create the file system; it has already been created.");

      /* ------------------------------------------------------------ */

      public void Exists
      (
         AbsoluteDirectoryPath path
      )
         => _returnValue = _fileSystem.Exists(path);

      /* ------------------------------------------------------------ */

      public void SetCurrentDirectory
      (
         AbsoluteDirectoryPath path
      )
         => _returnValue = _fileSystem.SetCurrentDirectory(path);

      /* ------------------------------------------------------------ */
   }
}