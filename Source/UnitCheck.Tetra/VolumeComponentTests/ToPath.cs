using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeComponent)]
public class ToPath
{
   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath ToPath(this VolumeComponent volume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume
   //WHEN
   //ToPath
   //THEN
   //an_AbsoluteDirectoryPath_with_the_value_plus_the_directory_separator_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_WHEN_ToPath_THEN_an_AbsoluteDirectoryPath_with_the_value_plus_the_directory_separator_is_returned()
   {
      static Property Property(VolumeComponent volume)
      {
         //Arrange
         var expected = TestAbsoluteDirectoryPath.Create(volume,
                                                         Array.Empty<DirectoryComponent>());

         //Act
         var actual = volume.ToPath();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}