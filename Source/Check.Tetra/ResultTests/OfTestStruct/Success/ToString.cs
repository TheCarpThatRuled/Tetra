namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_ToString
{
   /* ------------------------------------------------------------ */
   // string ToString();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //ToString
   //THEN
   //Success_of_TestStruct_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestStruct_WHEN_ToString_THEN_Success_of_TestStruct_is_returned()
   {
      //Arrange
      var result = Result<TestStruct>.Success();

      //Act
      var actual = result.ToString();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      "Success of TestStruct",
                      actual);
   }

   /* ------------------------------------------------------------ */
}