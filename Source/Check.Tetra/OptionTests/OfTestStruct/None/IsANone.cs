namespace Check.OptionTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_IsANone
{
   /* ------------------------------------------------------------ */
   // public bool IsANone()
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct
   //WHEN
   //IsANone
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestStruct_WHEN_IsANone_THEN_true_is_returned()
   {
      //Arrange
      var option = Option<TestStruct>.None();

      //Act
      var actual = option.IsANone();

      //Assert
      Assert.That
            .IsTrue(AssertMessages.ReturnValue,
                    actual);
   }

   /* ------------------------------------------------------------ */
}