using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedDirectoryPath)]
// ReSharper disable once InconsistentNaming
public class ToString
{
   /* ------------------------------------------------------------ */
   // string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedDirectoryPath
   //WHEN
   //ToString
   //THEN
   //the_value_bounded_by_angle_brackets_is_returned

   [TestMethod]
   public void GIVEN_VolumeRootedDirectoryPath_WHEN_ToString_THEN_the_value_bounded_by_angle_brackets_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         var volumeRootedDirectoryPath = VolumeRootedDirectoryPath.Create(path);

         //Act
         var actual = volumeRootedDirectoryPath.ToString();

         //Assert
         return AreEqual($"<{path}>",
                         actual);
      }

      Arb.Register<Libraries.ValidVolumeRootedPath>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}