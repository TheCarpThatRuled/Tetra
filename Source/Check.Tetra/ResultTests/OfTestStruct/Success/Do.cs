namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Do
{
   /* ------------------------------------------------------------ */
   // IResult<T> Do(Action    whenSuccess,
   //               Action<T> whenFailure);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //Do_AND_whenSuccess_is_a_Action_AND_whenFailure_is_a_Action_of_TestStruct
   //THEN
   //whenSuccess_was_invoked_once_AND_whenFailure_was_not_invoked_AND_this_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestStruct_WHEN_Do_AND_whenSuccess_is_a_Action_AND_whenFailure_is_a_Action_of_TestStruct_THEN_whenSuccess_was_invoked_once_AND_whenFailure_was_not_invoked_AND_this_is_returned()
   {
      //Arrange
      var whenSuccess = FakeAction.Create();
      var whenFailure = FakeAction<TestStruct>.Create();

      var result = Result<TestStruct>.Success();

      //Act
      var actual = result.Do(whenSuccess.Action,
                             whenFailure.Action);

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      result,
                      actual)
            .WasInvokedOnce(nameof(whenSuccess),
                            whenSuccess)
            .WasNotInvoked(nameof(whenFailure),
                           whenFailure);
   }

   /* ------------------------------------------------------------ */
}