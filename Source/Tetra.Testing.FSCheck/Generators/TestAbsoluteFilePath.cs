namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestAbsoluteFilePath> TestAbsoluteFilePath()
      => VolumeComponent()
        .Combine(SequenceOf(DirectoryComponent()),
                 FileComponent(),
                 Testing.TestAbsoluteFilePath
                        .Create);

   /* ------------------------------------------------------------ */
}