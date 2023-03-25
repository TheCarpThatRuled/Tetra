using Tetra;
using Tetra.Testing;
// ReSharper disable InconsistentNaming

namespace Check;

public sealed class Arranges : IArranges
{
   /* ------------------------------------------------------------ */
   // Methods
   public Arranges The_file_system_creates_a_sandbox(string directory)
   {
      _disposables.Register(DeleteADirectory.Create(directory));

      ExternalFileSystem.EnsureAnEmptyDirectoryExists(directory);
      ExternalFileSystem.SetCurrentDirectory(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Arranges A_directory_does_not_exist(string directory)
   {
      ExternalFileSystem.EnsureADirectoryExists(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Arranges A_directory_exists(string directory)
   {
      ExternalFileSystem.EnsureADirectoryExists(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Arranges A_file_does_not_exist(string file)
   {
      ExternalFileSystem.EnsureAFileExists(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Arranges A_file_exists(string file)
   {
      ExternalFileSystem.EnsureAFileExists(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Arranges A_file_is_locked(string file)
   {
      _lockedFiles.LockFile(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Arranges A_file_is_unlocked(string file)
   {
      _lockedFiles.UnlockFile(file);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Arranges The_current_directory_is(string directory)
   {
      ExternalFileSystem.SetCurrentDirectory(directory);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Acts WHEN()
      => Acts
        .Create(_fileSystem);

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Arranges Create(AAA_test.Disposables disposables)
   {
      var lockedFiles = LockedFiles.Create();
      disposables.Register(lockedFiles);
      disposables.Register(SetTheCurrentDirectory.Create(ExternalFileSystem.GetTheCurrentDirectory()));
 
      return new(disposables,
                 lockedFiles);
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IFileSystem _fileSystem = FileSystem.Create();

   private readonly AAA_test.Disposables _disposables;
   private readonly LockedFiles          _lockedFiles;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Arranges(AAA_test.Disposables disposables,
                    LockedFiles          lockedFiles)
   {
      _disposables = disposables;
      _lockedFiles = lockedFiles;
   }

   /* ------------------------------------------------------------ */
}