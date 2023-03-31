using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
// ReSharper disable once InconsistentNaming
public class GetHashCode
{
   /* ------------------------------------------------------------ */
   // int GetHashCode();
   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath
   //WHEN
   //GetHashCode
   //THEN
   //the_ordinal_ignore_case_hash_code_of_the_value_is_returned

   [TestMethod]
   public void GIVEN_AbsoluteFilePath_WHEN_GetHashCode_THEN_the_ordinal_ignore_case_hash_code_of_the_value_is_returned()
   {
      static Property Property(TestAbsoluteFilePath testPath)
      {
         //Arrange
         var path = testPath.ToTetra();

         //Act
         var actual = path.GetHashCode();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .GetHashCode(testPath.PathWithoutTrailingDirectorySeparator()),
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteFilePath>();

      Prop.ForAll<TestAbsoluteFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}