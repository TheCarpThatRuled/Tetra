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
      static Property Property(VolumeComponent      volume,
                               DirectoryComponent[] directories,
                               FileComponent file)
      {
         //Arrange
         var expected = ExpectedPath.BuildAncestry(volume,
                                                   directories);

         var path = AbsoluteFilePath.Create(volume,
                                            directories,
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
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, DirectoryComponent[], FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}