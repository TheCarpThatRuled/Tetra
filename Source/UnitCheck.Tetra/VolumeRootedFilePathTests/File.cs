using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedFilePath)]
public class File
{
   /* ------------------------------------------------------------ */
   // VolumeRootedDirectoryPath File()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeRootedFilePath
   //WHEN
   //File
   //THEN
   //a_FileComponent_containing_the_file_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeRootedFilePath_WHEN_File_THEN_a_FileComponent_containing_the_File_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] directories,
                               FileComponent        file)
      {
         //Arrange
         var volumeRootedDirectoryPath = VolumeRootedFilePath.Create(volume,
                                                                     directories,
                                                                     file);

         //Act
         var actual = volumeRootedDirectoryPath.File();

         //Assert
         return AreEqual(file,
                         actual);
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<Volume, DirectoryComponent[], FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}