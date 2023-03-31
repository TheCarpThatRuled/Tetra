using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.FileComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.FileComponent)]
public class ToPath
{
   /* ------------------------------------------------------------ */
   // public RelativeFilePath ToPath()
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
         var expected = TestRelativeFilePath.Create(Sequence<DirectoryComponent>.Empty(),
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