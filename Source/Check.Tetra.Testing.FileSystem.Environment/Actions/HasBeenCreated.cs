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
      private object? _returnValue;

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

         Api = FileSystemApiActions<Actions>.Create("IFileSystem API",
                                                    returnValue => _returnValue = returnValue,
                                                    _fileSystem,
                                                    () => parent);

         ConfigurationApi = FileSystemActions<Actions>.Create("Testing.FileSystem API",
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

      public FileSystemApiActions<Actions> Api { get; }

      /* ------------------------------------------------------------ */

      public FileSystemActions<Actions> ConfigurationApi { get; }

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => Check
           .Asserts
           .Create(_fileSystem,
                   _returnValue);

      /* ------------------------------------------------------------ */

      public void CreateFileSystem
      (
         AbsoluteDirectoryPath currentDirectory
      )
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("create the file system",
                                                                             "it")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */
   }
}