namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_IsASuccess
{
   /* ------------------------------------------------------------ */
   // bool IsASuccess();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //IsASuccess
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_IsASuccess_THEN_true_is_returned()
   {
      //Arrange
      var result = Result<int>.Success();

      //Act
      var actual = result.IsASuccess();

      //Assert
      Assert.That
            .IsTrue(AssertMessages.ReturnValue,
                    actual);
   }

   /* ------------------------------------------------------------ */
}