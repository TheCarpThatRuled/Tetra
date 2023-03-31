namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class SuccessFactory
{
   /* ------------------------------------------------------------ */
   // static Result<T> Success();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int
   //WHEN
   //Success
   //THEN
   //a_success_is_returned

   [TestMethod]
   public void GIVEN_Result_of_int_WHEN_Success_THEN_a_success_is_returned()
   {
      //Act
      var actual = Result<int>.Success();

      //Assert
      Assert.That
            .IsASuccess(AssertMessages.ReturnValue,
                     actual);
   }
   /* ------------------------------------------------------------ */
}