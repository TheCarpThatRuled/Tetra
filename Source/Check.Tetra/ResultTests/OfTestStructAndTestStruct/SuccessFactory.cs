using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStructAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class SuccessFactory
{
   /* ------------------------------------------------------------ */
   // static IResult<TSuccess, TFailure> Success(TSuccess content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct
   //WHEN
   //Success
   //THEN
   //a_success_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_WHEN_Success_THEN_a_success_containing_content_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Act
         var actual = Result<TestStruct, TestStruct>.Success(value);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           value,
                           actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}