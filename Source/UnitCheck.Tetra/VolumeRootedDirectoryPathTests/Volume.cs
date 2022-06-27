using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedDirectoryPath)]
public class VolumeProperty
{
   /* ------------------------------------------------------------ */
   // Volume Volume()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeRootedDirectoryPath
   //WHEN
   //Volume
   //THEN
   //a_Volume_containing_the_volume_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeRootedDirectoryPath_WHEN_Volume_THEN_a_Volume_containing_the_volume_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var volumeRootedDirectoryPath = VolumeRootedDirectoryPath.Create(volume,
                                                                     directories);

         //Act
         var actual = volumeRootedDirectoryPath.Volume();

         //Assert
         return AreEqual(volume,
                         actual);
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<Tetra.Volume, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}