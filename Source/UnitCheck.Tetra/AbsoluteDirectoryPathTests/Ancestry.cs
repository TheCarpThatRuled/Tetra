using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
public class Ancestry
{
   /* ------------------------------------------------------------ */
   // public ISequence<AbsoluteDirectoryPath> Ancestry()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath
   //WHEN
   //Ancestry
   //THEN
   //a_sequence_of_AbsoluteDirectoryPaths_representing_each_node_from_the_root_to_the_leaf_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_WHEN_Ancestry_THEN_a_sequence_of_AbsoluteDirectoryPaths_representing_each_node_from_the_root_to_the_leaf_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testPath)
      {
         //Arrange
         var expected = testPath.ToAncestry();

         var path = testPath.ToTetra();

         //Act
         var actual = path.Ancestry();

         //Assert
         return AreSequenceEqual(AssertMessages.ReturnValue,
                                 expected,
                                 actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}