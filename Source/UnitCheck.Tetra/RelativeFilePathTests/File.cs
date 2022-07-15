using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeFilePath)]
public class File
{
   /* ------------------------------------------------------------ */
   // FileComponent File()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath
   //WHEN
   //File
   //THEN
   //a_FileComponent_containing_the_file_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_WHEN_File_THEN_a_FileComponent_containing_the_File_is_returned()
   {
      static Property Property(DirectoryComponent[] directories,
                               FileComponent        file)
      {
         //Arrange
         var path = RelativeFilePath.Create(directories,
                                            file);

         //Act
         var actual = path.File();

         //Assert
         return AreEqual(file,
                         actual);
      }

      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<DirectoryComponent[], FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}