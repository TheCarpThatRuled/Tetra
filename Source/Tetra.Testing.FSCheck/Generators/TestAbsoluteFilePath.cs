using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestAbsoluteFilePath> TestAbsoluteFilePath()
      => VolumeComponent()
        .Combine(ArrayOf(DirectoryComponent()),
                 FileComponent(),
                 Testing.TestAbsoluteFilePath
                        .Create);

   /* ------------------------------------------------------------ */
}