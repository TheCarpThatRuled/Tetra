using Tetra.Testing;

namespace Check;

public sealed class ExternalFileSystemActions
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly AAA_test.Disposables _disposables;
   private readonly LockedFiles          _lockedFiles;
   private readonly Actions              _parent;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ExternalFileSystemActions
   (
      AAA_test.Disposables disposables,
      LockedFiles          lockedFiles,
      Actions              parent
   )
   {
      _disposables = disposables;
      _lockedFiles = lockedFiles;
      _parent      = parent;
   }

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static ExternalFileSystemActions Create
   (
      AAA_test.Disposables disposables,
      LockedFiles          lockedFiles,
      Actions              parent
   )
      => new(disposables,
             lockedFiles,
             parent);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ExternalFileSystemActions CreateSandbox
   (
      string directory
   )
   {
      _disposables.Register(DeleteADirectory.Create(directory));

      ExternalFileSystem.EnsureAnEmptyDirectoryExists(directory);
      ExternalFileSystem.SetCurrentDirectory(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public ExternalFileSystemActions EnsureADirectoryDoesNotExists
   (
      string directory
   )
   {
      ExternalFileSystem.EnsureADirectoryDoesNotExists(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public ExternalFileSystemActions EnsureADirectoryExists
   (
      string directory
   )
   {
      ExternalFileSystem.EnsureADirectoryExists(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public ExternalFileSystemActions EnsureAnEmptyDirectoryExists
   (
      string directory
   )
   {
      ExternalFileSystem.EnsureAnEmptyDirectoryExists(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public ExternalFileSystemActions EnsureADirectoryIsEmpty
   (
      string directory
   )
   {
      ExternalFileSystem.EnsureADirectoryIsEmpty(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public ExternalFileSystemActions EnsureAFileDoesNotExists
   (
      string file
   )
   {
      ExternalFileSystem.EnsureAFileDoesNotExists(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public ExternalFileSystemActions EnsureAFileExists
   (
      string file
   )
   {
      ExternalFileSystem.EnsureAFileExists(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public ExternalFileSystemActions LockFile
   (
      string file
   )
   {
      _lockedFiles.LockFile(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public ExternalFileSystemActions UnlockFile
   (
      string file
   )
   {
      _lockedFiles.UnlockFile(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public ExternalFileSystemActions SetCurrentDirectory
   (
      string directory
   )
   {
      ExternalFileSystem.SetCurrentDirectory(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions ReturnToParent()
      => _parent;

   /* ------------------------------------------------------------ */
}