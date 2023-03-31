namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_GetHashCode
{
   /* ------------------------------------------------------------ */
   // int GetHashCode();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //GetHashCode
   //THEN
   //the_hash_code_of_Type_TestStruct_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestStruct_WHEN_GetHashCode_THEN_the_hash_code_of_Type_TestStruct_is_returned()
   {
      //Arrange
      var result = Result<TestStruct>.Success();

      //Act
      var actual = result.GetHashCode();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      typeof(TestStruct).GetHashCode(),
                      actual);
   }

   /* ------------------------------------------------------------ */
}