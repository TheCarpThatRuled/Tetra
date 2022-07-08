using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
public class VolumeProperty
{
   /* ------------------------------------------------------------ */
   // Volume Volume()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_AbsoluteFilePath
   //WHEN
   //Volume
   //THEN
   //a_Volume_containing_the_volume_is_returned

   [TestMethod]
   public void GIVEN_a_AbsoluteFilePath_WHEN_Volume_THEN_a_Volume_containing_the_volume_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] directories,
                               FileComponent        file)
      {
         //Arrange
         var path = AbsoluteFilePath.Create(volume,
                                                                     directories,
                                                                     file);

         //Act
         var actual = path.Volume();

         //Assert
         return AreEqual(volume,
                         actual);
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<Tetra.Volume, DirectoryComponent[], FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}