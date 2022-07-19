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
   // public static IReadOnlyList<AbsoluteDirectoryPath> Ancestry(this AbsoluteDirectoryPath path)
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
      static Property Property(VolumeComponent      volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var expected = ExpectedPath.BuildAncestry(volume,
                                                   directories);

         //Act
         var actual = expected[^1].Ancestry();

         //Assert
         return AreSequenceEqual(expected,
                                 actual);
      }

      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}