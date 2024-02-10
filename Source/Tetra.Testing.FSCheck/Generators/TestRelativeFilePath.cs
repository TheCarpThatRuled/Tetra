namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestRelativeFilePath> TestRelativeFilePath()
      => SequenceOf(DirectoryComponent())
        .Combine(FileComponent(),
                 Testing.TestRelativeFilePath
                        .Create);

   /* ------------------------------------------------------------ */
}