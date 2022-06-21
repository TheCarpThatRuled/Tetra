using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedFilePath)]
// ReSharper disable once InconsistentNaming
public class ToString
{
   /* ------------------------------------------------------------ */
   // string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath
   //WHEN
   //ToString
   //THEN
   //the_value_bounded_by_angle_brackets_is_returned

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_WHEN_ToString_THEN_the_value_bounded_by_angle_brackets_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         var volumeRootedFilePath = VolumeRootedFilePath.Create(path);

         //Act
         var actual = volumeRootedFilePath.ToString();

         //Assert
         return AreEqual($"<{path}>",
                         actual);
      }

      Arb.Register<Libraries.ValidPathWithVolumeRootAndTrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}