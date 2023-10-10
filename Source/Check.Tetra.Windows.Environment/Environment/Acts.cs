using Tetra;
using Tetra.Testing;

namespace Check;

public sealed class Acts : IActs
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IFileSystem _fileSystem;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Acts
   (
      IFileSystem fileSystem
   )
      => _fileSystem = fileSystem;
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Act<ObjectAsserts<bool, Asserts>> The_client_checks_that_a_directory_does_not_exist
   (
      AbsoluteDirectoryPath path
   )
      => new(() => Check_that_a_directory_does_not_exist(path));

   /* ------------------------------------------------------------ */

   public Act<ObjectAsserts<bool, Asserts>> The_client_checks_that_a_directory_exists
   (
      AbsoluteDirectoryPath path
   )
      => new(() => Check_that_a_directory_exists(path));

   /* ------------------------------------------------------------ */

   public Act<ObjectAsserts<bool, Asserts>> The_client_checks_that_a_file_does_not_exist
   (
      AbsoluteFilePath path
   )
      => new(() => Check_that_a_file_does_not_exist(path));

   /* ------------------------------------------------------------ */

   public Act<ObjectAsserts<bool, Asserts>> The_client_checks_that_a_file_exists
   (
      AbsoluteFilePath path
   )
      => new(() => Check_that_a_file_exists(path));

   /* ------------------------------------------------------------ */

   public Act<OptionAsserts<Message, Asserts>> The_client_creates_a_directory
   (
      AbsoluteDirectoryPath path
   )
      => new(() => Create_a_directory(path));

   /* ------------------------------------------------------------ */
   public Act<ObjectAsserts<AbsoluteDirectoryPath, Asserts>> The_client_gets_the_current_directory()
      => new(Get_the_current_directory);

   /* ------------------------------------------------------------ */

   public Act<OptionAsserts<Message, Asserts>> The_client_sets_the_current_directory
   (
      AbsoluteDirectoryPath path
   )
      => new(() => Set_the_current_directory(path));

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Acts Create
   (
      IFileSystem fileSystem
   )
      => new(fileSystem);

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   private ObjectAsserts<bool, Asserts> Check_that_a_directory_does_not_exist
   (
      AbsoluteDirectoryPath path
   )
      => ObjectAsserts<bool, Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.DoesNotExist)}({nameof(AbsoluteDirectoryPath)})",
                _fileSystem.DoesNotExist(path),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */

   private ObjectAsserts<bool, Asserts> Check_that_a_directory_exists
   (
      AbsoluteDirectoryPath path
   )
      => ObjectAsserts<bool, Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.Exists)}({nameof(AbsoluteDirectoryPath)})",
                _fileSystem.Exists(path),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */

   private ObjectAsserts<bool, Asserts> Check_that_a_file_does_not_exist
   (
      AbsoluteFilePath path
   )
      => ObjectAsserts<bool, Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.DoesNotExist)}({nameof(AbsoluteFilePath)})",
                _fileSystem.DoesNotExist(path),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */

   private ObjectAsserts<bool, Asserts> Check_that_a_file_exists
   (
      AbsoluteFilePath path
   )
      => ObjectAsserts<bool, Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.Exists)}({nameof(AbsoluteFilePath)})",
                _fileSystem.Exists(path),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */

   private OptionAsserts<Message, Asserts> Create_a_directory
   (
      AbsoluteDirectoryPath path
   )
      => OptionAsserts<Message, Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.Create)}({nameof(AbsoluteDirectoryPath)})",
                _fileSystem.Create(path),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */

   private ObjectAsserts<AbsoluteDirectoryPath, Asserts> Get_the_current_directory()
      => ObjectAsserts<AbsoluteDirectoryPath, Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.CurrentDirectory)}",
                _fileSystem.CurrentDirectory(),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */

   private OptionAsserts<Message, Asserts> Set_the_current_directory
   (
      AbsoluteDirectoryPath path
   )
      => OptionAsserts<Message, Asserts>
        .Create($"{nameof(IFileSystem)}.{nameof(IFileSystem.SetCurrentDirectory)}",
                _fileSystem.SetCurrentDirectory(path),
                () => Asserts.Create(_fileSystem));

   /* ------------------------------------------------------------ */
}