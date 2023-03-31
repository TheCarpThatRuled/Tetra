namespace Check.ResultTests.OfTestStruct;

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
   //Success_of_TestStruct
   //WHEN
   //IsASuccess
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestStruct_WHEN_IsASuccess_THEN_true_is_returned()
   {
      //Arrange
      var result = Result<TestStruct>.Success();

      //Act
      var actual = result.IsASuccess();

      //Assert
      Assert.That
            .IsTrue(AssertMessages.ReturnValue,
                    actual);
   }

   /* ------------------------------------------------------------ */
}