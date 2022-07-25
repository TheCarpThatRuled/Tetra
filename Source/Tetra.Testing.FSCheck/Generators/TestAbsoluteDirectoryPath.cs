using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestAbsoluteDirectoryPath> TestAbsoluteDirectoryPath()
      => VolumeComponent()
        .Combine(ArrayOf(DirectoryComponent()),
                 Testing.TestAbsoluteDirectoryPath
                        .Create);

   /* ------------------------------------------------------------ */
}