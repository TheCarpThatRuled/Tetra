using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
public class Parent
{
   /* ------------------------------------------------------------ */
   // public AbsoluteDirectoryPath Parent()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteFilePath
   //WHEN
   //Parent
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_parent_directory_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteFilePath_WHEN_Parent_THEN_an_AbsoluteDirectoryPath_containing_the_parent_directory_is_returned()
   {
      static Property Property(TestAbsoluteFilePath testPath)
      {
         //Arrange
         var expected = testPath.Parent();

         var path = testPath.ToTetra();

         //Act
         var actual = path.Parent();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteFilePath>();

      Prop.ForAll<TestAbsoluteFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}