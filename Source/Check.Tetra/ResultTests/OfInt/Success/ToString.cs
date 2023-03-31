namespace Check.ResultTests.OfInt;

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
   //Success_of_int
   //WHEN
   //ToString
   //THEN
   //Success_of_Int32_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_ToString_THEN_Success_of_Int32_is_returned()
   {
      //Arrange
      var result = Result<int>.Success();

      //Act
      var actual = result.ToString();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      "Success of Int32",
                      actual);
   }

   /* ------------------------------------------------------------ */
}