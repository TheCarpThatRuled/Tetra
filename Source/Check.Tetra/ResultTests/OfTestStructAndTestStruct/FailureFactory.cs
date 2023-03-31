using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStructAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class FailureFactory
{
   /* ------------------------------------------------------------ */
   // static IResult<TSuccess, TFailure> Failure(TFailure content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct
   //WHEN
   //Failure
   //THEN
   //a_failure_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_WHEN_Failure_THEN_a_failure_containing_content_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Act
         var actual = Result<TestStruct, TestStruct>.Failure(value);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           value,
                           actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}