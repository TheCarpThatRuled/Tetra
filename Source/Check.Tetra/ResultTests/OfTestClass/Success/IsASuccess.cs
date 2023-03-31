namespace Check.ResultTests.OfTestClass;

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
   //Success_of_TestClass
   //WHEN
   //IsASuccess
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestClass_WHEN_IsASuccess_THEN_true_is_returned()
   {
      //Arrange
      var result = Result<TestClass>.Success();

      //Act
      var actual = result.IsASuccess();

      //Assert
      Assert.That
            .IsTrue(AssertMessages.ReturnValue,
                    actual);
   }

   /* ------------------------------------------------------------ */
}