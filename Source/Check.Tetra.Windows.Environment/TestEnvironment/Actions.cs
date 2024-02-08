using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check;

public sealed class Actions : TestEnvironment<Actions, Asserts>
{
   /* ------------------------------------------------------------ */
   // Fields
   /* ------------------------------------------------------------ */

   public readonly ExternalFileSystemActions ExternalFileSystem;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IFileSystem _fileSystem = FileSystem.Create();

   //Mutable
   private object? _lastReturnedValue = null;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Actions
   (
      AAA_test.Disposables disposables,
      LockedFiles          lockedFiles
   )
      => ExternalFileSystem = ExternalFileSystemActions.Create(disposables,
                                                               lockedFiles,
                                                               this);

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Actions Create
   (
      AAA_test.Disposables disposables
   )
   {
      var lockedFiles = LockedFiles.Create();
      disposables.Register(lockedFiles);
      disposables.Register(SetTheCurrentDirectory.Create(Check
                                                        .ExternalFileSystem
                                                        .GetTheCurrentDirectory()));

      return new(disposables,
                 lockedFiles);
   }

   /* ------------------------------------------------------------ */
   //  TestEnvironment<Actions,Asserts> Methods
   /* ------------------------------------------------------------ */

   protected override Asserts CreateAsserts()
      => Check
        .Asserts
        .Create(_lastReturnedValue);

   /* ------------------------------------------------------------ */

   protected override Actions PerformFinalise()
      => this;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Actions DoesNotExist
   (
      AbsoluteDirectoryPath path
   )
   {
      _lastReturnedValue = _fileSystem.DoesNotExist(path);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions DoesNotExist
   (
      AbsoluteFilePath path
   )
   {
      _lastReturnedValue = _fileSystem.DoesNotExist(path);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions Exists
   (
      AbsoluteFilePath path
   )
   {
      _lastReturnedValue = _fileSystem.Exists(path);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions Exists
   (
      AbsoluteDirectoryPath path
   )
   {
      _lastReturnedValue = _fileSystem.Exists(path);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions Create
   (
      AbsoluteDirectoryPath path
   )
   {
      _lastReturnedValue = _fileSystem.Create(path);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions GetCurrentDirectory()
   {
      _lastReturnedValue = _fileSystem.CurrentDirectory();

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions SetCurrentDirectory
   (
      AbsoluteDirectoryPath path
   )
   {
     _lastReturnedValue = _fileSystem.SetCurrentDirectory(path);

      return this;
   }

   /* ------------------------------------------------------------ */
}