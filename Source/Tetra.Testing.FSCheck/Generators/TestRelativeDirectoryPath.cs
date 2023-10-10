using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestRelativeDirectoryPath> TestRelativeDirectoryPath()
      => NonEmptySequenceOf(DirectoryComponent())
        .Select(Testing.TestRelativeDirectoryPath
                       .Create);

   /* ------------------------------------------------------------ */
}