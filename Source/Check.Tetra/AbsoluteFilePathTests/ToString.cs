using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
// ReSharper disable once InconsistentNaming
public class ToString
{
   /* ------------------------------------------------------------ */
   // string ToString();
   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath
   //WHEN
   //ToString
   //THEN
   //the_value_bounded_by_angle_brackets_is_returned

   [TestMethod]
   public void GIVEN_AbsoluteFilePath_WHEN_ToString_THEN_the_value_bounded_by_angle_brackets_is_returned()
   {
      static Property Property(TestAbsoluteFilePath testPath)
      {
         //Arrange
         var path = testPath.ToTetra();

         //Act
         var actual = path.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"<{testPath.PathWithoutTrailingDirectorySeparator()}>",
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteFilePath>();

      Prop.ForAll<TestAbsoluteFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}