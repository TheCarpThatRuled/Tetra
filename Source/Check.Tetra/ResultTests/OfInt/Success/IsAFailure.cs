namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_IsAFailure
{
   /* ------------------------------------------------------------ */
   // bool IsAFailure();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //IsAFailure
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_IsAFailure_THEN_false_is_returned()
   {
      //Arrange
      var result = Result<int>.Success();

      //Act
      var actual = result.IsAFailure();

      //Assert
      Assert.That
            .IsFalse(AssertMessages.ReturnValue,
                     actual);
   }

   /* ------------------------------------------------------------ */
}