using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.FileComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.FileComponent)]
public class ToPath
{
   /* ------------------------------------------------------------ */
   // public static RelativeFilePath ToPath(this FileComponent File)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_FileComponent
   //WHEN
   //ToPath
   //THEN
   //a_RelativeFilePath_containing_the_FileComponent_is_returned

   [TestMethod]
   public void GIVEN_a_FileComponent_WHEN_ToPath_THEN_a_RelativeFilePath_containing_the_FileComponent_is_returned()
   {
      static Property Property(FileComponent file)
      {
         //Arrange
         var expected = TestRelativeFilePath.Create(Array.Empty<DirectoryComponent>(),
                                                    file);

         //Act
         var actual = file.ToPath();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}