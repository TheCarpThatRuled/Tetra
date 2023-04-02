using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Do
{
   /* ------------------------------------------------------------ */
   // IResult<TSuccess, TFailure> Do(Action<TSuccess> whenSuccess,
   //                                Action<TFailure> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int_and_int
   //WHEN
   //Do_AND_whenSuccess_is_a_Action_of_int_AND_whenFailure_is_a_Action_of_int
   //THEN
   //whenSuccess_was_invoked_once_with_the_content_AND_whenFailure_was_not_invoked_AND_the_this_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_int_and_int_WHEN_Do_AND_whenSuccess_is_a_Action_of_int_AND_whenFailure_is_a_Action_of_int_THEN_whenSuccess_was_invoked_once_with_the_content_AND_whenFailure_was_not_invoked_AND_the_this_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenSuccess = FakeAction<int>.Create();
         var whenFailure = FakeAction<int>.Create();

         var result = Result<int, int>.Success(value);

         //Act
         var actual = result.Do(whenSuccess.Action,
                                whenFailure.Action);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         result,
                         actual)
               .And(WasInvokedOnce(nameof(whenSuccess),
                                   value,
                                   whenSuccess))
               .And(WasNotInvoked(nameof(whenFailure),
                                  whenFailure));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}