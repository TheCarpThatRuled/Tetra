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
      disposables.Register(SetTheCurrentDirectory.Create(ExternalFileSystem.GetTheCurrentDirectory()));

      return new(disposables);
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IFileSystem _fileSystem = FileSystem.Create();

   private readonly AAA_test.Disposables _disposables;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Arranges(AAA_test.Disposables disposables)
   {
      _disposables = disposables;
   }

   /* ------------------------------------------------------------ */
}