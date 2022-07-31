using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
public class Ancestry
{
   /* ------------------------------------------------------------ */
   // public static (IReadOnlyList<AbsoluteDirectoryPath> ancestors, AbsoluteFilePath file) Ancestry(this AbsoluteFilePath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteFilePath
   //WHEN
   //Ancestry
   //THEN
   //a_sequence_of_AbsoluteDirectoryPaths_representing_each_node_from_the_root_to_the_parent_and_an_AbsoluteFilePath_representing_the_leaf_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteFilePath_WHEN_Ancestry_THEN_a_sequence_of_AbsoluteDirectoryPaths_representing_each_node_from_the_root_to_the_parent_and_an_AbsoluteFilePath_representing_the_leaf_is_returned()
   {
      static Property Property(TestAbsoluteFilePath testPath)
      {
         //Arrange
         var expected = testPath.ToAncestry();

         var path = testPath.ToTetra();

         //Act
         var (actualAncestors, actualLeaf) = path.Ancestry();

         //Assert
         return AreSequenceEqual(AssertMessages.ReturnValue,
                                 expected,
                                 actualAncestors)
           .And(AreEqual(AssertMessages.ReturnValue,
                         testPath,
                         actualLeaf));
      }

      Arb.Register<Libraries.TestAbsoluteFilePath>();

      Prop.ForAll<TestAbsoluteFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}