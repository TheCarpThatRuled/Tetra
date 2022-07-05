using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Volume)]
public class ToDirectoryPath
{
   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath ToDirectoryPath(this Volume volume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume
   //WHEN
   //ToDirectoryPath
   //THEN
   //a_AbsoluteDirectoryPath_with_the_value_plus_the_directory_separator_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_WHEN_Create_THEN_a_AbsoluteDirectoryPath_with_the_value_plus_the_directory_separator_is_returned()
   {
      static Property Property(Volume volume)
      {
         //Arrange
         var expected = volume.Value()
                      + Path.DirectorySeparatorChar;

         //Act
         var actual = volume.ToDirectoryPath();

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.Volume>();

      Prop.ForAll<Volume>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}