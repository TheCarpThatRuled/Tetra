using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.RelativeFilePath)]
// ReSharper disable once InconsistentNaming
public class GetHashCode
{
   /* ------------------------------------------------------------ */
   // public int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath
   //WHEN
   //GetHashCode
   //THEN
   //the_ordinal_ignore_case_hash_code_of_the_value_is_returned

   [TestMethod]
   public void GIVEN_RelativeFilePath_WHEN_GetHashCode_THEN_the_ordinal_ignore_case_hash_code_of_the_value_is_returned()
   {
      static Property Property(TestRelativeFilePath testPath)
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

      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestRelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}