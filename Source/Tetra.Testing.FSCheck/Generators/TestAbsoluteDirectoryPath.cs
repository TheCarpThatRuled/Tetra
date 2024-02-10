namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestAbsoluteDirectoryPath> TestAbsoluteDirectoryPath()
      => VolumeComponent()
        .Combine(SequenceOf(DirectoryComponent()),
                 Testing.TestAbsoluteDirectoryPath
                        .Create);

   /* ------------------------------------------------------------ */
}