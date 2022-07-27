using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestRelativeDirectoryPath> TestRelativeDirectoryPath()
      => NonEmptyArrayOf(DirectoryComponent())
        .Select(Testing
               .TestRelativeDirectoryPath
               .Create);

   /* ------------------------------------------------------------ */
}