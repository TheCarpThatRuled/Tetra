using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.DirectoryComponent)]
public class ToPath
{
   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath ToPath()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent
   //WHEN
   //ToPath
   //THEN
   //a_RelativeDirectoryPath_containing_the_DirectoryComponent_is_returned

   [TestMethod]
   public void GIVEN_a_DirectoryComponent_WHEN_ToPath_THEN_a_RelativeDirectoryPath_containing_the_DirectoryComponent_is_returned()
   {
      static Property Property
      (
         DirectoryComponent directory
      )
      {
         //Arrange
         var expected = TestRelativeDirectoryPath.Create(directory);

         //Act
         var actual = directory.ToPath();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}