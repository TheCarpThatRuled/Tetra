using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeFilePath)]
public class Ancestry
{
   /* ------------------------------------------------------------ */
   // public static (IReadOnlyList<RelativeDirectoryPath> ancestors, RelativeFilePath file) Ancestry(this RelativeFilePath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath
   //WHEN
   //Ancestry
   //THEN
   //a_sequence_of_RelativeDirectoryPaths_representing_each_node_from_the_root_to_the_parent_and_an_RelativeFilePath_representing_the_leaf_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeFilePath_WHEN_Ancestry_THEN_a_sequence_of_RelativeDirectoryPaths_representing_each_node_from_the_root_to_the_parent_and_an_RelativeFilePath_representing_the_leaf_is_returned()
   {
      static Property Property(DirectoryComponent[] directories,
                               FileComponent        file)
      {
         //Arrange
         var expected = ExpectedPath.BuildAncestry(directories);

         var path = RelativeFilePath.Create(directories,
                                            file);

         //Act
         var (actualAncestors, actualLeaf) = path.Ancestry();

         //Assert
         return AreSequenceEqual(expected,
                                 actualAncestors)
           .And(AreEqual(path,
                         actualLeaf));
      }

      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<DirectoryComponent[], FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}