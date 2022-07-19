using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
public class VolumeProperty
{
   /* ------------------------------------------------------------ */
   // VolumeComponent Volume()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath
   //WHEN
   //Volume
   //THEN
   //a_VolumeComponent_containing_the_volume_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_WHEN_Volume_THEN_a_VolumeComponent_containing_the_volume_is_returned()
   {
      static Property Property(VolumeComponent      volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var path = AbsoluteDirectoryPath.Create(volume,
                                                 directories);

         //Act
         var actual = path.Volume();

         //Assert
         return AreEqual(volume,
                         actual);
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<VolumeComponent, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}