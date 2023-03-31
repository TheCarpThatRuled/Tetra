namespace Check.ResultTests.OfTestClass;

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
   //Success_of_TestClass
   //WHEN
   //GetHashCode
   //THEN
   //the_hash_code_of_Type_TestClass_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestClass_WHEN_GetHashCode_THEN_the_hash_code_of_Type_TestClass_is_returned()
   {
      //Arrange
      var result = Result<TestClass>.Success();

      //Act
      var actual = result.GetHashCode();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      typeof(TestClass).GetHashCode(),
                      actual);
   }

   /* ------------------------------------------------------------ */
}