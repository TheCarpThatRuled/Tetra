using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestRelativeFilePath> TestRelativeFilePath()
      => ArrayOf(DirectoryComponent())
        .Combine(FileComponent(),
                 Testing.TestRelativeFilePath
                        .Create);

   /* ------------------------------------------------------------ */
}