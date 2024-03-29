﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.RelativeDirectoryPath)]
public class Ancestry
{
   /* ------------------------------------------------------------ */
   // public ISequence<RelativeDirectoryPath> Ancestry()
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
      static Property Property
      (
         TestRelativeDirectoryPath testPath
      )
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

      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestRelativeDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}