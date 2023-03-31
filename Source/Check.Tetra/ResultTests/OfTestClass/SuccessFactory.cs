namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class SuccessFactory
{
   /* ------------------------------------------------------------ */
   // public static Result<T> Success()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass
   //WHEN
   //Success
   //THEN
   //a_success_is_returned

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Success_THEN_a_success_is_returned()
   {
      //Act
      var actual = Result<TestClass>.Success();

      //Assert
      Assert.That
            .IsASuccess(AssertMessages.ReturnValue,
                     actual);
   }
   /* ------------------------------------------------------------ */
}