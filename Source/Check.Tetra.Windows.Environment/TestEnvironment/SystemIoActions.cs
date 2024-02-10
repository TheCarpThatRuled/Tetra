using Tetra;
using Tetra.Testing;

namespace Check;

public sealed class SystemIoActions : Chainable<Actions>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string               _description;
   private readonly AAA_test.Disposables _disposables;
   private readonly LockedFiles          _lockedFiles;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private SystemIoActions
   (
      string               description,
      AAA_test.Disposables disposables,
      LockedFiles          lockedFiles,
      Func<Actions>        next
   ) : base(next)
   {
      _description = description;
      _disposables = disposables;
      _lockedFiles = lockedFiles;
   }

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static SystemIoActions Create
   (
      string               description,
      AAA_test.Disposables disposables,
      LockedFiles          lockedFiles,
      Func<Actions>        next
   )
      => new(description,
             disposables,
             lockedFiles,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public SystemIoActions CreateSandbox
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

   public SystemIoActions EnsureADirectoryDoesNotExists
   (
      string directory
   )
   {
      ExternalFileSystem.EnsureADirectoryDoesNotExists(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public SystemIoActions EnsureADirectoryExists
   (
      string directory
   )
   {
      ExternalFileSystem.EnsureADirectoryExists(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public SystemIoActions EnsureAnEmptyDirectoryExists
   (
      string directory
   )
   {
      ExternalFileSystem.EnsureAnEmptyDirectoryExists(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public SystemIoActions EnsureADirectoryIsEmpty
   (
      string directory
   )
   {
      ExternalFileSystem.EnsureADirectoryIsEmpty(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public SystemIoActions EnsureAFileDoesNotExists
   (
      string file
   )
   {
      ExternalFileSystem.EnsureAFileDoesNotExists(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public SystemIoActions EnsureAFileExists
   (
      string file
   )
   {
      ExternalFileSystem.EnsureAFileExists(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public SystemIoActions LockFile
   (
      string file
   )
   {
      _lockedFiles.LockFile(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public SystemIoActions UnlockFile
   (
      string file
   )
   {
      _lockedFiles.UnlockFile(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public SystemIoActions SetCurrentDirectory
   (
      string directory
   )
   {
      ExternalFileSystem.SetCurrentDirectory(directory);

      return this;
   }

   /* ------------------------------------------------------------ */
}