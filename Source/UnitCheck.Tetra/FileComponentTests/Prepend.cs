using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.FileComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.FileComponent)]
public class Prepend
{
   /* ------------------------------------------------------------ */
   // AbsoluteFilePath Append(this FileComponent file,
   //                         FileComponent volume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_FileComponent_AND_a_VolumeComponent
   //WHEN
   //Prepend
   //THEN
   //an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_FileComponent_AND_a_VolumeComponent_WHEN_Prepend_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(FileComponent   file,
                               VolumeComponent volume)
      {
         //Arrange
         var expected = TestAbsoluteFilePath.Create(volume,
                                             Array.Empty<DirectoryComponent>(),
                                             file);

         //Act
         var actual = file.Prepend(volume);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.FileComponent>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<FileComponent, VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}