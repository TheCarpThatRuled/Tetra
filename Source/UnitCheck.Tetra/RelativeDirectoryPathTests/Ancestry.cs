using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeDirectoryPath)]
public class Ancestry
{
   /* ------------------------------------------------------------ */
   // public static IReadOnlyList<RelativeDirectoryPath> Ancestry(this RelativeDirectoryPath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath
   //WHEN
   //Ancestry
   //THEN
   //a_sequence_of_RelativeDirectoryPaths_representing_each_node_from_the_root_to_the_leaf_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeDirectoryPath_WHEN_Ancestry_THEN_a_sequence_of_RelativeDirectoryPaths_representing_each_node_from_the_root_to_the_leaf_is_returned()
   {
      static Property Property(DirectoryComponent[] directories)
      {
         //Arrange
         var expected = ExpectedPath.BuildAncestry(directories);

         //Act
         var actual = expected[^1].Ancestry();

         //Assert
         return AreSequenceEqual(expected,
                                 actual);
      }

      Arb.Register<Libraries.NonEmptyArrayOfDirectoryComponents>();

      Prop.ForAll<DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}