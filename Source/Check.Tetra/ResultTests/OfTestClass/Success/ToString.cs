namespace Check.ResultTests.OfTestClass;

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
   //Success_of_TestClass
   //WHEN
   //ToString
   //THEN
   //Success_of_TestClass_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestClass_WHEN_ToString_THEN_Success_of_TestClass_is_returned()
   {
      //Arrange
      var result = Result<TestClass>.Success();

      //Act
      var actual = result.ToString();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      "Success of TestClass",
                      actual);
   }

   /* ------------------------------------------------------------ */
}