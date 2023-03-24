using Tetra;
using Tetra.Testing;

namespace Check;

public sealed class Acts : IActs
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Act<ReturnAsserts<bool, Asserts>> The_client_checks_that_a_directory_does_not_exist(AbsoluteDirectoryPath path)
      => new(() => Check_that_a_directory_does_not_exist(path));

   /* ------------------------------------------------------------ */

   public Act<ReturnAsserts<bool, Asserts>> The_client_checks_that_a_directory_exists(AbsoluteDirectoryPath path)
      => new(() => Check_that_a_directory_exists(path));

   /* ------------------------------------------------------------ */

   public Act<ErrorAsserts<Asserts>> The_client_creates_a_directory(AbsoluteDirectoryPath path)
      => new(() => Create_a_directory(path));

   /* ------------------------------------------------------------ */
   public Act<ReturnAsserts<AbsoluteDirectoryPath, Asserts>> The_client_gets_the_current_directory()
      => new(Get_the_current_directory);

   /* ------------------------------------------------------------ */

   public Act<ErrorAsserts<Asserts>> The_client_sets_the_current_directory(AbsoluteDirectoryPath path)
      => new(() => Set_the_current_directory(path));

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Acts Create(IFileSystem fileSystem)
      => new(fileSystem);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IFileSystem _fileSystem;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Acts(IFileSystem fileSystem)
      => _fileSystem = fileSystem;

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   private ReturnAsserts<bool, Asserts> Check_that_a_directory_does_not_exist(AbsoluteDirectoryPath path)
      => ReturnAsserts<bool, Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.DoesNotExist)}",
                _fileSystem.DoesNotExist(path),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */

   private ReturnAsserts<bool, Asserts> Check_that_a_directory_exists(AbsoluteDirectoryPath path)
      => ReturnAsserts<bool, Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.Exists)}",
                _fileSystem.Exists(path),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */

   private ErrorAsserts<Asserts> Create_a_directory(AbsoluteDirectoryPath path)
      => ErrorAsserts<Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.Create)}",
                _fileSystem.Create(path),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */

   private ReturnAsserts<AbsoluteDirectoryPath, Asserts> Get_the_current_directory()
      => ReturnAsserts<AbsoluteDirectoryPath, Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.CurrentDirectory)}",
                _fileSystem.CurrentDirectory(),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */

   private ErrorAsserts<Asserts> Set_the_current_directory(AbsoluteDirectoryPath path)
      => ErrorAsserts<Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.SetCurrentDirectory)}",
                _fileSystem.SetCurrentDirectory(path),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */
}