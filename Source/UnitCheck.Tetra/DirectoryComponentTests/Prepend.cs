using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.DirectoryComponent)]
public class Prepend
{
   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Append(this DirectoryComponent ,
   //                              VolumeComponent volume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Directory_AND_a_VolumeComponent
   //WHEN
   //Prepend
   //THEN
   //a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Directory_and_a_VolumeComponent_WHEN_Prepend_THEN_a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(DirectoryComponent directory,
                               VolumeComponent    volume)
      {
         //Arrange
         var expected = ExpectedPath.Combine(volume,
                                             new[] {directory});

         //Act
         var actual = directory.Prepend(volume);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.DirectoryComponent>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<DirectoryComponent, VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}