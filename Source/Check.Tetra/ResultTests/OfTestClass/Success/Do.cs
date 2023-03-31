namespace Check.ResultTests.OfTestClass;

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
   //Success_of_TestClass
   //WHEN
   //Do_AND_whenSuccess_is_a_Action_AND_whenFailure_is_a_Action_of_TestClass
   //THEN
   //whenSuccess_was_invoked_once_AND_whenFailure_was_not_invoked_AND_this_is_returned

   [TestMethod]
   public void
      GIVEN_Success_of_TestClass_WHEN_Do_AND_whenSuccess_is_a_Action_AND_whenFailure_is_a_Action_of_TestClass_THEN_whenSuccess_was_invoked_once_AND_whenFailure_was_not_invoked_AND_this_is_returned()
   {
      //Arrange
      var whenSuccess = FakeAction.Create();
      var whenFailure = FakeAction<TestClass>.Create();

      var result = Result<TestClass>.Success();

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