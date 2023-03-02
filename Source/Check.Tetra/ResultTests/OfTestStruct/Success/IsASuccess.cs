using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_IsASuccess
{
   /* ------------------------------------------------------------ */
   // bool IsASuccess()
   /* ------------------------------------------------------------ */

   //GIVEN
   //TestStruct
   //WHEN
   //IsASuccess
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_TestStruct_WHEN_IsASuccess_THEN_true_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.IsASuccess();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}