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
   // Volume Volume()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_AbsoluteDirectoryPath
   //WHEN
   //Volume
   //THEN
   //a_Volume_containing_the_volume_is_returned

   [TestMethod]
   public void GIVEN_a_AbsoluteDirectoryPath_WHEN_Volume_THEN_a_Volume_containing_the_volume_is_returned()
   {
      static Property Property(Volume               volume,
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

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<Tetra.Volume, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}