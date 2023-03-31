using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStructAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_Do
{
   /* ------------------------------------------------------------ */
   // IResult<TSuccess, TFailure> Do(Action<TSuccess> whenSuccess,
   //                                Action<TFailure> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct_and_TestStruct
   //WHEN
   //Do_AND_whenSuccess_is_a_Action_of_TestStruct_AND_whenFailure_is_a_Action_of_TestStruct
   //THEN
   //whenSuccess_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_this_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_TestStruct_and_TestStruct_WHEN_Do_AND_whenSuccess_is_a_Action_of_TestStruct_AND_whenFailure_is_a_Action_of_TestStruct_THEN_whenSuccess_was_not_invoked_AND_whenFailure_was_invoked_once_with_the_content_AND_the_this_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenSuccess = FakeAction<TestStruct>.Create();
         var whenFailure = FakeAction<TestStruct>.Create();

         var result = Result<TestStruct, TestStruct>.Failure(value);

         //Act
         var actual = result.Do(whenSuccess.Action,
                                whenFailure.Action);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         result,
                         actual)
               .And(WasNotInvoked(nameof(whenSuccess),
                                  whenSuccess))
               .And(WasInvokedOnce(nameof(whenFailure),
                                   value,
                                   whenFailure));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}